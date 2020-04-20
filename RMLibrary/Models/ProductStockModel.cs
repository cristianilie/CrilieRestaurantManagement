namespace RMLibrary.Models
{
    /// <summary>
    /// Represents the way a product's stock is handled when the sales process occurs
    /// so we wont sell a product that's not available
    /// </summary>
    public class ProductStockModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int BookedQuantity { get; set; }

        public int AvailableQuantity { get; set; }
    }
}