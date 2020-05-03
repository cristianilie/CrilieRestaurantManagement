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
        private void CreateProductButton_Click(object sender, EventArgs e)
        {
            ProductModel product = new ProductModel();
            product.Name = ProductNameTextBox.Text;

            if (ValidateFormInput() && ProductValidation(product))
            {
                AssociateProductRecipe(product);
                ProductModel createdproduct = GlobalConfig.Connection.CreateProduct(product);
                AssociateProductCategory(createdproduct);
            }
            else
            {
                MessageBox.Show("The product name must be at least 3 characters, and it shouldnt already exist in the database!");
            }
            InitializeLists();
        }

        /// <summary>
        /// Associate a product category(if one is selected) to the new created product
        /// </summary>
        private void AssociateProductCategory(ProductModel createdproduct)
        {
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

        /// <summary>
        /// Associate a product recipe to the selected product
        /// </summary>
        private void AssociateProductRecipe(ProductModel product)
        {
            if (ProductRecipeCheckBox.Checked == true && RecipesListBox.SelectedItem != null)
                product.RecipeId = ((RecipeModel)RecipesListBox.SelectedItem).Id;
            else
                product.RecipeId = null;
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
        private void CreateNewCategorylinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CategoryManagementForm categoryFrm = new CategoryManagementForm(this);
            categoryFrm.Show();
        }

        /// <summary>
        /// Gets called after we created/updated a category in the CategoryManagementForm and refreshes the lists and listBoxes/comboBoxes
        /// </summary>
        public void CategoryComplete(CategoryModel model)
        {
            CategoryList = GlobalConfig.Connection.GetCategories_All();
            InitializeLists();
        }

        /// <summary>
        /// Opens a window to ProductRecipeForm, that allows us to create/update a  recipe
        /// </summary>
        private void CreateNewRecipeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductRecipeForm recipeFrm = new ProductRecipeForm(this);
            recipeFrm.Show();
        }

        /// <summary>
        /// Gets called after we created/updated a recipe in the ProductRecipeForm and refreshes the lists and listBoxes/comboBoxes
        /// </summary>
        public void RecipeComplete(RecipeModel model)
        {
            RecipeList = GlobalConfig.Connection.GetRecipes_All();
            InitializeLists();
        }

        /// <summary>
        /// When the selected product(from ProductsListBox) changes, it initializes the related elements
        /// recipe in the RecipesListbox, and category in the ProductCategoryComboBox
        /// </summary>
        private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;

            if (selectedProduct != null)
            {
                ProductNameTextBox.Text = selectedProduct.Name;

                DisplayProductCategoryIfExists(selectedProduct);
                DisplayRecipeIfExists(selectedProduct);
            }

        }

        /// <summary>
        /// if selectedProduct has a category - display it in the combobox
        /// </summary>
        private void DisplayProductCategoryIfExists(ProductModel selectedProduct)
        {
            if (SelectedProductCategoryList.Where(c => c.ProductId == selectedProduct.Id).Count() > 0)
            {
                var selectedProdCateg = SelectedProductCategoryList.Where(c => c.ProductId == selectedProduct.Id).First();
                ProductCategoryComboBox.SelectedItem = CategoryList.Where(c => c.Id == selectedProdCateg.CategoryId).First();
            }
            else
            {
                ProductCategoryComboBox.SelectedItem = null;
            }
        }

        //if selectedProduct has a recipe - display it in the recipe listbox
        private void DisplayRecipeIfExists(ProductModel selectedProduct)
        {
            if (selectedProduct.RecipeId != null)
                RecipesListBox.SelectedItem = RecipeList.Where(r => r.Id == selectedProduct.RecipeId).First();
            else
                RecipesListBox.ClearSelected();
        }

        /// <summary>
        /// Clears the selected elements in list/comboBoxes, and the product name textBox, on button click
        /// </summary>
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
        private void UpdateProductButton_Click(object sender, EventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductsListBox.SelectedItem;
            RecipeModel selectedRecipe = (RecipeModel)RecipesListBox.SelectedItem;

            if (ProductValidation(selectedProduct))
            {
                UpdateProductModel(selectedProduct, selectedRecipe);
                ProductCategoryModel existingProductCategory = GetExistingProductCategory(selectedProduct);
                CategoryModel selectedCategory = (CategoryModel)ProductCategoryComboBox.SelectedItem;

                UpdateProductCategoryModel(selectedProduct, existingProductCategory, selectedCategory);
            }
            InitializeLists();
        }

        /// <summary>
        /// Validates that the selected product is not null, it doesnt exist already, and its name has at least 3 characters
        /// </summary>
        private bool ProductValidation(ProductModel selectedProduct)
        {
            return selectedProduct != null && !CheckProductNameLength(ProductNameTextBox.Text) && !CheckIfProductNameExists(ProductNameTextBox.Text);
        }

        /// <summary>
        /// Updates the selected product category model or creates a new product-category associacion if oe does not already exists
        /// </summary>
        private static void UpdateProductCategoryModel(ProductModel selectedProduct, ProductCategoryModel existingProductCategory, CategoryModel selectedCategory)
        {
            if (ProductCategoryValidation(existingProductCategory, selectedCategory))
            {
                existingProductCategory.CategoryId = selectedCategory.Id;
                GlobalConfig.Connection.UpdateProductCategoryModel(existingProductCategory);
            }
            else
            {
                if (selectedCategory != null)
                    GlobalConfig.Connection.CreateProductCategory(new ProductCategoryModel { ProductId = selectedProduct.Id, CategoryId = selectedCategory.Id });
            }
        }

        /// <summary>
        /// Validates that the existing product category, the selected category are not null, and the existing category is not the 
        /// same with the one selected from the category list
        /// </summary>
        private static bool ProductCategoryValidation(ProductCategoryModel existingProductCategory, CategoryModel selectedCategory)
        {
            return existingProductCategory != null && 
                   selectedCategory != null &&
                   (existingProductCategory.CategoryId != selectedCategory.Id);
        }

        /// <summary>
        /// Retrieves the selected product's category, or "null" if the product isn't associated with a category
        /// </summary>
        private ProductCategoryModel GetExistingProductCategory(ProductModel selectedProduct)
        {
            return SelectedProductCategoryList.Where(c => c.ProductId == selectedProduct.Id)
                                              .FirstOrDefault();
        }

        /// <summary>
        /// Updates the product model
        /// </summary>
        private void UpdateProductModel(ProductModel selectedProduct, RecipeModel selectedRecipe)
        {
            selectedProduct.Name = ProductNameTextBox.Text;

            if (selectedRecipe != null)
                selectedProduct.RecipeId = selectedRecipe.Id;

            GlobalConfig.Connection.UpdateProductModel(selectedProduct);
        }

        /// <summary>
        /// Checks if the product name already exists
        /// </summary>
        private bool CheckIfProductNameExists(string productName)
        {
            return ProductList.Where(p => p.Name.ToLower() == productName.ToLower()).Count() > 0;
        }

        /// <summary>
        /// Checks if the product name is at least 3 characters long
        /// </summary>
        private bool CheckProductNameLength(string productName)
        {
            if (productName.Length > 2)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please enter a product Name with at least 3 characters!");
                return false;
            }
        }
    }
}
