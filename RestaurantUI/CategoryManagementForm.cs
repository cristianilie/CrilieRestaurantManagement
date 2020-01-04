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
    public partial class CategoryManagementForm : Form
    {
        public List<CategoryModel> CategoryList { get; set; } = GlobalConfig.Connection.GetCategories_All();

        private ICategoryRequester callingForm;

        private CategoryModel lastCategoryCreated = new CategoryModel();
        public CategoryManagementForm(ICategoryRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
            LoadCategories();
        }


        /// <summary>
        /// Creates a new Category in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCategoryButton_Click(object sender, EventArgs e)
        {
            if (ValidateFormInput())
            {
                CategoryModel category = new CategoryModel { Name = CategoryNameTextBox.Text };
                GlobalConfig.Connection.CreateCategory(category);
                LoadCategories();
                lastCategoryCreated = category;
            }
            else
            {
                MessageBox.Show("You need to fill in at least a valid Product Name");
            }
        }

        /// <summary>
        /// Validates if the category name textbox contains at least 2 characters
        /// </summary>
        /// <returns>Returns "true" if category name textbox contains at least 2 characters, and "false" otherwise </returns>
        private bool ValidateFormInput()
        {
            if (CategoryNameTextBox.Text.Count() < 3)
                return false;

            return true;
        }

        /// <summary>
        /// Exits form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitFormButton_Click(object sender, EventArgs e)
        {
            callingForm.CategoryComplete(lastCategoryCreated);
            this.Close();
        }

        /// <summary>
        /// Loads the category list
        /// </summary>
        private void LoadCategories()
        {
            CategoryList = GlobalConfig.Connection.GetCategories_All();

            ProductCategoriesListBox.DataSource = null;
            ProductCategoriesListBox.DataSource = CategoryList;
            ProductCategoriesListBox.DisplayMember = "Name";

            ResetForm();
        }

        /// <summary>
        /// Updates the name of the selected category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCategoryButton_Click(object sender, EventArgs e)
        {
            if (ProductCategoriesListBox.SelectedItem != null)
            {
                CategoryModel modelToUpdate = (CategoryModel)ProductCategoriesListBox.SelectedItem;
                modelToUpdate.Name = CategoryNameTextBox.Text;
                GlobalConfig.Connection.UpdateCategoryModel(modelToUpdate);
                LoadCategories();
            }
        }

        /// <summary>
        /// Resets the category name textbox and category listbox selected item
        /// </summary>
        private void ResetForm()
        {
            ProductCategoriesListBox.ClearSelected();
            CategoryNameTextBox.Text = "";
        }

        /// <summary>
        /// When the selected item from the listbox changes, it initializes the category name textbox, with the name of the new selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductCategoriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductCategoriesListBox.SelectedItem != null)
            {
                CategoryModel selectedCategory = (CategoryModel)ProductCategoriesListBox.SelectedItem;
                CategoryNameTextBox.Text = selectedCategory.Name;
            }
        }

        /// <summary>
        /// Resets the category name textbox and category listbox selected item
        /// </summary>
        private void ClearCategoryNameTextBoxButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
