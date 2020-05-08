using RMLibrary;
using RMLibrary.Models;
using RMLibrary.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class RestaurantManagementForm : Form, IDeliveryMethodRequester, ICompanyRequester, IProductRequester, IPaymentTermRequester, IDocumentRequester, ISalesPriceUpdater, ISalesOrderPreviewer
    {
        private PurchaseOrderState CurrentPOState;

        private TableModel newOrderTable;
        private IDeliveryMethod newOrderDeliveryAdress;

        private CompanyModel selectedSupplier;
        private bool displayPurchaseOrder;
        private ProductModel productToAdd;
        private int productQtyToAdd;
        private bool SO_ProductSearchBoxIsActive = false;

        private TaxModel DefaultTax = GlobalConfig.Connection.GetTaxes_All().Where(t => t.DefaultSelectedTax == true).FirstOrDefault();


        public List<SalesOrderModel> SalesOrdersList { get; set; }
        public List<OrderProductModel> SalesOrderContentList { get; set; }
        public List<PurchaseOrderDetails_Join> PurchaseOrderContentList { get; set; }
        public List<ProductModel> ProductsList { get; set; }
        public List<CategoryModel> CategoriesList { get; set; }
        public List<TaxModel> TaxList { get; set; }
        public List<PaymentTermsModel> PaymentTermsList { get; set; }
        public List<SalesPriceModel> SalesPricesList { get; set; }
        public PurchaseOrderModel SelectedPurchaseOrder { get; set; }

        //Default Constructor
        public RestaurantManagementForm()
        {
            InitializeComponent();
            InitializeSalesPricesList();
            InitializeTaxList();
            InitializeProductsList(0);
            InitializeSalesOrdersList();
            InitializePO_TaxList();
            InitializePaymentTermsList();
            InitializeProductCategoryList();
            UpdateDueDate();

            productQtyToAdd = 1;
            CurrentPOState = PurchaseOrderState.NewEmptyPO_NotAdded;

            OrderStatusFilterComboBox.SelectedItem = OrderStatus.Active;
            InitializeOrderStatusFilter();

            displayPurchaseOrder = true;
            POrdersCheckBox.Checked = displayPurchaseOrder;
        }


        /// <summary>
        /// Creates a new Sales Order
        /// Opens a Window to select a delivery date & adress / a table in the "restaurant"
        /// </summary>
        public void CreateNewOrderButton_Click(object sender, EventArgs e)
        {
            CreateNewSalesOrderForm soFrm = new CreateNewSalesOrderForm(this);
            soFrm.Show();
        }

        /// <summary>
        /// Creates a new Sales Order model
        /// </summary>
        private void CreateNewOrder()
        {
            if (newOrderTable != null || newOrderDeliveryAdress != null)
            {
                SalesOrderModel newSalesOrder = new SalesOrderModel
                {
                    Status = OrderStatus.Active
                };

                InitializeNewSalesOrderDeliveryMethod(newSalesOrder);

                if (newSalesOrder.Name != null)
                    GlobalConfig.Connection.CreateSalesOrder(newSalesOrder);
            }
        }

        /// <summary>
        /// Initializes the delivery method for a new Sales Order
        /// </summary>
        private void InitializeNewSalesOrderDeliveryMethod(SalesOrderModel newSalesOrder)
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
        /// Finishes the the delivery method selection for a new Sales Order 
        /// </summary>
        public void DeliveryMethodSelectionComplete(IDeliveryMethod model = null, TableModel table = null)
        {
            if (model == null && table == null)
                return;

            if (table != null)
                newOrderTable = table;

            if (model != null)
                newOrderDeliveryAdress = model;

            CreateNewOrder();
            InitializeSalesOrdersList();
        }

        /// <summary>
        /// Initializes the SalesPricesList
        /// </summary>
        private void InitializeSalesPricesList()
        {
            SalesPricesList = GlobalConfig.Connection.GetSalesPrices_All().Where(p => p.CurrentlyActivePrice == true).ToList();
        }

        /// <summary>
        /// Initializes the product list and ProductListListBox
        /// </summary>
        private void InitializeProductsList(int categoryId)
        {
            if (categoryId == 0)
            {
                ProductsList = GlobalConfig.Connection.GetProducts_All();

                ProductListListBox.DataSource = null;
                ProductListListBox.DisplayMember = "Name";
                ProductListListBox.DataSource = ProductsList;
            }
            else
            {
                FilterProductListByCategoryId(categoryId);
            }
        }

        /// <summary>
        /// Filter the product list by product category id
        /// </summary>
        private void FilterProductListByCategoryId(int categoryId)
        {
            ProductsList.Clear();
            List<ProductCategoryModel> productCategoryList = GlobalConfig.Connection.GetProductCategories_All().Where(pc => pc.CategoryId == categoryId).ToList();
            List<ProductModel> tempProductList = GlobalConfig.Connection.GetProducts_All();
            List<ProductModel> tempProductList2 = new List<ProductModel>();

            foreach (ProductCategoryModel productCategory in productCategoryList)
            {
                tempProductList2.Add(tempProductList.Where(p => p.Id == productCategory.ProductId).SingleOrDefault());
            }

            ProductsList = tempProductList2;
            ProductListListBox.DataSource = null;
            ProductListListBox.DisplayMember = "Name";
            ProductListListBox.DataSource = ProductsList;
        }

        /// <summary>
        /// Initializes the Product ListBox in the Sales area with products that contain the searched text in their name
        /// </summary>
        /// <param name="productName">The searched product name</param>
        private void InitializeProductListBySearchedProductName(string productName)
        {
            ProductsList = GlobalConfig.Connection.GetProducts_All().Where(p => p.Name.ToLower().Contains(productName.ToLower())).ToList();

            ProductListListBox.DataSource = null;
            ProductListListBox.DisplayMember = "Name";
            ProductListListBox.DataSource = ProductsList;
        }

        /// <summary>
        /// Initializes the Sales Orders with active status
        /// </summary>
        private void InitializeSalesOrdersList(OrderStatus orderStatus = OrderStatus.Active)
        {
            SalesOrdersList = GlobalConfig.Connection.GetSalesOrders_All().Where(c => c.Status == orderStatus).ToList();
            ActiveOrdersListBox.DataSource = null;
            ActiveOrdersListBox.DisplayMember = "Name";
            ActiveOrdersListBox.DataSource = SalesOrdersList;
        }

        /// <summary>
        /// Adds a product to the selected Sales Order
        /// </summary>
        private void AddToOrderButton_Click(object sender, EventArgs e)
        {
            productQtyToAdd = GlobalConfig.Validation.CheckAndQuantity(ProductQuantityTextBox.Text);

            SalesOrderModel selectedOrder = (SalesOrderModel)ActiveOrdersListBox.SelectedItem;
            ProductModel selectedProduct = (ProductModel)ProductListListBox.SelectedItem;
            ProductStockModel selectedProductStock = GlobalConfig.Connection.GetProductStock_Single(selectedProduct.Id);

            if (CheckProductoToSellAvailability(selectedProductStock))
            {
                if (ValidateSelectedOrderAvailability(selectedOrder) && selectedProduct != null && ValidateDefaultTax())
                    AddProductToSalesOrder(selectedOrder, selectedProduct, selectedProductStock);
            }
        }

        /// <summary>
        /// Adds the selected product to the selected sales order in the selected quantities and
        /// updates the product stock available quantity
        /// </summary>
        private void AddProductToSalesOrder(SalesOrderModel selectedOrder, ProductModel selectedProduct, ProductStockModel selectedProductStock)
        {
            OrderProductModel productToSell = CheckIfProductExistsInSalesOrder(selectedProduct, selectedOrder);

            if (productToSell == null)
                AddNewProductToSalesOrderContent(selectedOrder, selectedProduct);
            else
                IncrementExistingProductInSalesOrderContent(productToSell);

            UpdateProductStock_OnAddToSalesOrder(selectedProductStock);

            InitializeSelectedSO_ProductList(selectedOrder.Id);
            InitializeProductStockDetails_GroupBox();
            CalculateSalesOrderTotal();
        }

        /// <summary>
        /// Increment booked quantity/decrement available quantity, according to the quantity added to the sales order
        /// Update the ProductStockModel in the database
        /// </summary>
        private void UpdateProductStock_OnAddToSalesOrder(ProductStockModel selectedProductStock)
        {
            selectedProductStock.BookedQuantity += productQtyToAdd;
            selectedProductStock.AvailableQuantity -= productQtyToAdd;
            GlobalConfig.Connection.UpdateProductStockModel(selectedProductStock);
        }

        /// <summary>
        /// Increment the quantity of a product we want to sell, in the sales order content list
        /// </summary>
        private void IncrementExistingProductInSalesOrderContent(OrderProductModel productToSell)
        {
            productToSell.OrderedQuantity += productQtyToAdd;
            GlobalConfig.Connection.Update_SO_Product(productToSell);
        }

        /// <summary>
        /// Add a new product to the selected sales order content(sales order product list)
        /// </summary>
        private void AddNewProductToSalesOrderContent(SalesOrderModel selectedOrder, ProductModel selectedProduct)
        {
            OrderProductModel newProduct = new OrderProductModel
            {
                ProductId = selectedProduct.Id,
                ProductName = selectedProduct.Name,
                OrderId = selectedOrder.Id,
                OrderedQuantity = productQtyToAdd,
                TaxId = DefaultTax.Id
            };

            GlobalConfig.Connection.Create_SO_Product(newProduct);
        }

        /// <summary>
        /// Validates if the selected sales order is not null and has the status of "Active"
        /// </summary>
        private static bool ValidateSelectedOrderAvailability(SalesOrderModel _selectedOrder)
        {
            return _selectedOrder != null && _selectedOrder.Status == OrderStatus.Active;
        }

        /// <summary>
        /// Validates if the selected product is not null and has a quantity >= than the quantity we want to sell
        /// </summary>
        private bool CheckProductoToSellAvailability(ProductStockModel selectedProductStock)
        {
            return selectedProductStock != null && selectedProductStock.AvailableQuantity >= productQtyToAdd;
        }

        /// <summary>
        /// Checks if the default tax for sales orders is null or nor
        /// </summary>
        /// <returns></returns>
        private bool ValidateDefaultTax()
        {
            if (DefaultTax == null)
            {
                MessageBox.Show("Please define a default tax in the database.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the product already exists in the current sales order
        /// </summary>
        /// <param name="product">Product model / the product id we are checking for</param>
        /// <param name="order">Sales Order model / the sales order id we are checking for </param>
        /// <returns>If the product already exists -> return the Sales OrderProductModel so we can increment/decrement it
        ///                                   else -> return null so we can create/add a new product to the sales order</returns>
        private OrderProductModel CheckIfProductExistsInSalesOrder(ProductModel product, SalesOrderModel order)
        {
            OrderProductModel orderProduct = GlobalConfig.Connection.Get_SO_Products_BySO_Id(order.Id).Where(p => p.ProductId == product.Id && p.OrderId == order.Id).FirstOrDefault();
            if (orderProduct != null)
                return orderProduct;

            return null;
        }

        /// <summary>
        /// Initialise the list of taxes we can use in sales and purchase orders
        /// </summary>
        private void InitializeTaxList()
        {
            TaxList = GlobalConfig.Connection.GetTaxes_All();

            ProductTaxComboBox.DataSource = null;
            ProductTaxComboBox.DisplayMember = "Name";
            ProductTaxComboBox.DataSource = TaxList;
            ProductTaxComboBox.SelectedItem = TaxList.Where(c => c.DefaultSelectedTax == true).FirstOrDefault();
        }

        /// <summary>
        /// Initialise the comboBox  that display sales orders by their status(active/finished)
        /// </summary>
        private void InitializeOrderStatusFilter()
        {
            OrderStatusFilterComboBox.DataSource = Enum.GetNames(typeof(OrderStatus));
        }


        /// <summary>
        /// Initialises the "Product Category" list & comboBox so we can filter by "Product Category" in the "Sales" section
        /// </summary>
        private void InitializeProductCategoryList()
        {
            CategoriesList = GlobalConfig.Connection.GetCategories_All();

            ProductCategoryFilterComboBox.DataSource = null;
            ProductCategoryFilterComboBox.DisplayMember = "Name";
            ProductCategoryFilterComboBox.DataSource = CategoriesList;
            ProductCategoryFilterComboBox.SelectedItem = null;
        }

        /// <summary>
        /// Removes a product from a Sales Order
        /// It removes the selected product from the SelectedOrderItemsListBox
        /// </summary>
        private void RemoveFromOrderButton_Click(object sender, EventArgs e)
        {
            SalesOrderModel selectedOrder = (SalesOrderModel)ActiveOrdersListBox.SelectedItem;

            if (ValidateSelectedOrderAvailability(selectedOrder))
            {
                OrderProductModel selectedOrderProduct = (OrderProductModel)SelectedOrderItemsListBox.SelectedItem;

                if (selectedOrderProduct != null)
                {
                    ProductModel selectedProduct = GlobalConfig.Connection.GetProductModel_By_Id(selectedOrderProduct.ProductId);
                    ProductStockModel selectedProductStock = GlobalConfig.Connection.GetProductStock_Single(selectedOrderProduct.ProductId);

                    RemoveProductFromSalesOrder(selectedOrder, selectedProduct, selectedProductStock);
                }
            }
        }

        /// <summary>
        /// Removes the selected product from the selected sales order and updates the product stock availability
        /// </summary>
        private void RemoveProductFromSalesOrder(SalesOrderModel selectedOrder, ProductModel selectedProduct, ProductStockModel selectedProductStock)
        {
            if (selectedProductStock != null && selectedProductStock.BookedQuantity > 0)
            {
                OrderProductModel productToRemove = CheckIfProductExistsInSalesOrder(selectedProduct, selectedOrder);

                RemoveProductFromSalesOrder(selectedOrder, productToRemove);
                UnBookSalesOrderProduct(selectedProductStock);

                InitializeProductStockDetails_GroupBox();
                CalculateSalesOrderTotal();
            }
        }

        /// <summary>
        /// Decrement booked quantity/inccrement available quantity for the selected ProductStockModel item
        /// </summary>
        private static void UnBookSalesOrderProduct(ProductStockModel selectedProductStock)
        {
            selectedProductStock.BookedQuantity--;
            selectedProductStock.AvailableQuantity++;
            GlobalConfig.Connection.UpdateProductStockModel(selectedProductStock);
        }

        /// <summary>
        /// Removes a  product(a single piece) from the selected sales order
        /// </summary>
        private void RemoveProductFromSalesOrder(SalesOrderModel selectedOrder, OrderProductModel productToRemove)
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
                InitializeSelectedSO_ProductList(selectedOrder.Id);
            }
        }

        /// <summary>
        /// Delete the selected Sales Order
        /// First delete the order Products, then release the booked products
        /// Then delete the Sales Order and refresh lists
        /// </summary>
        private void DeleteOrderButton_Click(object sender, EventArgs e)
        {
            SalesOrderModel selectedOrder = (SalesOrderModel)ActiveOrdersListBox.SelectedItem;

            if (ValidateSelectedOrderAvailability(selectedOrder))
            {
                List<OrderProductModel> productsToDelete = GlobalConfig.Connection.Get_SO_Products_BySO_Id(selectedOrder.Id).Where(c => c.OrderId == selectedOrder.Id).ToList();

                UnBookProducts(productsToDelete);
                DeleteProductsFromSalesOrder(productsToDelete);
                GlobalConfig.Connection.Delete_SalesOrder(selectedOrder);
            }

            InitializeSalesOrdersList();
            InitializeSelectedSO_ProductList(0);
            InitializeProductStockDetails_GroupBox();
        }

        /// <summary>
        /// Deletes the sales order products from the productsToDelete list
        /// </summary>
        private static void DeleteProductsFromSalesOrder(List<OrderProductModel> productsToDelete)
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
        private static void UnBookProducts(List<OrderProductModel> productsToUnbook)
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
        private static bool CanUnBookProduct(OrderProductModel product, ProductStockModel selectedProductStock)
        {
            return selectedProductStock != null &&
                   selectedProductStock.BookedQuantity >= product.OrderedQuantity &&
                   selectedProductStock.Quantity >= product.OrderedQuantity;
        }

        /// <summary>
        /// Removes / frees booked products
        /// </summary>
        /// <param name="productsToRemove"> Products to be removed from the booked section abd be made available to be sold</param>
        private static void RemoveProductsFromStock(List<OrderProductModel> productsToRemove)
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
        /// Initialises the PaymentTerms list and combobox
        /// </summary>
        private void InitializePaymentTermsList()
        {
            PaymentTermsList = GlobalConfig.Connection.GetPaymentTerms_All();

            PaymentTermComboBox.DataSource = null;
            PaymentTermComboBox.DisplayMember = "PaymentTerm_Days";
            PaymentTermComboBox.DataSource = PaymentTermsList;
            PaymentTermComboBox.SelectedItem = PaymentTermsList.Where(c => c.IsDefaultPaymentTerm == true).FirstOrDefault();
        }

        /// <summary>
        /// Opens a CompanyManagementForm window to create a new company
        /// </summary>
        private void CreateNewBPButton_Click(object sender, EventArgs e)
        {
            CompanyManagementForm company = new CompanyManagementForm(this);
            company.Show();
        }

        /// <summary>
        /// Finishes the company/supplier selection process displaying the selected supplier
        /// and initializing the associated variable "selectedSupplier"
        /// </summary>
        public void CompanySelected(CompanyModel model)
        {
            selectedSupplier = model;
            BPNameTextBox.Text = model.Name;
            BPNumberTextBox.Text = model.Data;
        }

        /// <summary>
        /// Initializes the Tax list associated with the POrderTaxFilterComboBox in the Purchasing area
        /// </summary>
        private void InitializePO_TaxList()
        {
            TaxList = GlobalConfig.Connection.GetTaxes_All();

            POrderTaxFilterComboBox.DataSource = null;
            POrderTaxFilterComboBox.DisplayMember = "Name";
            POrderTaxFilterComboBox.DataSource = TaxList;
            ProductTaxComboBox.SelectedItem = TaxList.Where(c => c.DefaultSelectedTax == true).FirstOrDefault();
        }

        /// <summary>
        /// Creates a new Purchase Order
        /// </summary>
        /// <param name="poContent">The purchase order content</param>
        private void DisplayPurchaseDocumentContent(List<PurchaseOrderDetails_Join> poContent)
        {
            if (poContent == null || poContent.Count() == 0)
            {
                InitPOContentList_WithEmptyRows();
            }
            else
            {
                PurchaseOrderContentList.Clear();
                PurchaseOrderContentList = poContent;
            }

            InitializePurchasingDataGridViewWithContent();
        }

        /// <summary>
        /// Initializes the POrderContentDataGridView with purchase order/invoice content 
        /// </summary>
        private void InitializePurchasingDataGridViewWithContent()
        {
            POrderContentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            POrderContentDataGridView.DataSource = null;
            POrderContentDataGridView.AutoGenerateColumns = true;
            POrderContentDataGridView.DataSource = PurchaseOrderContentList;
        }

        /// <summary>
        /// Converts Purchase Order products(OrderProductModel) into PurchaseOrderDetails_Join to be properly displayed 
        /// in the datagrid
        /// </summary>
        /// <param name="poProductList">Purchase order product list</param>
        /// <returns>A list of PurchaseOrderDetails_Join which is a "mixed" object with the purpose of displaying
        /// product names in the purchase order/invoice datagrid</returns>
        private List<PurchaseOrderDetails_Join> TransformPOContent(List<OrderProductModel> poProductList)
        {
            List<PurchaseOrderDetails_Join> poContent = new List<PurchaseOrderDetails_Join>();

            foreach (OrderProductModel poProduct in poProductList)
            {
                poContent.Add(new PurchaseOrderDetails_Join()
                {
                    ProductId = poProduct.ProductId,
                    ProductName = poProduct.ProductName,
                    PurchasePrice = GlobalConfig.Connection.GetPurchasePrice_By_Id(poProduct.OrderId, poProduct.ProductId).PurchasePrice,
                    Quantity = poProduct.OrderedQuantity,
                    TaxId = poProduct.TaxId
                });
            }

            return poContent;
        }

        /// <summary>
        /// Deactivate/Deactivate Buttons from the purchasing section according to the Purchase Order/Invoice state
        /// </summary>
        private void DeactivateButtons_Purchasing()
        {
            if (CurrentPOState == PurchaseOrderState.NewEmptyPO_NotAdded)
                RegisterInvoiceButton.Enabled = false;

            if (CurrentPOState == PurchaseOrderState.NewPO_Added)
            {
                RegisterInvoiceButton.Enabled = true;
                AddPurchaseOrderButton.Enabled = false;
            }

            if (CurrentPOState == PurchaseOrderState.InvoicedPO)
                RegisterInvoiceButton.Enabled = false;
        }

        /// <summary>
        /// Validates the dates for the Purchase Order / future Invoice
        /// </summary>
        private bool ValidateDates()
        {
            if (DocumentPostingDateTimePicker.Value.Date != DateTime.Today.Date)
                return false;

            if (DocumentPostingDateTimePicker.Value == null ||
                        InvoiceDateTimePicker.Value == null ||
                        DocumentDueDateTimePicker.Value == null)
                return false;

            if (InvoiceDateTimePicker.Value.Date > DateTime.Today.Date)
                return false;

            return true;
        }

        /// <summary>
        /// Add a new empty row to the grid and PurchaseOrderContentList if there are no other rows available
        /// </summary>
        private void AddNewRowIfNoneAvailable()
        {
            if (CountRemainingEmptyRows() < 1)
            {
                PurchaseOrderContentList.Add(new PurchaseOrderDetails_Join());
                POrderContentDataGridView.DataSource = null;
                POrderContentDataGridView.DataSource = PurchaseOrderContentList;
                POrderContentDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Gets and returns the empty row's index, for the row that is empty and is closest from the colection's start index
        /// </summary>
        private int GetClosestEmptyRowIndex()
        {
            var purchaseRow = PurchaseOrderContentList.First(r => (r.ProductId == 0) || (r.ProductName == null || r.ProductName == ""));
            return PurchaseOrderContentList.IndexOf(purchaseRow);
        }

        /// <summary>
        /// Counts the remaining empty rows from the Purchase Order
        /// </summary>
        /// <returns>The number of remaining empty rows in the PurchaseOrderContentList and the associated datagrid</returns>
        private int CountRemainingEmptyRows()
        {
            return PurchaseOrderContentList.Count(r => (r.ProductId == 0) || (r.ProductName == null || r.ProductName == ""));
        }

        /// <summary>
        /// Retrieves a list of products matching the "product name" inserted into the cell
        /// </summary>
        /// <param name="productName">The "product name" inserted into the cell</param>
        private List<ProductModel> SearchProductByName(string productName)
        {
            return ProductsList.Where(p => p.Name.ToLower().Contains(productName.ToLower())).ToList();
        }

        /// <summary>
        /// Retrieves a product model matching the id passed as parameter
        /// </summary>
        private ProductModel RetrieveProductById(int Id)
        {
            if (Id == 0)
            {
                MessageBox.Show("Please enter a valid product ID");
                return null;
            }
            return ProductsList.Where(p => p.Id == Id).FirstOrDefault();
        }


        /// <summary>
        /// Check if there are products matching the searched product Name/Id and adds them to the selected row
        /// </summary>
        private void AddSearchedProductToRow(string productName)
        {
            int closestEmptyRowIndex = GetClosestEmptyRowIndex();

            //Check if we are on the "product name" column so we can add / search by name
            if (POrderContentDataGridView.CurrentCell.ColumnIndex == 1)
            {
                DisplayTheProductSearchResultsForm(productName);
                AddProductToPurchaseOrderContent_BySearchedName(productName, closestEmptyRowIndex);

                if (SearchProductByName(productName).Count() == 0)
                    DisplayErrorMessage_IfNoProductFound(productName);

                productToAdd = null;
            }

            //Check if we are on the "product id" column so we can add if there is a product with that id
            if (POrderContentDataGridView.CurrentCell.ColumnIndex == 0)
            {
                int idToSearch = Convert.ToInt32(POrderContentDataGridView.CurrentCell.Value);
                productToAdd = RetrieveProductById(idToSearch);

                if (productToAdd != null)
                    AddProductToPurchaseOrderContent_BySearchedId(closestEmptyRowIndex);
                else
                    DisplayErrorMessage_IfNoProductFound(POrderContentDataGridView.CurrentCell.Value.ToString());

                POrderContentDataGridView.Refresh();
                productToAdd = null;
            }
        }

        /// <summary>
        /// Adds the searched product(by id) to the closest empty row in the purchase order content list
        /// </summary>
        private void AddProductToPurchaseOrderContent_BySearchedId(int closestEmptyRowIndex)
        {
            PurchaseOrderContentList[closestEmptyRowIndex] = new PurchaseOrderDetails_Join
            {
                ProductId = productToAdd.Id,
                ProductName = productToAdd.Name,
                Quantity = 1,
                TaxId = ((TaxModel)ProductTaxComboBox.SelectedItem).Id
            };
        }

        /// <summary>
        /// Displays an error message if no product was found
        /// </summary>
        private void DisplayErrorMessage_IfNoProductFound(string productName)
        {
            MessageBox.Show($"There is no product matching \"{productName}\\");
        }

        /// <summary>
        /// Adds the searched(by name) product to the closest empty row in the purchase order content list
        /// </summary>
        private void AddProductToPurchaseOrderContent_BySearchedName(string productName, int closestEmptyRowIndex)
        {
            if (SearchProductByName(productName).Count() == 1)
            {
                productToAdd = SearchProductByName(productName).First();

                if (productToAdd != null)
                {
                    PurchaseOrderContentList[closestEmptyRowIndex] = new PurchaseOrderDetails_Join
                    {
                        ProductId = productToAdd.Id,
                        ProductName = productToAdd.Name,
                        Quantity = 1,
                        TaxId = ((TaxModel)ProductTaxComboBox.SelectedItem).Id
                    };
                }
                POrderContentDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Display the form with the results of our search by product name
        /// </summary>
        private void DisplayTheProductSearchResultsForm(string productName)
        {
            if (SearchProductByName(productName).Count() > 1)
            {
                SelectProductForm form = new SelectProductForm(this, productName);
                form.Show();
            }
        }

        /// <summary>
        /// Initializes the datagridview with enpty rows
        /// </summary>
        private void InitPOContentList_WithEmptyRows()
        {
            PurchaseOrderContentList = new List<PurchaseOrderDetails_Join>
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
        /// Selects(in the case there are more than 1 products matching the searched name) a product and adds it to the order/datagridview rows
        /// </summary>
        public void ProductSelectionComplete(ProductModel product = null)
        {
            int index = GetClosestEmptyRowIndex();
            productToAdd = product;

            if (productToAdd != null)
            {
                PurchaseOrderContentList[index] = new PurchaseOrderDetails_Join
                {
                    ProductId = productToAdd.Id,
                    ProductName = productToAdd.Name,
                    Quantity = 1,
                    TaxId = ((TaxModel)ProductTaxComboBox.SelectedItem).Id
                };

                AddNewRowIfNoneAvailable();
            }
            POrderContentDataGridView.Refresh();
        }

        /// <summary>
        /// On cell value changed event, check if the value entered by the user matches a product by name or id
        /// if there's a match, add the product to the row.
        /// </summary>
        private void POrderContentDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (POrderContentDataGridView.CurrentCell.Value != null)
                AddSearchedProductToRow(POrderContentDataGridView.CurrentCell.Value.ToString());

            AddNewRowIfNoneAvailable();
            POrderContentDataGridView.Refresh();
            CalculatePurchaseOrderTotal();
        }


        /// <summary>
        /// Shows an error message of the user enters a wrong data type in certain columns cells
        /// </summary>
        private void POrderContentDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string message = "";
            switch (POrderContentDataGridView.CurrentCell.ColumnIndex)
            {
                case 0:
                    message = "Data entered must be of Integer type";
                    break;
                case 1:
                    break;
                case 2:
                    message = "Data entered must be of Integer type";
                    break;
                case 3:
                    message = "Data entered must be of Decimal type";
                    break;
                case 4:
                    message = "Data entered must be of Integer type";
                    break;
                default:
                    break;
            }

            if (message != "")
                MessageBox.Show(message);
        }

        /// <summary>
        /// Adds a new Purchase Order and its content to the database
        /// </summary>
        private void AddPurchaseOrderButton_Click(object sender, EventArgs e)
        {
            PaymentTermsModel selectedPT = (PaymentTermsModel)PaymentTermComboBox.SelectedItem;

            if (selectedSupplier != null && ValidateDates() && selectedPT != null)
            {
                CurrentPOState = PurchaseOrderState.NewPO_Added;
                DeactivateButtons_Purchasing();

                PurchaseOrderModel purchaseOrder = AddPurchaseOrderToDatabase();

                int orderId = purchaseOrder.Id;
                OrderNumberTextBox.Text = orderId.ToString();

                AddPurchaseProductAndPrice(orderId);

                SelectedPurchaseOrder = purchaseOrder;
                ClearPurchaseOrderFormFields();
            }

        }

        /// <summary>
        /// Add Purchase Order products and their prices to the database
        /// </summary>
        private void AddPurchaseProductAndPrice(int orderId)
        {
            foreach (var row in PurchaseOrderContentList)
            {
                if (row.ProductId != 0 &&
                    row.ProductName != "" &&
                    row.Quantity != 0)
                {
                    CreatePurchaseOrderProuct(orderId, row);
                    CreatePurchaseOrderPrice(orderId, row);
                }
            }
        }

        /// <summary>
        /// Create a new purchase order and adds it to the database
        /// </summary>
        private PurchaseOrderModel AddPurchaseOrderToDatabase()
        {
            PurchaseOrderModel purchaseOrder = new PurchaseOrderModel
            {
                Status = OrderStatus.Active,
                SupplierId = selectedSupplier.Id,
                SupplierName = selectedSupplier.Name,
                PostingDate = DocumentPostingDateTimePicker.Value,
                DueDate = GetDueDate(),
                DocumentDate = DocumentDueDateTimePicker.Value
            };

            GlobalConfig.Connection.CreatePurchaseOrder(purchaseOrder);
            return purchaseOrder;
        }

        /// <summary>
        /// Creates a purchase price for the product on the "row" recieved as a parameter
        /// </summary>
        private void CreatePurchaseOrderPrice(int orderId, PurchaseOrderDetails_Join row)
        {
            PurchasePriceModel purchasePrice = new PurchasePriceModel()
            {
                ProductId = row.ProductId,
                PurchasePrice = row.PurchasePrice + row.PurchasePrice * ((TaxModel)POrderTaxFilterComboBox.SelectedItem).Percent / 100,
                PurchaseDate = DocumentPostingDateTimePicker.Value.Date,
                PurchaseOrderId = orderId
            };

            GlobalConfig.Connection.CreatePurchasePrice(purchasePrice);
        }
        /// <summary>
        /// Creates a purchase OrderProductModel and adds it to the database
        /// </summary>
        private static void CreatePurchaseOrderProuct(int orderId, PurchaseOrderDetails_Join row)
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
        private void AddProductToStock(ProductStockModel product)
        {
            ProductStockModel existingProductStock = GlobalConfig.Connection.GetProductStock_Single(product.Id);
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
        private DateTime GetDueDate()
        {
            return (DocumentDueDateTimePicker.Value.Date.AddDays(((PaymentTermsModel)PaymentTermComboBox.SelectedItem).PaymentTerm_Days));
        }

        /// <summary>
        /// Updates the due date according to the document/invoice date
        /// </summary>
        private void UpdateDueDate()
        {
            DocumentDueDateTimePicker.Value = DocumentDueDateTimePicker.Value.Date.AddDays(((PaymentTermsModel)PaymentTermComboBox.SelectedItem).PaymentTerm_Days);
        }

        /// <summary>
        /// Calculates the Purchase Order total Value
        /// </summary>
        private void CalculatePurchaseOrderTotal()
        {
            TaxModel taxToUse = (TaxModel)POrderTaxFilterComboBox.SelectedItem;
            decimal poTotal = 0;
            decimal poTax = 0;
            decimal poGrandTotal = 0;

            for (int i = 0; i < PurchaseOrderContentList.Count; i++)
            {
                if (ValidatePurchaseOrderTotalCalculations(taxToUse, i))
                {
                    poTotal += PurchaseOrderContentList[i].Quantity * PurchaseOrderContentList[i].PurchasePrice;
                    poTax += PurchaseOrderContentList[i].Quantity * (PurchaseOrderContentList[i].PurchasePrice / 100 * (taxToUse.Percent));
                    poGrandTotal = poTotal + poTax;
                }
            }

            DisplayPurchaseDocumentTotals(poTotal, poTax, poGrandTotal);
        }

        /// <summary>
        /// Display in the UI the purchase order/invoice totals
        /// </summary>
        private void DisplayPurchaseDocumentTotals(decimal poTotal, decimal poTax, decimal poGrandTotal)
        {
            POrderTotalTextBox.Text = poTotal.ToString("0.##");
            POrderTaxTotalTextBox.Text = poTax.ToString("0.##");
            POrderGrandTotalTextBox.Text = poGrandTotal.ToString("0.##");

            POrderTotalTextBox.ReadOnly = true;
            POrderTaxTotalTextBox.ReadOnly = true;
            POrderGrandTotalTextBox.ReadOnly = true;
        }

        /// <summary>
        /// Validates if conditions are met to calculate the purchase order totals
        /// </summary>
        private bool ValidatePurchaseOrderTotalCalculations(TaxModel taxToUse, int index)
        {
            return (PurchaseOrderContentList[index].ProductId != 0 &&
                                PurchaseOrderContentList[index].PurchasePrice != 0 &&
                                !(PurchaseOrderContentList[index].PurchasePrice < 0) &&
                                PurchaseOrderContentList[index].Quantity > 0) &&
                                taxToUse != null ||
                                (PurchaseOrderContentList[index].ProductName != null || PurchaseOrderContentList[index].ProductName != "");
        }

        /// <summary>
        /// Calculates the Sales Order total value
        /// </summary>
        private void CalculateSalesOrderTotal()
        {
            TaxModel taxToUse = (TaxModel)ProductTaxComboBox.SelectedItem;
            decimal soTotal = 0;
            decimal soTax = 0;
            decimal soGrandTotal = 0;

            for (int i = 0; i < SalesOrderContentList.Count; i++)
            {
                soGrandTotal = CalculateSalesOrderRowTotals(taxToUse, ref soTotal, ref soTax, i);
            }

            DisplaySalesOrderTotals(soTotal, soTax, soGrandTotal);
        }

        /// <summary>
        /// Displays the sales order totals in the UI
        /// </summary>
        private void DisplaySalesOrderTotals(decimal soTotal, decimal soTax, decimal soGrandTotal)
        {
            TotalAmountSOTextBox.Text = soTotal.ToString("0.## Lei");
            TaxTotalAmountSOTextBox.Text = soTax.ToString("0.## Lei");
            GrandTotalAmountSOTextBox.Text = soGrandTotal.ToString("0.## Lei");
        }

        /// <summary>
        /// Calculates the sales order totals for the current row and retrieves the grand total
        /// </summary>
        private decimal CalculateSalesOrderRowTotals(TaxModel taxToUse, ref decimal soTotal, ref decimal soTax, int rowIndex)
        {
            decimal soGrandTotal;
            if (SalesPricesList == null && SalesPricesList.Count < 1)
                InitializeSalesPricesList();

            decimal productPrice = SalesPricesList.Where(p => p.ProductId == SalesOrderContentList[rowIndex].ProductId && p.CurrentlyActivePrice == true)
                                              .Single().SalesPrice;

            soTotal += SalesOrderContentList[rowIndex].OrderedQuantity * productPrice;
            soTax += SalesOrderContentList[rowIndex].OrderedQuantity * (productPrice / 100 * (taxToUse.Percent));
            soGrandTotal = soTotal + soTax;
            return soGrandTotal;
        }

        /// <summary>
        /// Updates the payment term list after a new payment term was created/updated
        /// </summary>
        public void PaymentTermComplete()
        {
            InitializePaymentTermsList();
        }

        /// <summary>
        /// Opens a PaymentTermsForm window to create a new payment term/ update an existing one
        /// </summary>
        private void CreateNewPaymentTermLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PaymentTermsForm paymentTerms = new PaymentTermsForm(this);
            paymentTerms.Show();
        }

        /// <summary>
        /// Updates the Due Date for a Purchase Order/Invoice
        /// </summary>
        private void InvoiceDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateDueDate();
        }

        /// <summary>
        /// When we go to the "Purchasing" Tab if there is an "unsaved" order, we clear all the fields and deactivate buttons
        /// so only the creation of a new order is available
        /// </summary>
        private void RMSTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RMSTabControl.SelectedTab.Text == "PURCHASING")
            {
                if (CurrentPOState == PurchaseOrderState.NewEmptyPO_NotAdded && PurchaseOrderContentList == null)
                {
                    DisplayPurchaseDocumentContent(null);
                    DeactivateButtons_Purchasing();
                }
            }
        }

        /// <summary>
        /// Calls a method to clear the purchasing fields
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearPurchaseOrderFormFields();
        }


        /// <summary>
        /// Clears the purchasing fields and calls a method to create a new Purchase Order
        /// </summary>
        private void ClearPurchaseOrderFormFields()
        {
            //Clear Supplier
            selectedSupplier = null;
            BPNameTextBox.Text = "";
            BPNumberTextBox.Text = "";

            //Clear PO Totals
            POrderTotalTextBox.Text = "0";
            POrderTaxTotalTextBox.Text = "0";
            POrderGrandTotalTextBox.Text = "0";

            //Reset PO Dates 
            DocumentPostingDateTimePicker.Value = DateTime.Today.Date;
            InvoiceDateTimePicker.Value = DateTime.Today.Date;

            //Clear PO Id
            OrderNumberTextBox.Text = "";

            //Clear PO Rows
            DisplayPurchaseDocumentContent(null);

            //Reset Buttons/PO Form State
            CurrentPOState = PurchaseOrderState.NewEmptyPO_NotAdded;
            DeactivateButtons_Purchasing();
        }

        /// <summary>
        /// Opens a new SearchPurchaseDocumentForm window to  search for the selected document type
        /// </summary>
        private void SearchDocumentButton_Click(object sender, EventArgs e)
        {
            RequestedPurchasingDocument requestedPurchasingDocument;
            SearchPurchaseDocumentForm document;

            if (POrdersCheckBox.Checked && !PInvoicesCheckBox.Checked)
            {
                requestedPurchasingDocument = RequestedPurchasingDocument.PurchaseOrder;
                document = new SearchPurchaseDocumentForm(this, requestedPurchasingDocument);
                document.Show();
            }

            if (PInvoicesCheckBox.Checked && !POrdersCheckBox.Checked)
            {
                requestedPurchasingDocument = RequestedPurchasingDocument.PurchaseInvoice;
                document = new SearchPurchaseDocumentForm(this, requestedPurchasingDocument);
                document.Show();
            }
        }

        /// <summary>
        /// Finishes the purchase document selection process by calling the methods that display the selected Purchase Order/Invoice
        /// </summary>
        public void DocumentSelected(RequestedPurchasingDocument _documentType, PurchaseOrderModel po_model = null, PurchaseInvoiceModel inv_model = null)
        {
            if (_documentType == RequestedPurchasingDocument.PurchaseOrder)
            {
                DisplaySearchedPurchaseOrder(po_model);

                if (po_model.Status == OrderStatus.Active)
                    DisplaySettingsForActivePurchaseOrders(po_model);
            }

            if (_documentType == RequestedPurchasingDocument.PurchaseInvoice)
            {
                DisplaySearchedPurchaseInvoice(inv_model);
                CurrentPOState = PurchaseOrderState.InvoicedPO;
                DeactivateButtons_Purchasing();
            }

            ChangePurchasingDocument_UI_Elements(_documentType);
        }

        /// <summary>
        /// Sets the current order status, deactivates UI buttons according to document type
        /// and initialises the SelectedPurchaseOrder
        /// </summary>
        private void DisplaySettingsForActivePurchaseOrders(PurchaseOrderModel po_model)
        {
                CurrentPOState = PurchaseOrderState.NewPO_Added;
                DeactivateButtons_Purchasing();
                SelectedPurchaseOrder = po_model;
        }

        /// <summary>
        /// Displays the searched Purchase Order
        /// </summary>
        private void DisplaySearchedPurchaseOrder(PurchaseOrderModel model)
        {
            DisplayCompanyDetails(model);
            OrderNumberTextBox.Text = model.Id.ToString();
            DisplayPurchaseDocumentDates(model);

            List<OrderProductModel> poProductList = GlobalConfig.Connection.GetPurchaseOrderProductList_ByPO_Id(model.Id);
            DisplayPurchaseDocumentContent(TransformPOContent(poProductList));
            CalculatePurchaseOrderTotal();
        }

        /// <summary>
        /// Displays the purchase document dates in the UI
        /// </summary>
        private void DisplayPurchaseDocumentDates(PurchaseOrderModel model)
        {
            DocumentPostingDateTimePicker.Value = model.PostingDate;
            DocumentDueDateTimePicker.Value = model.DueDate;
            InvoiceDateTimePicker.Value = model.DocumentDate;
        }

        /// <summary>
        /// Displays the company details in the UI/Purchasing section
        /// </summary>
        private void DisplayCompanyDetails(PurchaseOrderModel model)
        {
            CompanyModel company = GlobalConfig.Connection.GetCompany_Single(model.SupplierId);
            CompanySelected(company);
        }

        /// <summary>
        /// Displays the searched Purchase Invoice
        /// </summary>
        private void DisplaySearchedPurchaseInvoice(PurchaseInvoiceModel model)
        {
            DisplayCompanyDetails(model);
            OrderNumberTextBox.Text = model.Id.ToString();
            DisplayPurchaseDocumentDates(model);

            List<OrderProductModel> invoiceProductList = GlobalConfig.Connection.GetPurchaseOrderProductList_ByPO_Id(model.RelatedPurchaseOrderId);
            DisplayPurchaseDocumentContent(TransformPOContent(invoiceProductList));
            CalculatePurchaseOrderTotal();
        }

        /// <summary>
        /// Register a purchase invoice, closes an active purchase order and adds the products in stock
        /// </summary>
        private void RegisterInvoiceButton_Click(object sender, EventArgs e)
        {
            decimal poGrandTotal = (POrderGrandTotalTextBox.Text == "" || POrderGrandTotalTextBox.Text == null) ? 0 : decimal.Parse(POrderGrandTotalTextBox.Text);

            if (SelectedPurchaseOrder != null && poGrandTotal > 0 && PurchaseOrderNotInvoiced(SelectedPurchaseOrder))
            {
                CreateInvoice();
                ClosePurchaseOrder();
                AddInvoicedProductsToStock();
                ClearPurchaseOrderFormFields(); ;
            }
        }

        /// <summary>
        /// Add the product quantities on the purchase invoice in stock making them available to be sold
        /// </summary>
        private void AddInvoicedProductsToStock()
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
        /// Closes the purchase order for editing by changing its status to "Finished"
        /// </summary>
        private void ClosePurchaseOrder()
        {
            SelectedPurchaseOrder.Status = OrderStatus.Finished;
            GlobalConfig.Connection.UpdatePurchaseOrderModel(SelectedPurchaseOrder);
        }

        /// <summary>
        /// Creates a new invoice and adds it to the database
        /// </summary>
        private void CreateInvoice()
        {
            PurchaseInvoiceModel invoice = new PurchaseInvoiceModel
            {
                RelatedPurchaseOrderId = SelectedPurchaseOrder.Id,
                Status = OrderStatus.Finished,
                SupplierId = SelectedPurchaseOrder.SupplierId,
                SupplierName = SelectedPurchaseOrder.SupplierName,
                DocumentDate = SelectedPurchaseOrder.DocumentDate,
                DueDate = SelectedPurchaseOrder.DueDate,
                PostingDate = SelectedPurchaseOrder.PostingDate,
            };

            GlobalConfig.Connection.CreatePurchaseInvoice(invoice);
        }

        /// <summary>
        /// Checks if a purchase order was invoiced
        /// </summary>
        /// <param name="po">Purchase order model</param>
        /// <returns>true - was not invoiced/ false - was invoiced</returns>
        private bool PurchaseOrderNotInvoiced(PurchaseOrderModel po)
        {
            return GlobalConfig.Connection.GetPurchaseInvoices_All().Where(p => p.RelatedPurchaseOrderId == po.Id).Count() == 0;
        }

        /// <summary>
        /// Changes field names according to the selected purchasing document type(Order/Invoice)
        /// </summary>
        private void ChangePurchasingDocument_UI_Elements(RequestedPurchasingDocument docType)
        {
            if (POrdersCheckBox.Checked && !PInvoicesCheckBox.Checked && docType == RequestedPurchasingDocument.PurchaseOrder)
            {
                PurchaseOrderLabel.Text = "Purchase Order";
                OrderDetailsGroupBox.Text = "Order Details";
                OrderNumberLabel.Text = "Order Id";
                OrderTotalGroupBox.Text = "Order Total";
            }

            if (PInvoicesCheckBox.Checked && !POrdersCheckBox.Checked && docType == RequestedPurchasingDocument.PurchaseInvoice)
            {
                PurchaseOrderLabel.Text = "Purchase Invoice";
                OrderDetailsGroupBox.Text = "Invoice Details";
                OrderNumberLabel.Text = "Invoice Id";
                OrderTotalGroupBox.Text = "Invoice Total";
            }
        }

        /// <summary>
        /// Calls the method that displays the selected Sales Order's product list 
        /// By default handles the sales orders with "Active" status
        /// </summary>
        private void ActiveOrdersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SalesOrderModel selectedSO = (SalesOrderModel)ActiveOrdersListBox.SelectedItem;
            if (selectedSO != null)
            {
                InitializeSelectedSO_ProductList(selectedSO.Id);
            }
        }

        /// <summary>
        /// Initializes the selected Sales Order's product list by the Sales Order's Id
        /// And calls the function that calculates the sales order's total value
        /// </summary>
        private void InitializeSelectedSO_ProductList(int salesOrderId = 0)
        {
            if (SalesOrderContentList != null)
                SalesOrderContentList.Clear();

            if (salesOrderId != 0)
            {
                SalesOrderContentList = GlobalConfig.Connection.Get_SO_Products_BySO_Id(salesOrderId);

                SelectedOrderItemsListBox.DataSource = null;
                SelectedOrderItemsListBox.DisplayMember = "ProductName";
                SelectedOrderItemsListBox.DataSource = SalesOrderContentList;
            }
            else
            {
                SelectedOrderItemsListBox.DataSource = null;
                SelectedOrderItemsListBox.DisplayMember = "ProductName";
                SelectedOrderItemsListBox.DataSource = SalesOrderContentList;
            }
            CalculateSalesOrderTotal();
        }

        /// <summary>
        /// Displays price and stock info when the selected product changes
        /// </summary>
        private void ProductListListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeProductStockDetails_GroupBox();
            InitializeSelectedProductPriceDetails();
        }

        /// <summary>
        /// Initializes fields in the "Product Stock Details" groupBox asociated with the selected product
        /// </summary>
        private void InitializeProductStockDetails_GroupBox()
        {
            ProductModel selectedProduct = (ProductModel)ProductListListBox.SelectedItem;

            if (selectedProduct != null)
            {
                ProductStockModel selectedProductStock = GlobalConfig.Connection.GetProductStock_Single(selectedProduct.Id);

                if (selectedProductStock != null)
                {
                    ProductTotalStockQuantityLabel.Text = selectedProductStock.Quantity == 0 ? "0" : selectedProductStock.Quantity.ToString();
                    ProductBookedQuantityLabel.Text = selectedProductStock.BookedQuantity == 0 ? "0" : selectedProductStock.BookedQuantity.ToString();
                    ProductAvailableQuantityLabel.Text = (selectedProductStock.Quantity - selectedProductStock.BookedQuantity).ToString();
                }
                else
                {
                    ProductTotalStockQuantityLabel.Text = "0";
                    ProductBookedQuantityLabel.Text = "0";
                    ProductAvailableQuantityLabel.Text = "0";
                }
            }
        }

        /// <summary>
        /// Initializes the price field/textbox asociated with the selected product
        /// </summary>
        private void InitializeSelectedProductPriceDetails()
        {
            ProductModel selectedProduct = (ProductModel)ProductListListBox.SelectedItem;

            if (selectedProduct != null)
            {
                SalesPriceModel selectedProductSalesPrice = GlobalConfig.Connection.GetProduct_SalesPrice_ByProductId(selectedProduct.Id)
                                                                                        .Where(p => p.CurrentlyActivePrice == true).SingleOrDefault();

                if (selectedProductSalesPrice != null)
                    DisplayCurrentlyActivePrice(true, selectedProductSalesPrice.SalesPrice.ToString());
                else
                    DisplayCurrentlyActivePrice(false, "-");
            }
        }

        /// <summary>
        /// Displays the current active sale price for the selected product in the UI
        /// </summary>
        private void DisplayCurrentlyActivePrice(bool currentActivePriceExists, string productSalesPriceTextBoxMessage)
        {
            ProductSalesPriceTextBox.Text = productSalesPriceTextBoxMessage;
            AddProductToSalesOrderToggle(currentActivePriceExists);
            noActivePriceLabel.Visible = currentActivePriceExists ? false : true;
        }

        /// <summary>
        /// Toggles enabled/disabled the "AddToOrderButton" button
        /// </summary>
        private void AddProductToSalesOrderToggle(bool canAdd)
        {
            AddToOrderButton.Enabled = canAdd;
        }

        /// <summary>
        /// Displays the product quantity left to its name in the SelectedOrderItemsListBox
        /// </summary>
        private void SelectedOrderItemsListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            OrderProductModel soProduct = ((OrderProductModel)e.ListItem);

            e.Value = $"({soProduct.OrderedQuantity}) {soProduct.ProductName}";
        }

        /// <summary>
        /// Opens a FinishSalesOrderPreviewForm window that allows us to preview and finish a sales order
        /// </summary>
        private void FinishOrderButton_Click(object sender, EventArgs e)
        {
            SalesOrderModel selectedOrder = (SalesOrderModel)ActiveOrdersListBox.SelectedItem;
            TaxModel taxToUse = (TaxModel)ProductTaxComboBox.SelectedItem;
            if (selectedOrder.Status != OrderStatus.Finished)
            {
                FinishSalesOrderPreviewForm finishForm = new FinishSalesOrderPreviewForm(this, selectedOrder, SalesOrderContentList, taxToUse);
                finishForm.Show();
            }
        }

        /// <summary>
        /// Filters the product list when the selected filter from the ProductCategoryFilterComboBox changes
        /// </summary>
        private void ProductCategoryFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryModel selectedCategory = (CategoryModel)ProductCategoryFilterComboBox.SelectedItem;

            if (selectedCategory == null)
                InitializeProductsList(0);
            else
                InitializeProductsList(selectedCategory.Id);
        }

        /// <summary>
        /// Clears product filtering by product category
        /// </summary>
        private void ClearProductCategFilterButton_Click(object sender, EventArgs e)
        {
            InitializeProductsList(0);
            ProductCategoryFilterComboBox.SelectedItem = null;
        }

        /// <summary>
        /// Handles data validation for the product quantity textbox in the Sales area
        /// </summary>
        private void ProductQuantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!GlobalConfig.Validation.ValidateQuantity(ProductQuantityTextBox.Text, e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// Searches a product by text or resets the search according to what icon/search state the button has on
        /// </summary>
        private void SearchProductButton_Click(object sender, EventArgs e)
        {
            if (SO_ProductSearchBoxIsActive)
            {
                CancelSearch();
            }
            else
            {
                if (SearchProductTextBox.Text.Length > 0)
                    SearchProduct();
            }
        }

        /// <summary>
        /// Searches for a product with a name matching the SearchProductTextBox content
        /// </summary>
        private void SearchProduct()
        {
            InitializeProductListBySearchedProductName(SearchProductTextBox.Text);
            SO_ProductSearchBoxIsActive = true;
            ChangeSearchedProductBtnIcon(SO_ProductSearchBoxIsActive);
        }

        /// <summary>
        /// Remove product search results and makes the list searchable again
        /// </summary>
        private void CancelSearch()
        {
            SO_ProductSearchBoxIsActive = false;
            ChangeSearchedProductBtnIcon(SO_ProductSearchBoxIsActive);
            InitializeProductsList(0);
            SearchProductTextBox.Text = "";
        }

        /// <summary>
        /// Toggles the search state and changes the  image for the search button 
        /// </summary>
        private void ChangeSearchedProductBtnIcon(bool searchIsActive)
        {
            if (searchIsActive)
                SearchProductButton.BackgroundImage = Properties.Resources.cancel;
            else
                SearchProductButton.BackgroundImage = Properties.Resources.search;
        }

        /// <summary>
        /// Opens a new SalesPriceManagementForm window where we can create/update a sales price for a product(or more)
        /// </summary>
        private void EditSalesPriceLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductListListBox.SelectedItem;
            if (selectedProduct != null)
            {
                SalesPriceManagementForm prices = new SalesPriceManagementForm(this, selectedProduct);
                prices.Show();
            }
        }

        /// <summary>
        /// Updates a product price and refreshes the sales price list
        /// </summary>
        public void SalesPriceUpdateComplete(ProductModel model)
        {
            if (model != null)
                ProductListListBox.SelectedItem = model;

            InitializeSelectedProductPriceDetails();
            InitializeSalesPricesList();
        }

        /// <summary>
        /// Change a Sales Order's status to Finished and unbooks/removes from stock the Saes Order's content
        /// </summary>
        public void SalesOrderComplete(SalesOrderModel model)
        {
            if (model != null)
            {
                model.Status = OrderStatus.Finished;
                GlobalConfig.Connection.UpdateSalesOrderModel(model);

                if (SalesOrderContentList != null && SalesOrderContentList.Count > 0)
                {
                    RemoveProductQuantitiesFromStock(model);
                }
            }
            InitializeSalesOrdersList();
            InitializeSelectedSO_ProductList();
        }

        /// <summary>
        /// Removes product quantities booked on the current sales order and afterwards removes the quantities from stock
        /// </summary>
        /// <param name="model"></param>
        private void RemoveProductQuantitiesFromStock(SalesOrderModel model)
        {
            if (SalesOrderContentList[0].OrderId == model.Id)
            {
                UnBookProducts(SalesOrderContentList);
                RemoveProductsFromStock(SalesOrderContentList);
            }
            else
            {
                InitializeSelectedSO_ProductList(model.Id);
                UnBookProducts(SalesOrderContentList);
                RemoveProductsFromStock(SalesOrderContentList);
            }
        }

        /// <summary>
        /// Filter the Sales Order listbox by the Sales Order status(active/finished)
        /// </summary>
        private void OrderStatusFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderStatus selectedSO_Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), OrderStatusFilterComboBox.SelectedValue.ToString());
            InitializeSalesOrdersList(selectedSO_Status);
        }
    }
}