namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a Purchase Order - buying merchandise from our suppliers
    /// </summary>
    public class PurchaseOrderModel : OrderModel
    {
        public CompanyModel SuplierId { get; set; }
    }
}