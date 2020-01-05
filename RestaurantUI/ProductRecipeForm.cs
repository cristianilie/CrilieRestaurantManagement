using RMLibrary;
using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class ProductRecipeForm : Form
    {
        public List<RecipeModel> RecipesList { get; set; } = GlobalConfig.Connection.GetRecipes_All();
        public List<ProductModel> ProductsList { get; set; } = GlobalConfig.Connection.GetProducts_All();
        public List<RecipeAndContentModel> SelectedRecipeContent { get; set; } = new List<RecipeAndContentModel>();
        
        private IRecipeRequester callingForm;

        private RecipeModel lastRecipeCreated = new RecipeModel();

        /// <summary>
        /// Constructor(overloaded)
        /// </summary>
        /// <param name="caller"></param>
        public ProductRecipeForm(IRecipeRequester caller)
        {
            callingForm = caller;
            InitializeComponent();
            InitializeRecipeList();
            InitializeProductList();
            ResetForm();
        }
        
        /// <summary>
        /// Resets the form elements/selected items and clears the selected recipe's ingredients list
        /// </summary>
        private void ResetForm()
        {
            ProductsListBox.ClearSelected();
            SelectedRecipeContentListbox.ClearSelected();
            RecipesListBox.ClearSelected();
            RecipeNameTextBox.Text = "";
            SelectedRecipeContent.Clear();

            ClearRecipeContentList();
        }

        /// <summary>
        /// Initializes the recipe list, and connects it with the recipe listbox
        /// </summary>
        private void InitializeRecipeList()
        {
            RecipesList = GlobalConfig.Connection.GetRecipes_All();

            RecipesListBox.DataSource = null;
            RecipesListBox.DisplayMember = "Name";
            RecipesListBox.DataSource = RecipesList;

            ResetForm();
        }
        
        /// <summary>
        /// Initializes the product(recipe ingredient) list, and connects it with the product listbox
        /// </summary>
        private void InitializeProductList()
        {
            ProductsList = GlobalConfig.Connection.GetProducts_All();

            ProductsListBox.DataSource = null;
            ProductsListBox.DataSource = ProductsList;
            ProductsListBox.DisplayMember = "Name";

            ResetForm();
        }

        /// <summary>
        /// Initializes the list of ingredients belonging to the selected recipe and connects it with the SelectedRecipeContentListbox
        /// </summary>
        private void InitializeRecipeContentList(bool refresh = false)
        {
            if (RecipesListBox.SelectedItem != null || RecipesListBox.SelectedIndex != -1)
            {
                SelectedRecipeContentListbox.DataSource = null;
                SelectedRecipeContentListbox.DisplayMember = "ProductName";
                SelectedRecipeContentListbox.DataSource = SelectedRecipeContent;
            }

            if (refresh)
            {
                SelectedRecipeContentListbox.DataSource = null;
                SelectedRecipeContentListbox.DisplayMember = "ProductName";
                SelectedRecipeContentListbox.DataSource = SelectedRecipeContent;
            }
        }

        /// <summary>
        /// Clears the selected recipe content list & SelectedRecipeContentListbox
        /// </summary>
        private void ClearRecipeContentList()
        {
                SelectedRecipeContent.Clear();
                SelectedRecipeContentListbox.DataSource = null;
                SelectedRecipeContentListbox.DisplayMember = "ProductName";
                SelectedRecipeContentListbox.DataSource = SelectedRecipeContent;
        }

        /// <summary>
        /// Exits the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            callingForm.RecipeComplete(lastRecipeCreated);
            this.Close();
        }

        /// <summary>
        /// When the "selected recipe" changes, the "recipe content listbox" gets initialized with the current "selected recipe"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecipesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((RecipeModel)RecipesListBox.SelectedItem != null)
            {
                RecipeNameTextBox.Text = ((RecipeModel)RecipesListBox.SelectedItem).Name;
                SelectedRecipeContent = GlobalConfig.Connection.GetRecipeAndContent((RecipeModel)RecipesListBox.SelectedItem);
                InitializeRecipeContentList();
            }
        }

        /// <summary>
        /// Displays the ingredient quantity in "()", left of the ingredient name, in the selected recipe content listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedRecipeContentListbox_Format(object sender, ListControlConvertEventArgs e)
        {
            RecipeAndContentModel ingredient = ((RecipeAndContentModel)e.ListItem);

            e.Value = $"({ingredient.ProductQuantity}) {ingredient.ProductName}";
        }

        /// <summary>
        /// Adds an ingredient to a recipe(new or existing one)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRecipeItemButton_Click(object sender, EventArgs e)
        {
            ProductModel p = (ProductModel)ProductsListBox.SelectedItem;
            if (SelectedRecipeContent.Where(c => c.ProductId == p.Id).Count() > 0)
            {
                RecipeAndContentModel racm = SelectedRecipeContent.Where(c => c.ProductId == p.Id).First();
                SelectedRecipeContent[SelectedRecipeContent.IndexOf(racm)].ProductQuantity++;
            }
            else
            {
                SelectedRecipeContent.Add(new RecipeAndContentModel { ProductId = p.Id, ProductName = p.Name, ProductQuantity = 1 });
            }
            InitializeRecipeContentList(true);
        }

        /// <summary>
        /// Removes an ingredient from a recipe(new or existing one)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveRecipeItemButton_Click(object sender, EventArgs e)
        {
            RecipeAndContentModel ingredient = (RecipeAndContentModel)SelectedRecipeContentListbox.SelectedItem;

            if (ingredient.ProductQuantity > 1)
            {
                SelectedRecipeContent[SelectedRecipeContent.IndexOf(ingredient)].ProductQuantity--;
            }
            else
            {
                SelectedRecipeContent.Remove(ingredient);
            }
            InitializeRecipeContentList();
        }

        /// <summary>
        /// Creates a new recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateRecipeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                RecipeModel newRecipeMdl = GlobalConfig.Connection.CreateRecipe(new RecipeModel { Name = RecipeNameTextBox.Text });

                RecipeContentModel recipeContent = new RecipeContentModel();

                foreach (var ingredient in SelectedRecipeContent)
                {
                    recipeContent.RecipeId = newRecipeMdl.Id;
                    recipeContent.ProductId = ingredient.ProductId;
                    recipeContent.ProductQuantity = ingredient.ProductQuantity;

                    GlobalConfig.Connection.CreateRecipeContent(recipeContent);
                }

                lastRecipeCreated = newRecipeMdl;
                InitializeRecipeList();
                ResetForm();
            }
            else
            {
                MessageBox.Show("You need to fill in a valid Recipe Name, and to select at least 2 'ingredients'!");
            }
        }

        /// <summary>
        /// Checks if the new recipe name has at leat 3 characters, and there are at least 2 ingredients or an ingredient with a quantity > 1
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            if (RecipeNameTextBox.Text.Count() > 2 && (SelectedRecipeContent.Count > 1 || SelectedRecipeContent[0].ProductQuantity > 1))
                return true;

            return false;
        }

        /// <summary>
        /// Deletes a recipe from the database(first its contents, then the recipe itself)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteRecipeButton_Click(object sender, EventArgs e)
        {
            RecipeModel recipe = (RecipeModel)RecipesListBox.SelectedItem;
            List<RecipeContentModel> contentToDelete = GlobalConfig.Connection.GetRecipe_Content(recipe);

            foreach (var ingredient in contentToDelete)
            {
                GlobalConfig.Connection.RemoveRecipeContent(ingredient);
            }

            GlobalConfig.Connection.DeleteRecipe(recipe);

            InitializeRecipeList();
            InitializeRecipeContentList();
            ResetForm();
        }

        /// <summary>
        /// Updates the selected recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateRecipeButton_Click(object sender, EventArgs e)
        {
            if (RecipesListBox.SelectedItem != null && RecipeNameTextBox.Text.Count() > 2)
            {
                //Update recipe name
                RecipeModel newRecipeModel = new RecipeModel
                {
                    Id = ((RecipeModel)RecipesListBox.SelectedItem).Id,
                    Name = RecipeNameTextBox.Text
                };
                GlobalConfig.Connection.UpdateRecipeModel(newRecipeModel);

                //Update the recipeContent
                List<RecipeAndContentModel> ExistingRecipeContent = GlobalConfig.Connection.GetRecipeAndContent((RecipeModel)RecipesListBox.SelectedItem);

                //Check and add new entries
                AddNewIngredientsToRecipe(IngredientsToAdd(ExistingRecipeContent));

                //Check and remove old entries
                RemoveOldIngredientsToRecipe(IngredientsToRemove(ExistingRecipeContent));

                //Check and update ingredient quantities
                UpdateIngredientsQuantitiesToRecipe(GetIngredientsWithDifferentQty(ExistingRecipeContent));

                InitializeRecipeList();
                InitializeRecipeContentList();
                ResetForm();
            }
        }

        /// <summary>
        /// Updates(in the database) the ingredients with modified quantities
        /// </summary>
        /// <param name="ingredientsToUpdate"></param>
        private void UpdateIngredientsQuantitiesToRecipe(List<RecipeContentModel> ingredientsToUpdate)
        {
            foreach (RecipeContentModel ingredient in ingredientsToUpdate)
            {
                GlobalConfig.Connection.UpdateRecipeContentModel(ingredient);
            }
        }

        /// <summary>
        /// Removes ingredients from the existing(saved in the database) recipe
        /// </summary>
        /// <param name="ingredientsToRemove"></param>
        private void RemoveOldIngredientsToRecipe(List<RecipeContentModel> ingredientsToRemove)
        {
            foreach (RecipeContentModel ingredient in ingredientsToRemove)
            {
                GlobalConfig.Connection.RemoveRecipeContent(ingredient);
            }
        }

        /// <summary>
        /// Adds new ingredients to the selected recipe
        /// </summary>
        /// <param name="ingredientsToAdd"></param>
        private void AddNewIngredientsToRecipe(List<RecipeContentModel> ingredientsToAdd)
        {
            foreach (RecipeContentModel ingredient in ingredientsToAdd)
            {
                GlobalConfig.Connection.CreateRecipeContent(ingredient);
            }
        }

        /// <summary>
        /// Checks for new ingredients to add in the selected recipe
        /// </summary>
        /// <param name="savedRecipe"></param>
        /// <returns>List with new ingredients to add</returns>
        List<RecipeContentModel> IngredientsToAdd(List<RecipeAndContentModel> savedRecipe)
        {
            List<RecipeAndContentModel> Differences = new List<RecipeAndContentModel>();

            foreach (var item in SelectedRecipeContent)
            {
                if (savedRecipe.Where(c => c.ProductId == item.ProductId).Count() == 0)
                    Differences.Add(item);
            }

            List<RecipeContentModel> output = new List<RecipeContentModel>();
            foreach (var item in Differences)
            {
                output.Add(new RecipeContentModel { ProductId = item.ProductId, RecipeId = savedRecipe[0].RecipeId, ProductQuantity = item.ProductQuantity });
            }

            return output;
        }

        /// <summary>
        /// Checks for ingredients to remove from the selected recipe
        /// </summary>
        /// <param name="savedRecipe"></param>
        /// <returns>List with ingredients to remove</returns>
        List<RecipeContentModel> IngredientsToRemove(List<RecipeAndContentModel> savedRecipe)
        {
            List<RecipeAndContentModel> Differences = new List<RecipeAndContentModel>();

            foreach (var item in savedRecipe)
            {
                if (SelectedRecipeContent.Where(c => c.ProductId == item.ProductId).Count() == 0)
                    Differences.Add(item);
            }

            List<RecipeContentModel> Output = new List<RecipeContentModel>();
            foreach (var item in Differences)
            {
                Output.Add(new RecipeContentModel { ProductId = item.ProductId, RecipeId = savedRecipe[0].RecipeId, ProductQuantity = item.ProductQuantity });
            }

            return Output;
        }

        /// <summary>
        /// Checks for items with a modified quantity to update in the selected recipe
        /// </summary>
        /// <param name="savedRecipe"></param>
        /// <returns>List of ingredients to update quantity for</returns>
        private List<RecipeContentModel> GetIngredientsWithDifferentQty(List<RecipeAndContentModel> savedRecipe)
        {
            List<RecipeAndContentModel> CommonIngredients = new List<RecipeAndContentModel>();

            foreach (var item in savedRecipe)
            {
                RecipeAndContentModel selectedIngredient = SelectedRecipeContent.Where(c => c.ProductId == item.ProductId).FirstOrDefault();
                RecipeAndContentModel savedIngredient = savedRecipe.Where(c => c.ProductId == item.ProductId).FirstOrDefault();

                if (selectedIngredient != null && selectedIngredient.ProductQuantity != savedIngredient.ProductQuantity)
                    CommonIngredients.Add(selectedIngredient);
            }
            List<RecipeContentModel> Output = new List<RecipeContentModel>();
            foreach (var item in CommonIngredients)
            {
                Output.Add(new RecipeContentModel { ProductId = item.ProductId, RecipeId = savedRecipe[0].RecipeId, ProductQuantity = item.ProductQuantity });
            }

            return Output;
        }

        /// <summary>
        /// Clears the form elements and deselects listboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearRecipeContentList();
            ResetForm();
        }
    }
}
