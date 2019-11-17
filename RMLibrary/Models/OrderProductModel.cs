namespace RMLibrary.Models
{
    public class OrderProductModel
    {
        public int Id { get; set; }

        public ProductModel ProductId { get; set; }

        public int OrderedQuantity { get; set; }
        
    }
}