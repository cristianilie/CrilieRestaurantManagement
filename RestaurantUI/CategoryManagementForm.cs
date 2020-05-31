using RMLibrary;
using RMLibrary.Models;
using RMLibrary.RMS_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class CategoryManagementForm : Form
    {
        public List<CategoryModel> CategoryList { get; set; }

        private ICategoryRequester callingForm;

        private CategoryModel lastCategoryCreated = new CategoryModel();

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form
        /// </summary>
        /// <param name="caller">Parameter used to call this form and request data by forms that implement ICategoryRequester interface</param>
        public CategoryManagementForm(ICategoryRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
            LoadCategories();
        }


        /// <summary>
        /// Creates a new Category in the database
        /// </summary>
        private void CreateCategoryButton_Click(object sender, EventArgs e)
        {
            if (ValidateFormInput() && !RMS_Logic.CategoryLogic.CheckIfCategoryNameExists(CategoryNameTextBox.Text))
            {
                CategoryModel category = new CategoryModel { Name = CategoryNameTextBox.Text };
                GlobalConfig.Connection.CreateCategory(category);

                LoadCategories();
                lastCategoryCreated = category;
            }
            else
            {
                MessageBox.Show("Category name must have at least 3 characters/Check if the name already exists!");
            }
        }

        /// <summary>
        /// Validates if the category name textbox contains at least 2 characters
        /// </summary>
        private bool ValidateFormInput()
        {
            if (CategoryNameTextBox.Text.Count() < 3)
                return false;

            return true;
        }

        /// <summary>
        /// Exits form
        /// </summary>
        private void ExitFormButton_Click(object sender, EventArgs e)
        {
            callingForm.CategoryComplete(lastCategoryCreated);
            this.Close();
        }

        /// <summary>
        /// Loads the category list and displays it in the ProductCategoriesListBox
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
