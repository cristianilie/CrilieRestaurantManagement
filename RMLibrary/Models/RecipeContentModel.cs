using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a way to asociate one ot more products with a recipe
    /// </summary>
    public class RecipeContentModel
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

    }
}
