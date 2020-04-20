namespace RMLibrary.Models
{
    /// <summary>
    /// Represents the product sales price
    /// </summary>
    public class SalesPriceModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal SalesPrice { get; set; }

        public bool CurrentlyActivePrice { get; set; }
    }
}