using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RMLibrary;
using RMLibrary.Models;

namespace RestaurantUI
{
    public partial class ProductManagementForm : Form, ICategoryRequester, IRecipeRequester
    {
        public List<ProductModel> ProductList { get; set; } = GlobalConfig.Connection.GetProducts_All();
        public List<RecipeModel> RecipeList { get; set; } = GlobalConfig.Connection.GetRecipes_All();
        public List<CategoryModel> CategoryList { get; set; } = GlobalConfig.Connection.GetCategories_All();
        public List<ProductCategoryModel> SelectedProductCategoryList { get; set; } = GlobalConfig.Connection.GetProductCategories_All();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ProductManagementForm()
        {
            InitializeComponent();
            InitializeLists();
            ProductCategoryComboBox.SelectedItem = null;
        }

        /// <summary>
        /// Creates a new product and associates to it a recipe and a category if selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateProductButton_Click(object sender, EventArgs e)
        {
            if (ValidateFormInput())
            {
                ProductModel product = new ProductModel();
                product.Name = ProductNameTextBox.Text;

                if (ProductRecipeCheckBox.Checked == true && RecipesListBox.SelectedItem != null)
                    product.RecipeId = ((RecipeModel)RecipesListBox.SelectedItem).Id = ((RecipeModel)RecipesListBox.SelectedItem).Id;
                else
                    product.RecipeId = null;

                ProductModel createdproduct = GlobalConfig.Connection.CreateProduct(product);

                if (ProductCategoryComboBox.SelectedItem != null)
                {
                    ProductCategoryModel prodCategory = new ProductCategoryModel
                    {
                        CategoryId = ((CategoryModel)ProductCategoryComboBox.SelectedItem).Id,
                        ProductId = createdproduct.Id
                    };
                    GlobalConfig.Connection.CreateProductCategory(prodCategory);
                }
            }
            else
            {
                MessageBox.Show("You need to fill in at least a valid Product Name");
            }
            InitializeLists();
        }

        /// <summary>
        /// Validates if the product name textbox contains at least 2 characters
        /// </summary>
        /// <returns>Returns "true" if product name textbox contains at least 2 characters, and "false" otherwise </returns>
        private bool ValidateFormInput()
        {
            if (ProductNameTextBox.Text.Count() < 3)
                return false;

            return true;
        }

        /// <summary>
        /// Initializes the lists tied to product, recipe listboxes, and product category comboBox
        /// and clears selected elements
        /// </summary>
        private void InitializeLists()
        {
            ProductsListBox.DataSource = null;
            ProductsListBox.DataSource = ProductList;
            ProductsListBox.DisplayMember = "Name";

            RecipesListBox.DataSource = null;
            RecipesListBox.DataSource = RecipeList;
            RecipesListBox.DisplayMember = "Name";

            ProductCategoryComboBox.DataSource = null;
            ProductCategoryComboBox.DataSource = CategoryList;
            ProductCategoryComboBox.DisplayMember = "Name";

            SelectedProductCategoryList = GlobalConfig.Connection.GetProductCategories_All();
            ClearSelected();
        }

        /// <summary>
        /// Opens a window to CategoryManagementForm, that allows us to create/update a new category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewCategorylinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CategoryManagementForm categoryFrm = new CategoryManagementForm(this);
            categoryFrm.Show();
        }

        /// <summary>
        /// Gets called after we created/updated a category in the CategoryManagementForm and refreshes the lists and listBoxes/comboBoxes
        /// </summary>
        /// <param name="model"></param>
        public void CategoryComplete(CategoryModel model)
        {
            CategoryList = GlobalConfig.Connection.GetCategories_All();
            InitializeLists();
        }

        /// <summary>
        /// Opens a window to ProductRecipeForm, that allows us to create/update a  recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewRecipeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductRecipeForm recipeFrm = new ProductRecipeForm(this);
            recipeFrm.Show();
        }

        /// <summary>
        /// Gets called after we created/updated a recipe in the ProductRecipeForm and refreshes the lists and listBoxes/comboBoxes
        /// </summary>
        /// <param name="model"></param>
        public void RecipeComplete(RecipeModel model)
        {
            RecipeList = GlobalConfig.Connection.GetRecipes_All();
            InitializeLists();
        }

        /// <summary>
        /// When the selected product(from ProductsListBox) changes, it initializes the related elements
        /// (recipe in the RecipesListbox, and category in the ProductCategoryComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;
            if (selectedProduct != null)
            {
                ProductNameTextBox.Text = selectedProduct.Name;

                //if selectedProduct has a category - display it in the combobox
                if (SelectedProductCategoryList.Where(c => c.ProductId == selectedProduct.Id).Count() > 0)
                {
                    var selectedProdCateg = SelectedProductCategoryList.Where(c => c.ProductId == selectedProduct.Id).First();
                    ProductCategoryComboBox.SelectedItem = CategoryList.Where(c => c.Id == selectedProdCateg.CategoryId).First();
                }
                else
                {
                    ProductCategoryComboBox.SelectedItem = null;
                }

                //if selectedProduct has a recipe - display it in the listbox
                if (selectedProduct.RecipeId != null)
                {
                    RecipesListBox.SelectedItem = RecipeList.Where(r => r.Id == selectedProduct.RecipeId).First();
                }
                else
                {
                    RecipesListBox.ClearSelected();
                }
            }

        }

        /// <summary>
        /// Clears the selected elements in list/comboBoxes, and the product name textBox, on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearProductTextBoxesButton_Click(object sender, EventArgs e)
        {
            ClearSelected();
        }

        /// <summary>
        /// Clears the selected elements in list/comboBoxes, and the product name textBox
        /// </summary>
        private void ClearSelected()
        {
            ProductNameTextBox.Text = "";
            ProductsListBox.ClearSelected();
            ProductsListBox.SelectedItem = null;
            ProductCategoryComboBox.SelectedItem = null;
            RecipesListBox.ClearSelected();
            RecipesListBox.SelectedItem = null;
        }

        /// <summary>
        /// Associates the selected recipe, to the selected product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociateRecipeButton_Click(object sender, EventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;
            RecipeModel selectedRecipe = (RecipeModel)RecipesListBox.SelectedItem;

            selectedProduct.RecipeId = selectedRecipe.Id;
            GlobalConfig.Connection.UpdateProductModel(selectedProduct);
        }

        /// <summary>
        /// Updates a product and its related elements(name/recipe/category)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateProductButton_Click(object sender, EventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;
            RecipeModel selectedRecipe = (RecipeModel)RecipesListBox.SelectedItem;

            if (selectedProduct != null)
            {
                if (ProductNameTextBox.Text.Count() > 2)
                    selectedProduct.Name = ProductNameTextBox.Text;
                else
                    MessageBox.Show("Please enter a product Name with at least 3 characters!");

                if (selectedRecipe != null)
                    selectedProduct.RecipeId = selectedRecipe.Id;

                GlobalConfig.Connection.UpdateProductModel(selectedProduct);

                ProductCategoryModel existingProductCategory = SelectedProductCategoryList.Where(c => c.ProductId == selectedProduct.Id).FirstOrDefault();
                CategoryModel selectedCategory = ProductCategoryComboBox.SelectedItem == null ? null : (CategoryModel)ProductCategoryComboBox.SelectedItem;

                if (existingProductCategory != null && selectedCategory != null)
                {
                    if (existingProductCategory.CategoryId != selectedCategory.Id)
                    {
                        existingProductCategory.CategoryId = selectedCategory.Id;
                        GlobalConfig.Connection.UpdateProductCategoryModel(existingProductCategory);
                    }
                }
                else
                {
                    if (selectedCategory != null)
                        GlobalConfig.Connection.CreateProductCategory(new ProductCategoryModel { ProductId = selectedProduct.Id, CategoryId = selectedCategory.Id });
                }
            }
            InitializeLists();
        }
    }
}
