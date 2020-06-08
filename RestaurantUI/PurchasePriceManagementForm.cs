using RMLibrary;
using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class PurchasePriceManagementForm : Form
    {
        public List<ProductModel> ProductList { get; set; }
        public List<PurchasePriceModel> ProductPurchasePriceList { get; set; }
        public List<PurchasePriceModel> SelectedProduct_PurchasePriceList { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PurchasePriceManagementForm()
        {
            InitializeComponent();
            InitializeProductList();
            ProductPurchasePriceList = GlobalConfig.Connection.GetPurchasePrices_All();
        }

        /// <summary>
        /// Clears textboxes/selected elements
        /// </summary>
        private void ClearTextBoxesButton_Click(object sender, EventArgs e)
        {
            ClearSelected();
        }

        /// <summary>
        /// Initializes the product list and links it with the ProductsListBox
        /// </summary>
        private void InitializeProductList()
        {
            ProductList = GlobalConfig.Connection.GetProducts_All();

            ProductsListBox.DataSource = null;
            ProductsListBox.DataSource = ProductList;
            ProductsListBox.DisplayMember = "Name";

            ClearSelected();
        }

        /// <summary>
        /// Initialize the list of prices associated with the selected product if the purchase order was invoiced
        /// </summary>
        private void InitializeSelectedProductPriceList(ProductModel selectedProduct)
        {
            List<int> finishedPurchaseOrderIds = GlobalConfig.Connection.GetPurchaseOrders_All()
                                                                        .Where(p => p.Status == OrderStatus.Finished)
                                                                        .Select(c => c.Id)
                                                                        .ToList();

            SelectedProduct_PurchasePriceList = GlobalConfig.Connection.GetPurchasePrices_All()
                                                                       .Where(p => p.ProductId == selectedProduct.Id && finishedPurchaseOrderIds.Contains(p.PurchaseOrderId))
                                                                       .OrderByDescending(c => c.PurchaseDate)
                                                                       .ToList();

            SelectedProductPricesListBox.DataSource = null;
            SelectedProductPricesListBox.DataSource = SelectedProduct_PurchasePriceList;
            SelectedProductPricesListBox.DisplayMember = "PurchasePrice";

        }

        /// <summary>
        /// Clears textboxes/resets selected fields and PurchaseDateLabel.Text
        /// </summary>
        private void ClearSelected()
        {
            PriceTextBox.Text = "";
            PurchaseDateLabel.Text = "Purchase Date";
            ProductsListBox.ClearSelected();
            ProductsListBox.SelectedItem = null;
            SelectedProductPricesListBox.DataSource = null;
            SelectedProductPricesListBox.ClearSelected();
            SelectedProductPricesListBox.SelectedItem = null;
        }

        /// <summary>
        /// When the selected product changes the price listbox gets updated with the prices associated with the selected product
        /// </summary>
        private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedProduct_PriceListBox();
        }

        /// <summary>
        /// Updates the product price listbox when the selected product changes
        /// </summary>
        private void UpdateSelectedProduct_PriceListBox()
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;

            if (selectedProduct != null)
                InitializeSelectedProductPriceList(selectedProduct);
        }

        /// <summary>
        /// When a price is selected, it displays information in the associated textbox/checkbox
        /// </summary>
        private void SelectedProductPricesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedPriceFields();
        }

        /// <summary>
        /// Display in the UI/listbox/textbox changes made to the selected price  
        /// </summary>
        private void UpdateSelectedPriceFields()
        {
            PurchasePriceModel purchasePrice = (PurchasePriceModel)SelectedProductPricesListBox.SelectedItem;
            if (purchasePrice != null)
            {
                PriceTextBox.Text = purchasePrice.PurchasePrice.ToString();
                PurchaseDateLabel.Text = purchasePrice.PurchaseDate.ToShortDateString();
            }
            else
            {
                PriceTextBox.Text = "";
                PurchaseDateLabel.Text = "Purchase Date";
            }
        }

        /// <summary>
        /// Updates the selected price(in the UI/database)
        /// </summary>
        private void UpdateProductPriceButton_Click(object sender, EventArgs e)
        {
            PurchasePriceModel purchasePrice = (PurchasePriceModel)SelectedProductPricesListBox.SelectedItem;
            if (purchasePrice != null)
            {
                purchasePrice.PurchasePrice = decimal.Parse(PriceTextBox.Text);
                GlobalConfig.Connection.UpdatePurchasePriceModel(purchasePrice);

                ProductPurchasePriceList = GlobalConfig.Connection.GetPurchasePrices_All();
                UpdateSelectedProduct_PriceListBox();
            }
        }

        /// <summary>
        /// Validates the the characters inserted into the price textbox, so that the price can be only decimal
        /// </summary>
        private void PriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!GlobalConfig.Validation.ValidatePrice(PriceTextBox.Text, e.KeyChar))
                e.Handled = true;
        }
    }
}
