using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class PurchasingManagementLogic
    {

        /// <summary>
        /// Add Purchase Order products and their prices to the database
        /// </summary>
        public void AddPurchaseProductAndPrice(int orderId, List<PurchaseOrderDetails_Join> PurchaseOrderContentList, DateTime documentPostingDate)
        {
            foreach (var row in PurchaseOrderContentList)
            {
                if (row.ProductId != 0 &&
                    row.ProductName != "" &&
                    row.Quantity != 0)
                {
                    CreatePurchaseOrderProuct(orderId, row);
                    CreatePurchaseOrderPrice(orderId, PurchaseOrderContentList.IndexOf(row), row, documentPostingDate);
                }
            }
        }

        /// <summary>
        /// Deletes purchase rder products and their prices from the database
        /// </summary>
        public void DeletePurchaseProductAndPrice(int orderId, List<PurchaseOrderDetails_Join> PurchaseOrderContentList)
        {
            foreach (PurchaseOrderDetails_Join row in PurchaseOrderContentList)
            {
                GlobalConfig.Connection.DeletePurchasePrice(row.ProductId, orderId);
                GlobalConfig.Connection.Delete_PO_Product(row.ProductId, orderId);
            }
        }

        /// <summary>
        /// Creates a purchase price for the product on the "row" recieved as a parameter
        /// </summary>
        public void CreatePurchaseOrderPrice(int orderId, int rowIndex, PurchaseOrderDetails_Join row, DateTime documentPostingDate)
        {
            PurchasePriceModel purchasePrice = new PurchasePriceModel()
            {
                ProductId = row.ProductId,
                PurchasePrice = row.PurchasePrice,
                PurchaseDate = documentPostingDate.Date,
                PurchaseOrderId = orderId,
                RowIndex = rowIndex,
                TaxId = row.TaxId
            };

            GlobalConfig.Connection.CreatePurchasePrice(purchasePrice);
        }
        /// <summary>
        /// Creates a purchase OrderProductModel and adds it to the database
        /// </summary>
        public void CreatePurchaseOrderProuct(int orderId, PurchaseOrderDetails_Join row)
        {
            OrderProductModel op = new OrderProductModel
            {
                OrderId = orderId,
                ProductId = row.ProductId,
                ProductName = row.ProductName,
                OrderedQuantity = row.Quantity,
                TaxId = row.TaxId
            };

            GlobalConfig.Connection.Create_PO_Product(op);
        }

        /// <summary>
        /// Adds a product to stock as a new entry or updating an existing one
        /// </summary>
        public void AddProductToStock(ProductStockModel product)
        {
            ProductStockModel existingProductStock = GlobalConfig.Connection.GetProductStock_Single(product.ProductId);
            if (existingProductStock != null)
            {
                existingProductStock.Quantity += product.Quantity;
                existingProductStock.AvailableQuantity += product.AvailableQuantity;
                GlobalConfig.Connection.UpdateProductStockModel(existingProductStock);
            }
            else
            {
                GlobalConfig.Connection.CreateProductStock(product);
            }
        }

        /// <summary>
        /// Calculates due date for the purchase invoice
        /// </summary>
        private DateTime GetDueDate(DateTime dueDate, PaymentTermsModel paymentTerm)
        {
            return dueDate.Date.AddDays(/*((PaymentTermsModel)PaymentTermComboBox.SelectedItem)*/paymentTerm.PaymentTerm_Days);
        }

        /// <summary>
        /// Create a new purchase order and adds it to the database
        /// </summary>
        public PurchaseOrderModel AddPurchaseOrderToDatabase(CompanyModel supplier, DateTime postingDate, DateTime documentDate, PaymentTermsModel paymentTerm)
        {
            PurchaseOrderModel purchaseOrder = new PurchaseOrderModel
            {
                Status = OrderStatus.Active,
                SupplierId = supplier.Id,
                SupplierName = supplier.Name,
                PostingDate = postingDate,
                DueDate = GetDueDate(postingDate, paymentTerm),
                DocumentDate = documentDate
            };

            GlobalConfig.Connection.CreatePurchaseOrder(purchaseOrder);
            return purchaseOrder;
        }

        /// <summary>
        /// Add the product quantities on the purchase invoice in stock making them available to be sold
        /// </summary>
        public void AddInvoicedProductsToStock(List<PurchaseOrderDetails_Join> PurchaseOrderContentList)
        {
            foreach (var row in PurchaseOrderContentList)
            {
                if (row.ProductId != 0 && row.ProductName != "" && row.Quantity != 0)
                {
                    ProductStockModel productStock = new ProductStockModel()
                    {
                        ProductId = row.ProductId,
                        Quantity = row.Quantity,
                        AvailableQuantity = row.Quantity,
                    };

                    AddProductToStock(productStock);
                }
            }
        }

        /// <summary>
        /// Updates the purchase prices when registering a purchase invoice
        /// </summary>
        public void UpdatePurchasePrices(List<PurchaseOrderDetails_Join> PurchaseOrderContentList, int purchaseOrderId)
        {
            foreach (PurchaseOrderDetails_Join row in PurchaseOrderContentList)
            {
                PurchasePriceModel purchasePrice = GlobalConfig.Connection.GetPurchasePrice_By_Id(purchaseOrderId, row.ProductId, PurchaseOrderContentList.IndexOf(row));
                purchasePrice.PurchasePrice = row.PurchasePrice;
                purchasePrice.TaxId = row.TaxId;

                GlobalConfig.Connection.UpdatePurchasePriceModel(purchasePrice);
            }

        }

        /// <summary>
        /// Converts Purchase Order products(OrderProductModel) into PurchaseOrderDetails_Join to be properly displayed 
        /// in the datagrid
        /// </summary>
        /// <param name="poProductList">Purchase order product list</param>
        /// <returns>A list of PurchaseOrderDetails_Join which is a "mixed" object with the purpose of displaying
        /// product names in the purchase order/invoice datagrid</returns>
        public List<PurchaseOrderDetails_Join> TransformPOContent(List<OrderProductModel> poProductList)
        {
            List<PurchaseOrderDetails_Join> poContent = new List<PurchaseOrderDetails_Join>();

            foreach (OrderProductModel poProduct in poProductList)
            {
                poContent.Add(new PurchaseOrderDetails_Join()
                {
                    ProductId = poProduct.ProductId,
                    ProductName = poProduct.ProductName,
                    PurchasePrice = GlobalConfig.Connection.GetPurchasePrice_By_Id(poProduct.OrderId, poProduct.ProductId, poProductList.IndexOf(poProduct)).PurchasePrice,
                    Quantity = poProduct.OrderedQuantity,
                    TaxId = poProduct.TaxId
                });
            }

            return poContent;
        }

        /// <summary>
        /// Initializes the datagridview with enpty rows
        /// </summary>
        public List<PurchaseOrderDetails_Join> InitPOContentList_WithEmptyRows()
        {
            return new List<PurchaseOrderDetails_Join>
                {
                    new PurchaseOrderDetails_Join(),
                    new PurchaseOrderDetails_Join(),
                    new PurchaseOrderDetails_Join(),
                    new PurchaseOrderDetails_Join(),
                    new PurchaseOrderDetails_Join(),
                    new PurchaseOrderDetails_Join(),
                    new PurchaseOrderDetails_Join(),
                    new PurchaseOrderDetails_Join(),
                    new PurchaseOrderDetails_Join(),
                    new PurchaseOrderDetails_Join()
                };
        }

        /// <summary>
        /// Gets and returns the empty row's index, for the row that is empty and is closest from the colection's start index
        /// </summary>
        public int GetClosestEmptyRowIndex(List<PurchaseOrderDetails_Join> PurchaseOrderContentList)
        {
            var purchaseRow = PurchaseOrderContentList.First(r => (r.ProductId == 0) || (r.ProductName == null || r.ProductName == ""));
            return PurchaseOrderContentList.IndexOf(purchaseRow);
        }

        /// <summary>
        /// Counts the remaining empty rows from the Purchase Order
        /// </summary>
        /// <returns>The number of remaining empty rows in the PurchaseOrderContentList and the associated datagrid</returns>
        public int CountRemainingEmptyRows(List<PurchaseOrderDetails_Join> PurchaseOrderContentList)
        {
            return PurchaseOrderContentList.Count(r => (r.ProductId == 0) || (r.ProductName == null || r.ProductName == ""));
        }

        /// <summary>
        /// Retrieves a list of products matching the "product name" inserted into the cell
        /// </summary>
        /// <param name="productName">The "product name" inserted into the cell</param>
        public List<ProductModel> SearchProductByName(string productName, List<ProductModel> ProductsList)
        {
            return ProductsList.Where(p => p.Name.ToLower().Contains(productName.ToLower())).ToList();
        }

        /// <summary>
        /// Retrieves a product model matching the id passed as parameter
        /// </summary>
        public ProductModel RetrieveProductById(int Id, List<ProductModel> ProductsList)
        {
            if (Id == 0)
            {
                //MessageBox.Show("Please enter a valid product ID");
                return null;
            }
            return ProductsList.Where(p => p.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// Adds the searched(by name) product to the closest empty row in the purchase order content list
        /// </summary>
        public void AddProductToPurchaseOrderContent_BySearchedName(string productName, int closestEmptyRowIndex, List<ProductModel> ProductsList, List<PurchaseOrderDetails_Join> PurchaseOrderContentList, int taxId)
        {
            if (RMS_Logic.PurchasingLogic.SearchProductByName(productName, ProductsList).Count() == 1)
            {
                ProductModel productToAdd = RMS_Logic.PurchasingLogic.SearchProductByName(productName, ProductsList).First();

                PurchaseOrderContentList[closestEmptyRowIndex] = new PurchaseOrderDetails_Join
                {
                    ProductId = productToAdd.Id,
                    ProductName = productToAdd.Name,
                    Quantity = 1,
                    TaxId = taxId // ((TaxModel)ProductTaxComboBox.SelectedItem).Id
                };
            }
        }

        /// <summary>
        /// Adds the searched product(by id) to the closest empty row in the purchase order content list
        /// </summary>
        public void AddProductToPurchaseOrderContent_BySearchedId(int closestEmptyRowIndex, List<PurchaseOrderDetails_Join> PurchaseOrderContentList, int taxId, ProductModel productToAdd)
        {
            PurchaseOrderContentList[closestEmptyRowIndex] = new PurchaseOrderDetails_Join
            {
                ProductId = productToAdd.Id,
                ProductName = productToAdd.Name,
                Quantity = 1,
                TaxId = taxId
            };
        }

        /// <summary>
        /// Validates if conditions are met to calculate the purchase order totals
        /// </summary>
        private bool ValidatePurchaseOrderTotalCalculations(TaxModel taxToUse, int index, List<PurchaseOrderDetails_Join> PurchaseOrderContentList)
        {
            return (PurchaseOrderContentList[index].ProductId != 0 &&
                                PurchaseOrderContentList[index].PurchasePrice != 0 &&
                                !(PurchaseOrderContentList[index].PurchasePrice < 0) &&
                                PurchaseOrderContentList[index].Quantity > 0)&&
                                taxToUse != null &&
                                (PurchaseOrderContentList[index].ProductName != null && PurchaseOrderContentList[index].ProductName != "");
        }

        /// <summary>
        /// Calculates the Purchase Order total Value
        /// </summary>
        public OrderTotal CalculatePurchaseOrderTotal(List<PurchaseOrderDetails_Join> PurchaseOrderContentList)
        {
            OrderTotal purchaseOrderTotal = new OrderTotal();
            TaxModel taxToUse = GlobalConfig.Connection.GetTaxSingle(PurchaseOrderContentList[0].TaxId) == null ? 
                                        GlobalConfig.Connection.GetTaxes_All().Where(t => t.DefaultSelectedTax).Single() : 
                                        GlobalConfig.Connection.GetTaxSingle(PurchaseOrderContentList[0].TaxId);

            for (int i = 0; i < PurchaseOrderContentList.Count; i++)
            {
                if (ValidatePurchaseOrderTotalCalculations(taxToUse, i, PurchaseOrderContentList))
                {
                    if(PurchaseOrderContentList[i].TaxId != 0 && taxToUse.Id != PurchaseOrderContentList[i].TaxId)
                        taxToUse = GlobalConfig.Connection.GetTaxSingle(PurchaseOrderContentList[i].TaxId);

                    purchaseOrderTotal.Total += PurchaseOrderContentList[i].Quantity * PurchaseOrderContentList[i].PurchasePrice;
                    purchaseOrderTotal.TaxTotal += PurchaseOrderContentList[i].Quantity * (PurchaseOrderContentList[i].PurchasePrice / 100 * (taxToUse.Percent));
                    purchaseOrderTotal.GrandTotal = purchaseOrderTotal.Total + purchaseOrderTotal.TaxTotal;
                }
            }

            return purchaseOrderTotal;
        }

        /// <summary>
        /// Checks if a purchase order was invoiced
        /// </summary>
        /// <returns>true - was not invoiced/ false - was invoiced</returns>
        public bool PurchaseOrderNotInvoiced(PurchaseOrderModel po)
        {
            return GlobalConfig.Connection.GetPurchaseInvoices_All().Where(p => p.RelatedPurchaseOrderId == po.Id).Count() == 0;
        }
    }
}