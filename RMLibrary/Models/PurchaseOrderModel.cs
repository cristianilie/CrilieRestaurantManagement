namespace RMLibrary.Models
{
    public class PurchaseOrderModel : OrderModel
    {

        public SupplierModel SuplierId { get; set; }

        public TaxModel TaxId { get; set; }
    }
}