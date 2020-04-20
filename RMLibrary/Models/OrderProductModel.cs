    namespace RMLibrary.Models
{
    /// <summary>
    /// Database mapping for the list of products ordered(sales/purchase)
    /// </summary>
    public class OrderProductModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int OrderId { get; set; }

        public int OrderedQuantity { get; set; }

        public int TaxId { get; set; }
        
    }
}