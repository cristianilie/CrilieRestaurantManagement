using RMLibrary;
using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class PricingManagementForm : Form
    {
        public List<ProductModel> ProductList { get; set; }
        public List<PriceModel> SelectedProductPriceList { get; set; }
        public List<PriceModel> PriceList_All { get; set; }

        PriceModel selectedActivePrice;

        /// <summary>
        /// Default constructor
        /// </summary>
        public PricingManagementForm()
        {
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
                PriceModel newPrice = new PriceModel();
                newPrice.ProductId = selectedProduct.Id;
                newPrice.SalesPrice = decimal.Parse(PriceTextBox.Text);
                newPrice.CurrentlyActivePrice = IsCurrentlyActivePriceCheckBox.Checked;

                if (IsCurrentlyActivePriceCheckBox.Checked)
                    UncheckPreviousActivePrice();

                GlobalConfig.Connection.CreatePrice(newPrice);
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
            PriceList_All = GlobalConfig.Connection.GetPrices_All();
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
            PriceModel selectedPrice = SelectedProductPriceList.Where(p => p.CurrentlyActivePrice == true).FirstOrDefault();
            PriceTextBox.Text = selectedPrice == null ? "" : selectedPrice.SalesPrice.ToString();

            IsCurrentlyActivePriceCheckBox.Checked = selectedPrice == null ? false : selectedPrice.CurrentlyActivePrice;
        }

        /// <summary>
        /// Returns a list of prices associated with the selected product
        /// </summary>
        /// <returns></returns>
        private List<PriceModel> GetSelectedProductPrices()
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;
            List<PriceModel> output = new List<PriceModel>();

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
                PriceModel newPrice = (PriceModel)SelectedProductPricesListBox.SelectedItem;

                newPrice.SalesPrice = decimal.Parse(PriceTextBox.Text);
                newPrice.CurrentlyActivePrice = IsCurrentlyActivePriceCheckBox.Checked;

                if (IsCurrentlyActivePriceCheckBox.Checked)
                    UncheckPreviousActivePrice();

                GlobalConfig.Connection.UpdatePriceModel(newPrice);

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
                GlobalConfig.Connection.UpdatePriceModel(selectedActivePrice);
            }
        }

        /// <summary>
        /// Updates the textbox and checkbox related to the selected price
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedProductPricesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PriceModel selectedPrice = (PriceModel)SelectedProductPricesListBox.SelectedItem;

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
            PriceModel selectedPrice = (PriceModel)SelectedProductPricesListBox.SelectedItem;
            if (selectedPrice != null)
            {
                GlobalConfig.Connection.DeleteProductPrice(selectedPrice);

                ResetForm();
                InitializePriceList();
            }
        }

    }
}
