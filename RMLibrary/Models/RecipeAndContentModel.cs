using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary.Models
{
    /// <summary>
    /// Class used to retrieve a combined model from product, recipe and recipe content
    /// </summary>
    public class RecipeAndContentModel
    {
        public string RecipetName { get; set; }
        public int RecipeId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
