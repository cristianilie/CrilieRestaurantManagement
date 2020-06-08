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
    public partial class ProductStockFromRecipeIngredientsForm : Form
    {
        private IProductRecipeRequester callingForm;

        public List<ProductModel> ProductWithRecipeList { get; set; }

        public List<ProductModel> AllProductsList { get; set; }

        List<RecipeAndContentModel> SelectedProduct_RecipeIngredients { get; set; }

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form
        /// </summary>
        public ProductStockFromRecipeIngredientsForm(IProductRecipeRequester caller, ProductModel selectedProduct)
        {
            InitializeComponent();
            callingForm = caller;

            InitializeProductList(selectedProduct);
            AllProductsList = GlobalConfig.Connection.GetProducts_All();
        }

        /// <summary>
        /// Initializes the product list(of products made up from recipes) and links it with the ProductListBox
        /// </summary>
        private void InitializeProductList(ProductModel selectedProduct)
        {
            ProductWithRecipeList = GlobalConfig.Connection.GetProducts_All().Where(p => p.RecipeId != null).ToList();

            ProductListBox.DataSource = null;
            ProductListBox.DataSource = ProductWithRecipeList;
            ProductListBox.DisplayMember = "Name";

            ProductListBox.SelectedItem = selectedProduct;
        }

        /// <summary>
        /// Initializes the Ingredient list for the selected product and links it with the IngredientListBox
        /// </summary>
        private void InitializeIngredientList(ProductModel selectedProduct)
        {
            RecipeModel recipe = GlobalConfig.Connection.GetRecipes_All().Where(r => r.Id == selectedProduct.RecipeId).SingleOrDefault();
            List<RecipeAndContentModel> recipeIngredients = GlobalConfig.Connection.GetRecipeAndContent(recipe);

            IngredientsListBox.DataSource = null;
            IngredientsListBox.DataSource = recipeIngredients;
            IngredientsListBox.DisplayMember = "ProductName";

            SelectedProduct_RecipeIngredients = recipeIngredients;
        }

        /// <summary>
        /// Clears listboxes selected items
        /// </summary>
        private void Clear()
        {
            ProductListBox.ClearSelected();
            IngredientsListBox.ClearSelected();
            ProductListBox.SelectedItem = null;
            IngredientsListBox.SelectedItem = null;
        }

        /// <summary>
        /// Initializes fields in the "Product Stock " groupBox asociated with the selected product
        /// </summary>
        private void InitializeProductStockDetails_GroupBox(int productId)
        {

            if (productId > 0)
            {
                ProductStockModel selectedProductStock = GlobalConfig.Connection.GetProductStock_Single(productId);

                if (selectedProductStock != null)
                {
                    ProductTotalStockQuantityLabel.Text = selectedProductStock.Quantity == 0 ? "0" : selectedProductStock.Quantity.ToString();
                    ProductBookedQuantityLabel.Text = selectedProductStock.BookedQuantity == 0 ? "0" : selectedProductStock.BookedQuantity.ToString();
                    ProductAvailableQuantityLabel.Text = (selectedProductStock.Quantity - selectedProductStock.BookedQuantity).ToString();
                }
                else
                {
                    ProductTotalStockQuantityLabel.Text = "0";
                    ProductBookedQuantityLabel.Text = "0";
                    ProductAvailableQuantityLabel.Text = "0";
                }
            }
        }

        /// <summary>
        /// Initializes fields in the "Ingredient Stock " groupBox asociated with the selected product's recipe
        /// </summary>
        private void InitializeIngredientStockDetails_GroupBox(int productId)
        {

            if (productId != 0)
            {
                ProductStockModel selectedProductStock = GlobalConfig.Connection.GetProductStock_Single(productId);

                if (selectedProductStock != null)
                {
                    IngredientTotalStockQuantityLabel.Text = selectedProductStock.Quantity == 0 ? "0" : selectedProductStock.Quantity.ToString();
                    IngredientBookedQuantityLabel.Text = selectedProductStock.BookedQuantity == 0 ? "0" : selectedProductStock.BookedQuantity.ToString();
                    IngredientAvailableQuantityLabel.Text = (selectedProductStock.Quantity - selectedProductStock.BookedQuantity).ToString();
                }
                else
                {
                    IngredientTotalStockQuantityLabel.Text = "0";
                    IngredientBookedQuantityLabel.Text = "0";
                    IngredientAvailableQuantityLabel.Text = "0";
                }
            }
        }

        /// <summary>
        /// Creates stock for the selected product, and removes from stock the ingredient quantities used
        /// </summary>
        private void CreateProductStockButton_Click(object sender, EventArgs e)
        {
            int quantityToCreate = int.Parse(QuantityToCreateTextBox.Text);
            if (ValidateIngredientsAvailability(SelectedProduct_RecipeIngredients, quantityToCreate))
            {
                ProductModel selectedProduct = (ProductModel)ProductListBox.SelectedItem;
                ProductStockModel selectedProductStock = new ProductStockModel
                {
                    ProductId = selectedProduct.Id,
                    Quantity = quantityToCreate
                };

                RMS_Logic.PurchasingLogic.AddProductToStock(selectedProductStock);

                List<OrderProductModel> productsToRemoveFromStock = new List<OrderProductModel>();
                foreach (RecipeAndContentModel ingredient in SelectedProduct_RecipeIngredients)
                {
                    productsToRemoveFromStock.Add(new OrderProductModel
                    {
                        OrderedQuantity = ingredient.ProductQuantity * quantityToCreate,
                        ProductId = ingredient.ProductId
                    });
                }

                RMS_Logic.SalesLogic.UnBookProducts(productsToRemoveFromStock);
                RMS_Logic.SalesLogic.RemoveProductsFromStock(productsToRemoveFromStock);

                Clear();
                //TODO - Record Journal transation for exceptional stoc creation/deletion
            }
        }

        /// <summary>
        /// Validates if the recipe ingredients have the requested quantity in stock
        /// </summary>
        private bool ValidateIngredientsAvailability(List<RecipeAndContentModel> RecipeIngredients, int quantityToCreate)
        {
            if (quantityToCreate < 1)
            {
                MessageBox.Show("Cannot create product with 0 Quantity");
                return false;
            }

            ProductStockModel ingredientStock;
            bool canCreateRequestedQuantity = false;

            foreach (RecipeAndContentModel ingredient in RecipeIngredients)
            {
                ingredientStock = GlobalConfig.Connection.GetProductStock_Single(ingredient.ProductId);

                if (ingredient.ProductQuantity * quantityToCreate > ingredientStock.AvailableQuantity)
                {
                    MessageBox.Show("Ingredient stock unavailable");
                    return false;
                }
                else
                {
                    canCreateRequestedQuantity = true;
                }
            }

            return canCreateRequestedQuantity;
        }

        /// <summary>
        /// Updates the groupbox with details about the product availability and initializes the ingredient listbox
        /// with the current product's recipe content
        /// </summary>
        private void ProductListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductModel selectedProduct = (ProductModel)ProductListBox.SelectedItem;
            if (selectedProduct != null)
            {
                InitializeProductStockDetails_GroupBox(selectedProduct.Id);
                InitializeIngredientList(selectedProduct);
            }
        }

        /// <summary>
        /// Updates the groupbox with details about the ingredient availability
        /// </summary>
        private void IngredientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeAndContentModel recipeContentProduct = (RecipeAndContentModel)IngredientsListBox.SelectedItem;
            if (recipeContentProduct != null)
                InitializeIngredientStockDetails_GroupBox(recipeContentProduct.ProductId);
        }

        /// <summary>
        /// Finishes the product stock from recipe creation process, and returns to the preious form, refreshing its product list 
        /// </summary>
        private void FinishButton_Click(object sender, EventArgs e)
        {
            callingForm.ProductCreationComplete();
            this.Close();
        }

        /// <summary>
        /// Validates that the inserted data is of integer type
        /// </summary>
        private void QuantityToCreateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!GlobalConfig.Validation.ValidateQuantity(QuantityToCreateTextBox.Text, e.KeyChar))
                e.Handled = true;
        }
    }
}
