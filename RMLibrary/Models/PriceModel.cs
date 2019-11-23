namespace RMLibrary.Models
{
    /// <summary>
    /// Represents the product prices
    /// Cost = buying + taxes price
    /// SalesPrice = cost + taxes + profit margin; Calculated to gain profit from sales.
    /// </summary>
    public class PriceModel
    {
        public int Id { get; set; }

        public ProductModel ProductId { get; set; }

        public decimal Cost { get; set; }

        public decimal SalesPrice { get; set; }
    }
}