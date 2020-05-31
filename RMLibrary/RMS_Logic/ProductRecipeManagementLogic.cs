using RMLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class ProductRecipeManagementLogic
    {

        /// <summary>
        /// Updates(in the database) the ingredients with modified quantities
        /// </summary>
        public void UpdateIngredientsQuantitiesToRecipe(List<RecipeContentModel> ingredientsToUpdate)
        {
            foreach (RecipeContentModel ingredient in ingredientsToUpdate)
            {
                GlobalConfig.Connection.UpdateRecipeContentModel(ingredient);
            }
        }

        /// <summary>
        /// Removes ingredients from the existing(saved in the database) recipe
        /// </summary>
        public void RemoveOldIngredientsToRecipe(List<RecipeContentModel> ingredientsToRemove)
        {
            foreach (RecipeContentModel ingredient in ingredientsToRemove)
            {
                GlobalConfig.Connection.RemoveRecipeContent(ingredient);
            }
        }

        /// <summary>
        /// Adds new ingredients to the selected recipe
        /// </summary>
        public void AddNewIngredientsToRecipe(List<RecipeContentModel> ingredientsToAdd)
        {
            foreach (RecipeContentModel ingredient in ingredientsToAdd)
            {
                GlobalConfig.Connection.CreateRecipeContent(ingredient);
            }
        }

        /// <summary>
        /// Checks for new ingredients to add in the selected recipe
        /// </summary>
        /// <returns>List with new ingredients to add</returns>
        public List<RecipeContentModel> IngredientsToAdd(List<RecipeAndContentModel> savedRecipe, List<RecipeAndContentModel> selectedRecipeContent)
        {
            List<RecipeAndContentModel> Differences = new List<RecipeAndContentModel>();


            foreach (RecipeAndContentModel item in selectedRecipeContent)
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
        public List<RecipeContentModel> IngredientsToRemove(List<RecipeAndContentModel> savedRecipe, List<RecipeAndContentModel> selectedRecipeContent)
        {
            List<RecipeAndContentModel> Differences = new List<RecipeAndContentModel>();

            foreach (var item in savedRecipe)
            {
                if (selectedRecipeContent.Where(c => c.ProductId == item.ProductId).Count() == 0)
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
        /// <returns>List of ingredients to update quantity for</returns>
        public List<RecipeContentModel> GetIngredientsWithDifferentQty(List<RecipeAndContentModel> savedRecipe, List<RecipeAndContentModel> selectedRecipeContent)
        {
            List<RecipeAndContentModel> CommonIngredients = new List<RecipeAndContentModel>();

            foreach (var item in savedRecipe)
            {
                RecipeAndContentModel selectedIngredient = selectedRecipeContent.Where(c => c.ProductId == item.ProductId).FirstOrDefault();
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
    }
}