using RMLibrary.Models;
using RMLibrary.Models.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class SalesManagementLogic
    {
        public OrderTotal CalculateSalesOrderTotal(TaxModel taxToUse, List<OrderProductModel> SalesOrderContentList)
        {
            List<SalesPriceModel> SalesPricesList = GlobalConfig.Connection.GetSalesPrices_All().Where(p => p.CurrentlyActivePrice == true).ToList();
            OrderTotal salesOrderTotal = new OrderTotal();

            for (int i = 0; i < SalesOrderContentList.Count; i++)
            {
                salesOrderTotal += CalculateSalesOrderRowTotals(taxToUse, i, SalesPricesList, SalesOrderContentList);
            }

            return salesOrderTotal;
        }

        /// <summary>
        /// Calculates the sales order totals for the current row and retrieves the grand total
        /// </summary>
        private OrderTotal CalculateSalesOrderRowTotals(TaxModel taxToUse, int rowIndex,
            List<SalesPriceModel> SalesPricesList, List<OrderProductModel> SalesOrderContentList)
        {
            decimal productPrice = SalesPricesList.Where(p => p.ProductId == SalesOrderContentList[rowIndex].ProductId && p.CurrentlyActivePrice == true)
                                          .Single().SalesPrice;
            OrderTotal salesOrderTotal = new OrderTotal();

            salesOrderTotal.Total += SalesOrderContentList[rowIndex].OrderedQuantity * productPrice;
            salesOrderTotal.TaxTotal += SalesOrderContentList[rowIndex].OrderedQuantity * (productPrice / 100 * (taxToUse.Percent));
            salesOrderTotal.GrandTotal = salesOrderTotal.Total + salesOrderTotal.TaxTotal;

            return salesOrderTotal;
        }

        /// <summary>
        /// Increment booked quantity/decrement available quantity, according to the quantity added to the sales order
        /// Update the ProductStockModel in the database
        /// </summary>
        public void UpdateProductStock_OnAddToSalesOrder(ProductStockModel selectedProductStock, int productQtyToAdd)
        {
            selectedProductStock.BookedQuantity += productQtyToAdd;
            selectedProductStock.AvailableQuantity -= productQtyToAdd;
            GlobalConfig.Connection.UpdateProductStockModel(selectedProductStock);
        }

        /// <summary>
        /// Increment the quantity of a product we want to sell, in the sales order content list
        /// </summary>
        public void IncrementExistingProductInSalesOrderContent(OrderProductModel productToSell, int productQtyToAdd)
        {
            productToSell.OrderedQuantity += productQtyToAdd;
            GlobalConfig.Connection.Update_SO_Product(productToSell);
        }

        /// <summary>
        /// Add a new product to the selected sales order content(sales order product list)
        /// </summary>
        public void AddNewProductToSalesOrderContent(SalesOrderModel selectedOrder, ProductModel selectedProduct, TaxModel defaultTax, int productQtyToAdd)
        {
            OrderProductModel newProduct = new OrderProductModel
            {
                ProductId = selectedProduct.Id,
                ProductName = selectedProduct.Name,
                OrderId = selectedOrder.Id,
                OrderedQuantity = productQtyToAdd,
                TaxId = defaultTax.Id
            };

            GlobalConfig.Connection.Create_SO_Product(newProduct);
        }

        /// <summary>
        /// Adds the selected product to the selected sales order in the selected quantities and
        /// updates the product stock available quantity
        /// </summary>
        public void AddProductToSalesOrder(SalesOrderModel selectedOrder, ProductModel selectedProduct, ProductStockModel selectedProductStock,TaxModel taxToUse, int productQtyToAdd)
        {
            OrderProductModel productToSell = CheckIfProductExistsInSalesOrder(selectedProduct, selectedOrder);

            if (productToSell == null)
                AddNewProductToSalesOrderContent(selectedOrder, selectedProduct, taxToUse, productQtyToAdd);
            else
                IncrementExistingProductInSalesOrderContent(productToSell, productQtyToAdd);

            UpdateProductStock_OnAddToSalesOrder(selectedProductStock, productQtyToAdd);
        }

        /// <summary>
        /// Checks if the product already exists in the current sales order
        /// </summary>
        public OrderProductModel CheckIfProductExistsInSalesOrder(ProductModel product, SalesOrderModel order)
        {
            OrderProductModel orderProduct = GlobalConfig.Connection.Get_SO_Products_BySO_Id(order.Id).Where(p => p.ProductId == product.Id && p.OrderId == order.Id).FirstOrDefault();
            if (orderProduct != null)
                return orderProduct;

            return null;
        }

        /// <summary>
        /// Creates a new Sales Order model
        /// </summary>
        public void CreateNewOrder(TableModel newOrderTable, IDeliveryMethod newOrderDeliveryAdress)
        {
            if (newOrderTable != null || newOrderDeliveryAdress != null)
            {
                SalesOrderModel newSalesOrder = new SalesOrderModel
                {
                    Status = OrderStatus.Active
                };

                InitializeNewSalesOrderDeliveryMethod(newSalesOrder, newOrderTable, newOrderDeliveryAdress);

                if (newSalesOrder.Name != null)
                    GlobalConfig.Connection.CreateSalesOrder(newSalesOrder);
            }
        }

        /// <summary>
        /// Initializes the delivery method for a new Sales Order
        /// </summary>
        public void InitializeNewSalesOrderDeliveryMethod(SalesOrderModel newSalesOrder, TableModel newOrderTable, IDeliveryMethod newOrderDeliveryAdress)
        {
            if (newOrderTable != null && newOrderDeliveryAdress == null)
            {
                newSalesOrder.TableId = newOrderTable.Id;
                newSalesOrder.Name = newOrderTable.Name;
            }

            if (newOrderTable == null && newOrderDeliveryAdress != null)
            {
                if (newOrderDeliveryAdress.GetType() == typeof(CompanyModel))
                {
                    newSalesOrder.CompanyId = newOrderDeliveryAdress.Id;
                    newSalesOrder.Name = newOrderDeliveryAdress.Name;
                }
                else
                {
                    newSalesOrder.CustomerId = newOrderDeliveryAdress.Id;
                    newSalesOrder.Name = newOrderDeliveryAdress.Name;
                }
            }
        }

        /// <summary>
        /// Initializes the SalesPricesList
        /// </summary>
        public List<SalesPriceModel> InitializeSalesPricesList()
        {
            return GlobalConfig.Connection.GetSalesPrices_All().Where(p => p.CurrentlyActivePrice == true).ToList();
        }

        /// <summary>
        /// Deletes the sales order products from the productsToDelete list
        /// </summary>
        public void DeleteProductsFromSalesOrder(List<OrderProductModel> productsToDelete)
        {
            foreach (var product in productsToDelete)
            {
                GlobalConfig.Connection.Delete_SO_Product(product);
            }
        }

        /// <summary>
        /// Removes / frees booked products
        /// </summary>
        /// <param name="productsToUnbook"> Products to be removed from the booked section abd be made available to be sold</param>
        public  void UnBookProducts(List<OrderProductModel> productsToUnbook)
        {
            foreach (OrderProductModel product in productsToUnbook)
            {
                ProductStockModel selectedProductStock = GlobalConfig.Connection.GetProductStock_Single(product.ProductId);

                if (CanUnBookProduct(product, selectedProductStock))
                {
                    selectedProductStock.BookedQuantity -= product.OrderedQuantity;
                    selectedProductStock.AvailableQuantity += product.OrderedQuantity;
                    GlobalConfig.Connection.UpdateProductStockModel(selectedProductStock);
                }
            }
        }

        /// <summary>
        /// Checks if the product stock model is not null, and there is enough booked quantity that we can also 
        /// un-book the requested quantity from the sales order
        /// </summary>
        public static bool CanUnBookProduct(OrderProductModel product, ProductStockModel selectedProductStock)
        {
            return selectedProductStock != null &&
                   selectedProductStock.BookedQuantity >= product.OrderedQuantity &&
                   selectedProductStock.Quantity >= product.OrderedQuantity;
        }

        /// <summary>
        /// Removes / frees booked products
        /// </summary>
        /// <param name="productsToRemove"> Products to be removed from the booked section abd be made available to be sold</param>
        public void RemoveProductsFromStock(List<OrderProductModel> productsToRemove)
        {
            foreach (OrderProductModel product in productsToRemove)
            {
                ProductStockModel selectedProductStock = GlobalConfig.Connection.GetProductStock_Single(product.ProductId);

                if (selectedProductStock != null)
                {
                    selectedProductStock.Quantity -= product.OrderedQuantity;
                    selectedProductStock.AvailableQuantity -= product.OrderedQuantity;

                    GlobalConfig.Connection.UpdateProductStockModel(selectedProductStock);
                }
            }
        }

        /// <summary>
        /// Validates if the selected product is not null and has a quantity >= than the quantity we want to sell
        /// </summary>
        public bool CheckProductToSellAvailability(ProductStockModel selectedProductStock, int productQtyToAdd)
        {
            return selectedProductStock != null && selectedProductStock.AvailableQuantity >= productQtyToAdd;
        }

        /// <summary>
        /// Decrement booked quantity/inccrement available quantity for the selected ProductStockModel item
        /// </summary>
        public void UnBookSalesOrderProduct(ProductStockModel selectedProductStock)
        {
            selectedProductStock.BookedQuantity--;
            selectedProductStock.AvailableQuantity++;
            GlobalConfig.Connection.UpdateProductStockModel(selectedProductStock);
        }

        /// <summary>
        /// Removes a  product(a single piece) from the selected sales order
        /// </summary>
        public void RemoveProductFromSalesOrder(OrderProductModel productToRemove)
        {
            if (productToRemove != null)
            {
                if (productToRemove.OrderedQuantity > 1)
                {
                    productToRemove.OrderedQuantity--;
                    GlobalConfig.Connection.Update_SO_Product(productToRemove);
                }
                else
                {
                    GlobalConfig.Connection.Delete_SO_Product(productToRemove);
                }
            }
        }
    }
}