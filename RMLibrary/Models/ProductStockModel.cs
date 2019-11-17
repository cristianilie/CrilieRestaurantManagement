namespace RMLibrary.Models
{
    public class ProductStockModel
    {
        public int Id { get; set; }

        public ProductModel ProductId { get; set; }

        public int Quantity { get; set; }

        public int BookedQuantity { get; set; }

        public int AvailableQuantity { get; set; }
    }
}