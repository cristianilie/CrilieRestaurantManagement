namespace RMLibrary.Models
{
    /// <summary>
    /// Represents an entity(food/drink/delivery tax) we are selling in exchange for money
    /// </summary>
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// If not null, represents the product components
        /// </summary>
        public RecipeModel RecipeId { get; set; }

    }
}