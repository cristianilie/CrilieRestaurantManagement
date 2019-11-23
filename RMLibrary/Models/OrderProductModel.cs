namespace RMLibrary.Models
{
    /// <summary>
    /// Database mapping for the list of products ordered(sales/purchase)
    /// </summary>
    public class OrderProductModel
    {
        public int Id { get; set; }

        public ProductModel ProductId { get; set; }

        public OrderModel OrderId { get; set; }

        public int OrderedQuantity { get; set; }

        public TaxModel TaxId { get; set; }
        
    }
}