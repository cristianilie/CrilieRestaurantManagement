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
    public partial class ProductRecipeForm : Form
    {
        public List<RecipeModel> RecipesList { get; set; } = GlobalConfig.Connection.GetRecipes_All();
        public List<ProductModel> ProductsList { get; set; } = GlobalConfig.Connection.GetProducts_All();
        public List<RecipeAndContentModel> SelectedRecipeContent { get; set; } = new List<RecipeAndContentModel>();
        
        private IRecipeRequester callingForm;

        private RecipeModel lastRecipeCreated = new RecipeModel();

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form
        /// </summary>
        /// <param name="caller">Parameter used to call this form and request data by forms that implement IRecipeRequester interface</param>
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
        /// <parameter see cref="refresh">default parameter, used to refresh the recipe content listbox, when RecipesListBox.SelectedItem/Index are null/-1 </parameter>
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
        /// Exits the form and sends back to the calling form, the last recipe created
        /// </summary>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            callingForm.RecipeComplete(lastRecipeCreated);
            this.Close();
        }

        /// <summary>
        /// When the "selected recipe" changes, the "recipe content listbox" gets initialized with the current "selected recipe"
        /// </summary>
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
        private void SelectedRecipeContentListbox_Format(object sender, ListControlConvertEventArgs e)
        {
            RecipeAndContentModel ingredient = ((RecipeAndContentModel)e.ListItem);

            e.Value = $"({ingredient.ProductQuantity}) {ingredient.ProductName}";
        }

        /// <summary>
        /// Adds an ingredient to a recipe(new or existing one)
        /// </summary>
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
                SelectedRecipeContent.Add(new RecipeAndContentModel { 
                                                                        ProductId = p.Id, 
                                                                        ProductName = p.Name, 
                                                                        ProductQuantity = 1 
                                                                     });
            }
            InitializeRecipeContentList(true);
        }

        /// <summary>
        /// Removes an ingredient from a recipe(new or existing one)
        /// </summary>
        private void RemoveRecipeItemButton_Click(object sender, EventArgs e)
        {
            RecipeAndContentModel ingredient = (RecipeAndContentModel)SelectedRecipeContentListbox.SelectedItem;

            if (ingredient.ProductQuantity > 1)
                SelectedRecipeContent[SelectedRecipeContent.IndexOf(ingredient)].ProductQuantity--;
            else
                SelectedRecipeContent.Remove(ingredient);

            InitializeRecipeContentList();
        }

        /// <summary>
        /// Creates a new recipe model
        /// </summary>
        private void CreateRecipeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                RecipeModel newRecipeMdl = GlobalConfig.Connection.CreateRecipe(new RecipeModel { Name = RecipeNameTextBox.Text });

                RecipeContentModel recipeContent;

                foreach (var ingredient in SelectedRecipeContent)
                {
                    recipeContent = new RecipeContentModel
                    {
                        RecipeId = newRecipeMdl.Id,
                        ProductId = ingredient.ProductId,
                        ProductQuantity = ingredient.ProductQuantity
                    };

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
        private bool ValidateForm()
        {
            if (RecipeNameTextBox.Text.Count() > 2 && (SelectedRecipeContent.Count > 1 || SelectedRecipeContent[0].ProductQuantity > 1))
                return true;

            return false;
        }

        /// <summary>
        /// Deletes a recipe from the database(first its contents, then the recipe itself)
        /// </summary>
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
        private void UpdateRecipeButton_Click(object sender, EventArgs e)
        {
            if (RecipesListBox.SelectedItem != null && RecipeNameTextBox.Text.Count() > 2)
            {
                RecipeModel newRecipeModel = new RecipeModel
                {
                    Id = ((RecipeModel)RecipesListBox.SelectedItem).Id,
                    Name = RecipeNameTextBox.Text
                };
                GlobalConfig.Connection.UpdateRecipeModel(newRecipeModel);

                List<RecipeAndContentModel> ExistingRecipeContent = GlobalConfig.Connection.GetRecipeAndContent((RecipeModel)RecipesListBox.SelectedItem);

                RMS_Logic.RecipeLogic.AddNewIngredientsToRecipe(RMS_Logic.RecipeLogic.IngredientsToAdd(ExistingRecipeContent, SelectedRecipeContent));
                RMS_Logic.RecipeLogic.RemoveOldIngredientsToRecipe(RMS_Logic.RecipeLogic.IngredientsToRemove(ExistingRecipeContent, SelectedRecipeContent));
                RMS_Logic.RecipeLogic.UpdateIngredientsQuantitiesToRecipe(RMS_Logic.RecipeLogic.GetIngredientsWithDifferentQty(ExistingRecipeContent, SelectedRecipeContent));

                InitializeRecipeList();
                InitializeRecipeContentList();
                ResetForm();
            }
        }

        /// <summary>
        /// Clears the form elements and deselects listboxes
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearRecipeContentList();
            ResetForm();
        }
        
    }
}
