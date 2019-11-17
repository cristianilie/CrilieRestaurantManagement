namespace RMLibrary.Models
{
    public class ProductCategoryModel
    {
        public int Id { get; set; }

        public ProductModel ProductId { get; set; }

        public CategoryModel CategoryId { get; set; }
    }
}