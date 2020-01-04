namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a category a product belongs to
    /// Made so we can easily filter the product lists when selling
    /// </summary>
    public class ProductCategoryModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }
    }
}