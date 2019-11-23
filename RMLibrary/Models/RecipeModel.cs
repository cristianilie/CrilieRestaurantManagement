namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a way to create a more complex product/bundle/menu etc from products previously created
    /// </summary>
    public class RecipeModel
    {
        public int Id { get; set; }

        public ProductModel ProductId { get; set; }

        public int ProductQuantity { get; set; }


    }
}