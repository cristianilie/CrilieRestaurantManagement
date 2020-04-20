using RMLibrary;
using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class SelectProductForm : Form
    {
        private IProductRequester callingForm;
        private string searchedWord;

        public List<ProductModel> ProductList { get; set; }

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form or uses the default parameter values
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="searchedName"></param>
        public SelectProductForm(IProductRequester caller = null, string searchedName = "")
        {
            InitializeComponent();

            if(caller != null)
                callingForm = caller;
            searchedWord = searchedName;

            ProductList = searchedWord == "" || searchedWord == " " ?
                                            GlobalConfig.Connection.GetProducts_All() :
                                            GlobalConfig.Connection.GetProducts_All().Where(p => p.Name.ToLower().Contains(searchedWord.ToLower())).ToList();
        }

        /// <summary>
        /// When the form loads, initialize the  ProductsListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectProductForm_Load(object sender, EventArgs e)
        {
            ProductsListBox.DataSource = ProductList;
            ProductsListBox.DisplayMember = "Name";
            ProductsListBox.ClearSelected();
        }

        /// <summary>
        /// Finishes the product selection process by sendint data to the calling form and closing the current window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            callingForm.ProductSelectionComplete();
            this.Close();
        }
    }
}
