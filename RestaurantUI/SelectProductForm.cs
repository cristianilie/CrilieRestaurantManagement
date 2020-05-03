using RMLibrary;
using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class SelectProductForm : Form
    {
        private IProductRequester callingForm;

        public List<ProductModel> ProductList { get; set; }

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form or uses the default parameter values
        /// </summary>
        /// <param name="caller">Parameter used to call this form and request data by forms that implement IProductRequester interface</param>
        /// <param name="searchedName">The text by we search for a product</param>
        public SelectProductForm(IProductRequester caller = null, string searchedName = "")
        {
            InitializeComponent();

            if(caller != null)
                callingForm = caller;

            ProductList = GetMatchingProducts(searchedName);
        }

        /// <summary>
        /// Returns a list of products whose names contain the searched text
        /// </summary>
        /// <param name="searchedProductName">The searched text</param>
        private List<ProductModel> GetMatchingProducts(string searchedProductName)
        {
            return searchedProductName == "" || searchedProductName == " " ?
                                 GlobalConfig.Connection.GetProducts_All() :
                                 GlobalConfig.Connection.GetProducts_All().Where(p => p.Name.ToLower().Contains(searchedProductName.ToLower())).ToList();
        }

        /// <summary>
        /// When the form loads, initialize the  ProductsListBox
        /// </summary>
        private void SelectProductForm_Load(object sender, EventArgs e)
        {
            ProductsListBox.DataSource = ProductList;
            ProductsListBox.DisplayMember = "Name";
            ProductsListBox.ClearSelected();
        }

        /// <summary>
        /// Finishes the product selection process by sendint data to the calling form and closing the current window
        /// </summary>
        private void SelectButton_Click(object sender, EventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;

            if (selectedProduct != null)
            {
                callingForm.ProductSelectionComplete(selectedProduct);
                this.Close();
            }
        }

        /// <summary>
        /// Cancels the product selection process by calling ProductSelectionComplete with the default parameter(null)
        /// and closing the current window
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            callingForm.ProductSelectionComplete();
            this.Close();
        }
    }
}
