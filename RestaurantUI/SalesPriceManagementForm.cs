using RMLibrary;
using RMLibrary.Models;
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

        private SalesPriceModel selectedActivePrice;

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
        /// <param name="caller"></param>
        /// <param name="productModel"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearTextBoxesButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Associates a price with the selected product
        /// Creates a Price entry in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatePriceButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;
                SalesPriceModel newPrice = new SalesPriceModel();
                newPrice.ProductId = selectedProduct.Id;
                newPrice.SalesPrice = decimal.Parse(PriceTextBox.Text);
                newPrice.CurrentlyActivePrice = IsCurrentlyActivePriceCheckBox.Checked;

                if (IsCurrentlyActivePriceCheckBox.Checked)
                    UncheckPreviousActivePrice();

                GlobalConfig.Connection.CreateSalesPrice(newPrice);
            }
            ResetForm();
            InitializePriceList();
        }

        /// <summary>
        /// Validates if the form textboxes are least  2 and 1 characters long, and the Tax wasn't already created
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            if (ProductsListBox.SelectedItem != null && PriceTextBox.Text.Count() > 0)
            {
                    return true;
            }
            else
            {
                MessageBox.Show("Select a product and enter a price for it!");
            }
            return false;
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
        private void InitializeSelectedProductPriceList()
        {
            SelectedProductPriceList = GetSelectedProductPrices();

            SelectedProductPricesListBox.DataSource = null;
            SelectedProductPricesListBox.DisplayMember = "SalesPrice";
            SelectedProductPricesListBox.DataSource = SelectedProductPriceList;

            SelectedProductPricesListBox.SelectedItem = SelectedProductPriceList.Where(c => c.CurrentlyActivePrice == true).FirstOrDefault() == null ? 
                null : 
                SelectedProductPriceList.Where(c => c.CurrentlyActivePrice == true).FirstOrDefault();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeSelectedProductPriceList();
            SalesPriceModel selectedPrice = SelectedProductPriceList.Where(p => p.CurrentlyActivePrice == true).FirstOrDefault();
            PriceTextBox.Text = selectedPrice == null ? "" : selectedPrice.SalesPrice.ToString();
            lastSelectedProduct = (ProductModel)ProductsListBox.SelectedItem;
            IsCurrentlyActivePriceCheckBox.Checked = selectedPrice == null ? false : selectedPrice.CurrentlyActivePrice;
        }

        /// <summary>
        /// Returns a list of prices associated with the selected product
        /// </summary>
        /// <returns></returns>
        private List<SalesPriceModel> GetSelectedProductPrices()
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;
            List<SalesPriceModel> output = new List<SalesPriceModel>();

            if (selectedProduct != null && PriceList_All != null)
            {
                output = PriceList_All.Where(p => p.ProductId == selectedProduct.Id).ToList();
            }

            selectedActivePrice = output.Where(q => q.CurrentlyActivePrice == true).FirstOrDefault();

            return output;
        }

        /// <summary>
        /// Updates the selected price
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateProductPriceButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SalesPriceModel newPrice = (SalesPriceModel)SelectedProductPricesListBox.SelectedItem;

                newPrice.SalesPrice = decimal.Parse(PriceTextBox.Text);
                newPrice.CurrentlyActivePrice = IsCurrentlyActivePriceCheckBox.Checked;

                if (IsCurrentlyActivePriceCheckBox.Checked)
                    UncheckPreviousActivePrice();

                GlobalConfig.Connection.UpdateSalesPriceModel(newPrice);

                ResetForm();
                InitializePriceList();
            }

        }

        /// <summary>
        /// Searches for the current "active price", sets it to false and updates it into the database
        /// </summary>
        private void UncheckPreviousActivePrice()
        {
            if (selectedActivePrice != null)
            {
                selectedActivePrice.CurrentlyActivePrice = false;
                GlobalConfig.Connection.UpdateSalesPriceModel(selectedActivePrice);
            }
        }

        /// <summary>
        /// Updates the textbox and checkbox related to the selected price
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedProductPricesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SalesPriceModel selectedPrice = (SalesPriceModel)SelectedProductPricesListBox.SelectedItem;

            PriceTextBox.Text = selectedPrice == null ? "" : selectedPrice.SalesPrice.ToString();
            IsCurrentlyActivePriceCheckBox.Checked =  selectedPrice == null ? false : selectedPrice.CurrentlyActivePrice; ;

        }

        /// <summary>
        /// Deletes the selected price entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePriceButton_Click(object sender, EventArgs e)
        {
            SalesPriceModel selectedPrice = (SalesPriceModel)SelectedProductPricesListBox.SelectedItem;
            if (selectedPrice != null)
            {
                GlobalConfig.Connection.DeleteSalesPrice(selectedPrice);

                ResetForm();
                InitializePriceList();
            }
        }

        /// <summary>
        /// Validates characters entered to the price textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!GlobalConfig.Validation.ValidatePrice(PriceTextBox.Text, e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// If the for wa opened from another form implementing the  interface, it calls the  SalesPriceUpdateComplete to
        /// finish the sales price update process
        /// Closes the current window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
