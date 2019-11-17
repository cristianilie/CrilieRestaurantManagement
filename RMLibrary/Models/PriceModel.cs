namespace RMLibrary.Models
{
    public class PriceModel
    {
        public int Id { get; set; }

        public ProductModel ProductId { get; set; }

        public decimal Cost { get; set; }

        public decimal SalesPrice { get; set; }
    }
}