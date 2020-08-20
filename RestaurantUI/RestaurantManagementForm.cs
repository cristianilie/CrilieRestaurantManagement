using RMLibrary;
using RMLibrary.Models;
using RMLibrary.Models.Helpers;
using RMLibrary.RMS_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class RestaurantManagementForm : Form, IDeliveryMethodRequester, ICompanyRequester, IProductRequester, IPaymentTermRequester, IDocumentRequester, ISalesPriceUpdater, ISalesOrderPreviewer, IProductRecipeRequester
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

        public OrderTotal SalesOrderTotal { get; set; }
        public OrderTotal PurchaseOrderTotal { get; set; }


        //Default Constructor
        public RestaurantManagementForm()
        {
            InitializeComponent();
            SalesPricesList = RMS_Logic.SalesLogic.InitializeSalesPricesList();
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

        #region SALES

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

            RMS_Logic.SalesLogic.CreateNewOrder(newOrderTable, newOrderDeliveryAdress);
            InitializeSalesOrdersList();
            newOrderDeliveryAdress = null;
            newOrderTable = null;
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

            if (RMS_Logic.SalesLogic.CheckProductToSellAvailability(selectedProductStock, productQtyToAdd))
            {
                if (ValidateSelectedOrderAvailability(selectedOrder) && selectedProduct != null && ValidateDefaultTax())
                {
                    RMS_Logic.SalesLogic.AddProductToSalesOrder(selectedOrder, selectedProduct, selectedProductStock, DefaultTax, productQtyToAdd);
                    UpdateSalesProductsDetails(selectedOrder);
                }
            }
        }

        /// <summary>
        /// Updates sales order content, product stock details and sales order totals
        /// </summary>
        /// <param name="selectedOrder"></param>
        private void UpdateSalesProductsDetails(SalesOrderModel selectedOrder)
        {
            InitializeSelectedSO_ProductList(selectedOrder.Id);
            InitializeProductStockDetails_GroupBox();
            SalesOrderTotal = RMS_Logic.SalesLogic.CalculateSalesOrderTotal((TaxModel)ProductTaxComboBox.SelectedItem, SalesOrderContentList);
            DisplaySalesOrderTotals(SalesOrderTotal);
        }

        /// <summary>
        /// Validates if the selected sales order is not null and has the status of "Active"
        /// </summary>
        private static bool ValidateSelectedOrderAvailability(SalesOrderModel _selectedOrder)
        {
            return _selectedOrder != null && _selectedOrder.Status == OrderStatus.Active;
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

                    RemoveFromSalesOrder(selectedOrder, selectedProduct, selectedProductStock);
                }
            }
        }

        /// <summary>
        /// Removes the selected product from the selected sales order and updates the product stock availability
        /// </summary>
        private void RemoveFromSalesOrder(SalesOrderModel selectedOrder, ProductModel selectedProduct, ProductStockModel selectedProductStock)
        {
            if (selectedProductStock != null && selectedProductStock.BookedQuantity > 0)
            {
                OrderProductModel productToRemove = RMS_Logic.SalesLogic.CheckIfProductExistsInSalesOrder(selectedProduct, selectedOrder);

                RMS_Logic.SalesLogic.RemoveProductFromSalesOrder(productToRemove);
                InitializeSelectedSO_ProductList(selectedOrder.Id);
                RMS_Logic.SalesLogic.UnBookSalesOrderProduct(selectedProductStock);

                InitializeProductStockDetails_GroupBox();
                SalesOrderTotal = RMS_Logic.SalesLogic.CalculateSalesOrderTotal((TaxModel)ProductTaxComboBox.SelectedItem, SalesOrderContentList);
                DisplaySalesOrderTotals(SalesOrderTotal);

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

                RMS_Logic.SalesLogic.UnBookProducts(productsToDelete);
                RMS_Logic.SalesLogic.DeleteProductsFromSalesOrder(productsToDelete);
                GlobalConfig.Connection.Delete_SalesOrder(selectedOrder);
            }

            InitializeSalesOrdersList();
            InitializeSelectedSO_ProductList(0);
            InitializeProductStockDetails_GroupBox();
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
            if (selectedOrder != null)
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
            SalesPricesList = RMS_Logic.SalesLogic.InitializeSalesPricesList();
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
                RMS_Logic.SalesLogic.UnBookProducts(SalesOrderContentList);
                RMS_Logic.SalesLogic.RemoveProductsFromStock(SalesOrderContentList);
            }
            else
            {
                InitializeSelectedSO_ProductList(model.Id);
                RMS_Logic.SalesLogic.UnBookProducts(SalesOrderContentList);
                RMS_Logic.SalesLogic.RemoveProductsFromStock(SalesOrderContentList);
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
            SalesOrderTotal = RMS_Logic.SalesLogic.CalculateSalesOrderTotal((TaxModel)ProductTaxComboBox.SelectedItem, SalesOrderContentList);
            DisplaySalesOrderTotals(SalesOrderTotal);

        }

        /// <summary>
        /// Displays price and stock info when the selected product changes
        /// </summary>
        private void ProductListListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeProductStockDetails_GroupBox();
            InitializeSelectedProductPriceDetails();

            ProductModel selectedProduct = (ProductModel)ProductListListBox.SelectedItem;

            if (selectedProduct != null && selectedProduct.RecipeId != null)
                CreateProductFromRecipeButton.Enabled = true;
            else
                CreateProductFromRecipeButton.Enabled = false;
        }

        /// <summary>
        /// Filter the Sales Order listbox by the Sales Order status(active/finished)
        /// </summary>
        private void OrderStatusFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderStatus selectedSO_Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), OrderStatusFilterComboBox.SelectedValue.ToString());
            InitializeSalesOrdersList(selectedSO_Status);

            if (selectedSO_Status == OrderStatus.Active)
                FinishOrderButton.Text = "Finish Order";
            else
                FinishOrderButton.Text = "Preview Order";
        }

        /// <summary>
        /// Displays the sales order totals in the UI
        /// </summary>
        private void DisplaySalesOrderTotals(OrderTotal salesOrderTotal)
        {
            TotalAmountSOTextBox.Text = salesOrderTotal.Total.ToString("0.## Lei");
            TaxTotalAmountSOTextBox.Text = salesOrderTotal.TaxTotal.ToString("0.## Lei");
            GrandTotalAmountSOTextBox.Text = salesOrderTotal.GrandTotal.ToString("0.## Lei");
        }

        /// <summary>
        /// Updates the sales order totals, calculated at the new selected tax
        /// </summary>
        private void ProductTaxComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((SalesOrderModel)ActiveOrdersListBox.SelectedItem != null)
            {
                SalesOrderTotal = RMS_Logic.SalesLogic.CalculateSalesOrderTotal((TaxModel)ProductTaxComboBox.SelectedItem, SalesOrderContentList);
                DisplaySalesOrderTotals(SalesOrderTotal);
            }
        }

        /// <summary>
        /// Finishes the stock quantities creation process for products made by recipes
        /// </summary>
        public void ProductCreationComplete()
        {
            InitializeProductsList(0);
        }

        /// <summary>
        /// Opens the ProductStockFromRecipeIngredientsForm to create stock for a product made by a recipe(if the recipe ingredients are in stock)
        /// </summary>
        private void CreateProductFromRecipeButton_Click(object sender, EventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductListListBox.SelectedItem;

            ProductStockFromRecipeIngredientsForm form = new ProductStockFromRecipeIngredientsForm(this, selectedProduct);
            form.Show();
        }
        #endregion


        #region PURCHASING

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
        /// Opens a CompanyManagementForm window to create a new company / BP = Business Partner
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
        /// Initializes the Tax list associated with the Purchase Order Tax Filter ComboBox in the Purchasing area
        /// </summary>
        private void InitializePO_TaxList()
        {
            TaxList = GlobalConfig.Connection.GetTaxes_All();

            POrderTaxFilterComboBox.DataSource = null;
            POrderTaxFilterComboBox.DisplayMember = "Name";
            POrderTaxFilterComboBox.DataSource = TaxList;
            POrderTaxFilterComboBox.SelectedItem = TaxList.Where(c => c.DefaultSelectedTax == true).FirstOrDefault();
        }

        /// <summary>
        /// Creates a new Purchase Order
        /// </summary>
        /// <param name="poContent">The purchase order content</param>
        private void DisplayPurchaseDocumentContent(List<PurchaseOrderDetails_Join> poContent)
        {
            if (poContent == null || poContent.Count() == 0)
            {
                PurchaseOrderContentList = RMS_Logic.PurchasingLogic.InitPOContentList_WithEmptyRows();
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
        /// Deactivate/Deactivate Buttons from the purchasing section according to the Purchase Order/Invoice state
        /// </summary>
        private void DeactivateButtons_Purchasing()
        {
            if (CurrentPOState == PurchaseOrderState.NewEmptyPO_NotAdded)
            {
                AddPurchaseOrderButton.Enabled = true;
                RegisterInvoiceButton.Enabled = false;
                DeletePurchaseOrderButton.Enabled = false;
            }

            if (CurrentPOState == PurchaseOrderState.NewPO_Added)
            {
                RegisterInvoiceButton.Enabled = true;
                AddPurchaseOrderButton.Enabled = false;
                DeletePurchaseOrderButton.Enabled = true;
            }

            if (CurrentPOState == PurchaseOrderState.InvoicedPO)
            {
                AddPurchaseOrderButton.Enabled = false;
                RegisterInvoiceButton.Enabled = false;
                DeletePurchaseOrderButton.Enabled = false;
            }
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
            if (RMS_Logic.PurchasingLogic.CountRemainingEmptyRows(PurchaseOrderContentList) < 1)
            {
                PurchaseOrderContentList.Add(new PurchaseOrderDetails_Join());
                POrderContentDataGridView.DataSource = null;
                POrderContentDataGridView.DataSource = PurchaseOrderContentList;
                POrderContentDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Check if there are products matching the searched product Name/Id and adds them to the selected row
        /// </summary>
        private bool AddSearchedProductToRow(string productName)
        {
            int closestEmptyRowIndex = RMS_Logic.PurchasingLogic.GetClosestEmptyRowIndex(PurchaseOrderContentList);
            //Check if we are on the "product name" column so we can add / search by name
            if (POrderContentDataGridView.CurrentCell.ColumnIndex == 1)
            {
                return TryAddProductToRow_ByName(productName, closestEmptyRowIndex);
            }

            //Check if we are on the "product id" column so we can add if there is a product with that id
            if (POrderContentDataGridView.CurrentCell.ColumnIndex == 0)
            {
                return TryAddProductToRow_ById(closestEmptyRowIndex);
            }
            POrderContentDataGridView.Refresh();

            return false;
        }

        /// <summary>
        /// Try to add a product to the closest empty row, by id
        /// </summary>
        /// <returns>True if we the product exists and was added / False otherwise</returns>
        private bool TryAddProductToRow_ById(int closestEmptyRowIndex)
        {
            int currentRowIndex = POrderContentDataGridView.CurrentCell.RowIndex;

            int idToSearch = Convert.ToInt32(POrderContentDataGridView.CurrentCell.Value);
            productToAdd = RMS_Logic.PurchasingLogic.RetrieveProductById(idToSearch, ProductsList);

            if (productToAdd != null)
            {
                RMS_Logic.PurchasingLogic.AddProductToPurchaseOrderContent_BySearchedId(closestEmptyRowIndex,
                                                                                        PurchaseOrderContentList,
                                                                                        ((TaxModel)ProductTaxComboBox.SelectedItem).Id,
                                                                                        productToAdd);

                if (closestEmptyRowIndex < POrderContentDataGridView.CurrentCell.RowIndex)
                    ClearCurrentRow(currentRowIndex);
            }
            else
            {
                DisplayErrorMessage_IfNoProductFound(POrderContentDataGridView.CurrentCell.Value.ToString());
                ClearCurrentRow(POrderContentDataGridView.CurrentCell.RowIndex);

                return false;
            }
            productToAdd = null;
            return true;
        }

        /// <summary>
        /// Clears the row at the specified index
        /// </summary>
        private void ClearCurrentRow(int rowIndex)
        {
            PurchaseOrderContentList[rowIndex].ProductId = 0;
            PurchaseOrderContentList[rowIndex].ProductName = "";
            PurchaseOrderContentList[rowIndex].PurchasePrice = 0;
            PurchaseOrderContentList[rowIndex].Quantity = 0;
            PurchaseOrderContentList[rowIndex].TaxId = 0;
        }

        /// <summary>
        /// Try to add a product to the closest empty row, by name
        /// </summary>
        /// <returns>True if we the product exists and was added / False otherwise</returns>
        private bool TryAddProductToRow_ByName(string productName, int closestEmptyRowIndex)
        {
            DisplayTheProductSearchResultsForm(productName);
            RMS_Logic.PurchasingLogic.AddProductToPurchaseOrderContent_BySearchedName(productName,
                                                                                      closestEmptyRowIndex,
                                                                                      ProductsList,
                                                                                      PurchaseOrderContentList,
                                                                                      ((TaxModel)ProductTaxComboBox.SelectedItem).Id);

            if (RMS_Logic.PurchasingLogic.SearchProductByName(productName, ProductsList).Count() == 0)
            {
                DisplayErrorMessage_IfNoProductFound(productName);
                POrderContentDataGridView.CurrentCell.Value = POrderContentDataGridView.CurrentCell.ColumnIndex == 1 ? "" : "0";
                return false;
            }

            productToAdd = null;
            return true;
        }

        /// <summary>
        /// Displays an error message if no product was found
        /// </summary>
        private void DisplayErrorMessage_IfNoProductFound(string productName)
        {
            MessageBox.Show($"There is no product matching \"{productName}\\");
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
        /// Display the form with the results of our search by product name
        /// </summary>
        private void DisplayTheProductSearchResultsForm(string productName)
        {
            if (RMS_Logic.PurchasingLogic.SearchProductByName(productName, ProductsList).Count() > 1)
            {
                SelectProductForm form = new SelectProductForm(this, productName);
                form.Show();
            }
        }

        /// <summary>
        /// Selects(in the case there are more than 1 products matching the searched name) a product and adds it to the order/datagridview rows
        /// </summary>
        public void ProductSelectionComplete(ProductModel product = null)
        {
            int index = RMS_Logic.PurchasingLogic.GetClosestEmptyRowIndex(PurchaseOrderContentList);
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
            bool wasAdded = false;
            if (POrderContentDataGridView.CurrentCell.Value != null)
                wasAdded = AddSearchedProductToRow(POrderContentDataGridView.CurrentCell.Value.ToString());

            if (POrderContentDataGridView.CurrentCell.ColumnIndex == 4)
                UpdateRowTaxId_IfValid();

            if (wasAdded == false)
            {
                //POrderContentDataGridView.CurrentCell.Value = POrderContentDataGridView.CurrentCell.ColumnIndex == 1 ? "" : "0";
            }

            AddNewRowIfNoneAvailable();
            POrderContentDataGridView.Refresh();
            PurchaseOrderTotal = RMS_Logic.PurchasingLogic.CalculatePurchaseOrderTotal(PurchaseOrderContentList);
            DisplayPurchaseDocumentTotals(PurchaseOrderTotal);
        }

        /// <summary>
        /// Validates if the inserted tax Id exists. If its not valid => uses default tax & shows error message
        /// </summary>
        private void UpdateRowTaxId_IfValid()
        {
            int cellTaxId = int.Parse(POrderContentDataGridView.CurrentCell.Value.ToString());

            if (cellTaxId != ((TaxModel)POrderTaxFilterComboBox.SelectedItem).Id)
            {
                if (GlobalConfig.Connection.GetTaxes_All().Where(t => t.Id == cellTaxId).Count() > 0)
                {
                    PurchaseOrderContentList[POrderContentDataGridView.CurrentCell.RowIndex].TaxId = cellTaxId;
                }
                else
                {
                    PurchaseOrderContentList[POrderContentDataGridView.CurrentCell.RowIndex].TaxId = ((TaxModel)POrderTaxFilterComboBox.SelectedItem).Id;
                    MessageBox.Show("Invalid Tax Id / Using Current Default Tax");
                }
            }
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

                PurchaseOrderModel purchaseOrder = RMS_Logic.PurchasingLogic.AddPurchaseOrderToDatabase(selectedSupplier,
                                                                                                        (DateTime)DocumentPostingDateTimePicker.Value,
                                                                                                        (DateTime)DocumentDueDateTimePicker.Value,
                                                                                                        (PaymentTermsModel)PaymentTermComboBox.SelectedItem);

                int orderId = purchaseOrder.Id;
                OrderNumberTextBox.Text = orderId.ToString();

                RMS_Logic.PurchasingLogic.AddPurchaseProductAndPrice(orderId,
                                                                     PurchaseOrderContentList,
                                                                     DocumentPostingDateTimePicker.Value);

                SelectedPurchaseOrder = purchaseOrder;
                ClearPurchaseOrderFormFields();
            }
        }

        /// <summary>
        /// Updates the due date according to the document/invoice date
        /// </summary>
        private void UpdateDueDate()
        {
            DocumentDueDateTimePicker.Value = InvoiceDateTimePicker.Value.Date.AddDays(((PaymentTermsModel)PaymentTermComboBox.SelectedItem).PaymentTerm_Days);
        }

        /// <summary>
        /// Display in the UI the purchase order/invoice totals
        /// </summary>
        private void DisplayPurchaseDocumentTotals(OrderTotal purchaseOrderTotal)
        {
            POrderTotalTextBox.Text = purchaseOrderTotal.Total.ToString("0.##");
            POrderTaxTotalTextBox.Text = purchaseOrderTotal.TaxTotal.ToString("0.##");
            POrderGrandTotalTextBox.Text = purchaseOrderTotal.GrandTotal.ToString("0.##");

            POrderTotalTextBox.ReadOnly = true;
            POrderTaxTotalTextBox.ReadOnly = true;
            POrderGrandTotalTextBox.ReadOnly = true;
        }

        /// <summary>
        /// Updates the payment term list after a new payment term was created/updated
        /// </summary>
        public void PaymentTermComplete()
        {
            InitializePaymentTermsList();
        }

        /// <summary>
        /// Calls a method to clear the purchasing fields
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearPurchaseOrderFormFields();
            POrdersCheckBox.Checked = true;
            PInvoicesCheckBox.Checked = false;
            ChangePurchasingDocument_UI_Elements(RequestedPurchasingDocument.PurchaseOrder);
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
            DisplayPurchaseDocumentContent(RMS_Logic.PurchasingLogic.TransformPOContent(poProductList));
            PurchaseOrderTotal = RMS_Logic.PurchasingLogic.CalculatePurchaseOrderTotal(PurchaseOrderContentList);
            DisplayPurchaseDocumentTotals(PurchaseOrderTotal);
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
            DisplayPurchaseDocumentContent(RMS_Logic.PurchasingLogic.TransformPOContent(invoiceProductList));
            PurchaseOrderTotal = RMS_Logic.PurchasingLogic.CalculatePurchaseOrderTotal(PurchaseOrderContentList);
            DisplayPurchaseDocumentTotals(PurchaseOrderTotal);
        }

        /// <summary>
        /// Register a purchase invoice, closes an active purchase order and adds the products in stock
        /// </summary>
        private void RegisterInvoiceButton_Click(object sender, EventArgs e)
        {
            decimal poGrandTotal = (POrderGrandTotalTextBox.Text == "" || POrderGrandTotalTextBox.Text == null) ? 0 : decimal.Parse(POrderGrandTotalTextBox.Text);

            if (SelectedPurchaseOrder != null && poGrandTotal > 0 && RMS_Logic.PurchasingLogic.PurchaseOrderNotInvoiced(SelectedPurchaseOrder))
            {
                CreateInvoice();
                ClosePurchaseOrder();
                RMS_Logic.PurchasingLogic.AddInvoicedProductsToStock(PurchaseOrderContentList);
                RMS_Logic.PurchasingLogic.UpdatePurchasePrices(PurchaseOrderContentList, SelectedPurchaseOrder.Id);
                ClearPurchaseOrderFormFields();
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
        /// Updates the tax change on the selected purchase order content in the datagridview
        /// </summary>
        private void POrderTaxFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PurchaseOrderContentList != null)
            {
                POrderContentDataGridView.Refresh();

                foreach (PurchaseOrderDetails_Join row in PurchaseOrderContentList)
                {
                    if (row.ProductId != 0 && row.ProductName != null)
                        row.TaxId = ((TaxModel)POrderTaxFilterComboBox.SelectedItem).Id;
                }

                PurchaseOrderTotal = RMS_Logic.PurchasingLogic.CalculatePurchaseOrderTotal(PurchaseOrderContentList);
                DisplayPurchaseDocumentTotals(PurchaseOrderTotal);
                POrderContentDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Updates the due date for the purchase invoice when the payment term is changed
        /// </summary>
        private void PaymentTermComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDueDate();
        }

        /// <summary>
        /// Formats the purchase order tax combobox so that is shows the tax id before the tax name
        /// </summary>
        private void POrderTaxFilterComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            TaxModel tax = ((TaxModel)e.ListItem);

            e.Value = $"[{tax.Id}] {tax.Name}";
        }

        /// <summary>
        /// Retrieves the last purchase document created according to what checkbox is selected (purchase order/invoice)
        /// </summary>
        private void LastDocumentButton_Click(object sender, EventArgs e)
        {
            RequestedPurchasingDocument _documentType = RequestedPurchasingDocument.PurchaseOrder;

            if (POrdersCheckBox.Checked && !PInvoicesCheckBox.Checked)
            {
                _documentType = RequestedPurchasingDocument.PurchaseOrder;
                PurchaseOrderModel po_model = GlobalConfig.Connection.GetPurchaseOrders_All().OrderByDescending(f => f.Id).FirstOrDefault();

                if (po_model != null)
                    DisplaySearchedPurchaseOrder(po_model);

                if (po_model.Status == OrderStatus.Active)
                    DisplaySettingsForActivePurchaseOrders(po_model);

                CurrentPOState = po_model.Status == OrderStatus.Active ? PurchaseOrderState.NewPO_Added : PurchaseOrderState.InvoicedPO;
                DeactivateButtons_Purchasing();
            }

            if (PInvoicesCheckBox.Checked && !POrdersCheckBox.Checked)
            {
                _documentType = RequestedPurchasingDocument.PurchaseInvoice;
                PurchaseInvoiceModel inv_model = GlobalConfig.Connection.GetPurchaseInvoices_All().OrderByDescending(f => f.Id).FirstOrDefault();

                if (inv_model != null)
                    DisplaySearchedPurchaseInvoice(inv_model);

                CurrentPOState = PurchaseOrderState.InvoicedPO;
                DeactivateButtons_Purchasing();
            }

            ChangePurchasingDocument_UI_Elements(_documentType);
        }

        /// <summary>
        /// Deletes a Purchase Order if it was not yet invoiced
        /// </summary>
        private void DeletePurchaseOrderButton_Click(object sender, EventArgs e)
        {
            if (SelectedPurchaseOrder != null && SelectedPurchaseOrder.Status != OrderStatus.Finished)
            {
                RMS_Logic.PurchasingLogic.DeletePurchaseProductAndPrice(SelectedPurchaseOrder.Id, PurchaseOrderContentList);
                GlobalConfig.Connection.Delete_PurchaseOrder(SelectedPurchaseOrder.Id);

                ClearPurchaseOrderFormFields();
                ChangePurchasingDocument_UI_Elements(RequestedPurchasingDocument.PurchaseOrder);
            }
        }

        #endregion
    }
}