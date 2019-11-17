namespace RMLibrary.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }

        public ProductModel ProductId { get; set; }

        public int ProductQuantity { get; set; }


    }
}