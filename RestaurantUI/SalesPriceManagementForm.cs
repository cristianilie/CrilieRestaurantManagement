using RMLibrary;
using RMLibrary.Models;
using RMLibrary.RMS_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class SalesPriceManagementForm : Form
    {
        public List<ProductModel> ProductList { get; set; }
        public List<SalesPriceModel> SelectedProductPriceList { get; set; }
        public List<SalesPriceModel> PriceList_All { get; set; }

        private ISalesPriceUpdater callingForm;
        private ProductModel lastSelectedProduct;


        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesPriceManagementForm()
        {
            InitializeComponent();
            InitializeProductList();
            InitializePriceList();
        }

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form
        /// </summary>
        /// <param name="caller">Parameter used to call this form and request data by forms that implement ISalesPriceUpdater interface</param>
        /// <param name="productModel">The product model whose price will be changed</param>
        public SalesPriceManagementForm(ISalesPriceUpdater caller, ProductModel productModel)
        {
            callingForm = caller;
            lastSelectedProduct = productModel;
            InitializeComponent();
            InitializeProductList();
            InitializePriceList();
        }

        /// <summary>
        /// Clears the textboxes and selected items
        /// </summary>
        private void ClearTextBoxesButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Associates a price with the selected product
        /// Creates a Price entry in the database
        /// </summary>
        private void AssociatePriceButton_Click(object sender, EventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;

            if (selectedProduct != null &&
                !RMS_Logic.SalesPriceLogic.CheckIfPriceAlreadyExists(decimal.Parse(PriceTextBox.Text), selectedProduct.Id, IsCurrentlyActivePriceCheckBox.Checked))
            {
                SalesPriceModel newPrice = new SalesPriceModel
                {
                    ProductId = selectedProduct.Id,
                    SalesPrice = decimal.Parse(PriceTextBox.Text),
                    CurrentlyActivePrice = IsCurrentlyActivePriceCheckBox.Checked
                };

                if (IsCurrentlyActivePriceCheckBox.Checked)
                    RMS_Logic.SalesPriceLogic.UncheckPreviousActivePrice(RMS_Logic.SalesPriceLogic.GetProductActivePrice(selectedProduct.Id));

                GlobalConfig.Connection.CreateSalesPrice(newPrice);
            }
            ResetForm();
            InitializePriceList();
        }



        /// <summary>
        /// Initializes the product list, and connects it with the ProductsListBox
        /// </summary>
        private void InitializeProductList()
        {
            ProductList = GlobalConfig.Connection.GetProducts_All();

            ProductsListBox.DataSource = null;
            ProductsListBox.DisplayMember = "Name";
            ProductsListBox.DataSource = ProductList;

            ResetForm();
        }

        /// <summary>
        /// Initializes a list with all the prices created in the database
        /// </summary>
        private void InitializePriceList()
        {
            PriceList_All = GlobalConfig.Connection.GetSalesPrices_All();
        }

        /// <summary>
        /// Imitializes the Price List related to the selected product
        /// </summary>
        private List<SalesPriceModel> InitializeSelectedProductPriceList(ProductModel selectedProduct)
        {
            InitializePriceList();
            if (selectedProduct != null)
                SelectedProductPriceList = RMS_Logic.SalesPriceLogic.GetSelectedProductPrices(selectedProduct, PriceList_All);

            SelectedProductPricesListBox.DataSource = null;
            SelectedProductPricesListBox.DisplayMember = "SalesPrice";
            SelectedProductPricesListBox.DataSource = SelectedProductPriceList;

            if(SelectedProductPriceList != null)
               SelectedProductPricesListBox.SelectedItem = SelectedProductPriceList.Where(c => c.CurrentlyActivePrice == true)
                                                                                .FirstOrDefault() ?? null;

            return SelectedProductPriceList;
        }

        /// <summary>
        /// Resets the form elements/selected items and clears the related textboxes
        /// </summary>
        private void ResetForm()
        {
            ProductsListBox.ClearSelected();
            ProductsListBox.SelectedItem = null;
            SelectedProductPricesListBox.ClearSelected();
            SelectedProductPricesListBox.SelectedItem = null;
            PriceTextBox.Text = "";
            IsCurrentlyActivePriceCheckBox.Checked = false;
        }

        /// <summary>
        /// When the selected product changes, in load the prices(related to the selected product) the "SelectedProductPricesListBox" listbox
        /// Displays(by default) the price that has true for "CurrentlyActivePrice" property
        /// </summary>
        private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedProductPriceList = InitializeSelectedProductPriceList((ProductModel)ProductsListBox.SelectedItem);
            SalesPriceModel selectedPrice = new SalesPriceModel();

            if (SelectedProductPriceList != null)
            {
                selectedPrice = SelectedProductPriceList.Where(p => p.CurrentlyActivePrice == true).FirstOrDefault();
            }

            PriceTextBox.Text = selectedPrice == null ? "" : selectedPrice.SalesPrice.ToString();
            lastSelectedProduct = (ProductModel)ProductsListBox.SelectedItem;
            IsCurrentlyActivePriceCheckBox.Checked = selectedPrice == null ? false : selectedPrice.CurrentlyActivePrice;
        }

        /// <summary>
        /// Updates the selected price
        /// </summary>
        private void UpdateProductPriceButton_Click(object sender, EventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;
            if (selectedProduct != null &&
                !RMS_Logic.SalesPriceLogic.CheckIfPriceAlreadyExists(decimal.Parse(PriceTextBox.Text), selectedProduct.Id, IsCurrentlyActivePriceCheckBox.Checked))
            {
                SalesPriceModel newPrice = (SalesPriceModel)SelectedProductPricesListBox.SelectedItem;
                                newPrice.SalesPrice = decimal.Parse(PriceTextBox.Text);
                                newPrice.CurrentlyActivePrice = IsCurrentlyActivePriceCheckBox.Checked;

                if (newPrice.CurrentlyActivePrice)
                    RMS_Logic.SalesPriceLogic.UncheckPreviousActivePrice(RMS_Logic.SalesPriceLogic.GetProductActivePrice(selectedProduct.Id));

                GlobalConfig.Connection.UpdateSalesPriceModel(newPrice);
                InitializeSelectedProductPriceList(selectedProduct);
            }
        }


        /// <summary>
        /// Updates the textbox and checkbox related to the selected price
        /// </summary>
        private void SelectedProductPricesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SalesPriceModel selectedPrice = (SalesPriceModel)SelectedProductPricesListBox.SelectedItem;

            PriceTextBox.Text = selectedPrice == null ? "" : selectedPrice.SalesPrice.ToString();
            IsCurrentlyActivePriceCheckBox.Checked =  selectedPrice == null ? false : selectedPrice.CurrentlyActivePrice; ;
        }

        /// <summary>
        /// Deletes the selected price entry
        /// </summary>
        private void DeletePriceButton_Click(object sender, EventArgs e)
        {
            SalesPriceModel selectedPrice = (SalesPriceModel)SelectedProductPricesListBox.SelectedItem;
            if (selectedPrice != null)
            {
                GlobalConfig.Connection.DeleteSalesPrice(selectedPrice);
                InitializeSelectedProductPriceList((ProductModel)ProductsListBox.SelectedItem);
            }
        }

        /// <summary>
        /// Validates characters entered to the price textbox
        /// </summary>
        private void PriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!GlobalConfig.Validation.ValidatePrice(PriceTextBox.Text, e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// If the for wa opened from another form implementing the  interface, it calls the  SalesPriceUpdateComplete to
        /// finish the sales price update process
        /// Closes the current window
        /// </summary>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (callingForm == null)
            {
                this.Close();
            }
            else
            {
                callingForm.SalesPriceUpdateComplete(lastSelectedProduct);
                this.Close();
            }
        }
    }
}
