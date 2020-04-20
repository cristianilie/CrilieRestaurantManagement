namespace RMLibrary.Models
{
    public enum OrderStatus
    {
        Active,
        Finished,
    }

    public enum PurchaseOrderState
    {
        NewPO_Added,
        NewEmptyPO_NotAdded,
        InvoicedPO
    }

    public enum RequestedPurchasingDocument
    {
        PurchaseOrder,
        PurchaseInvoice
    }
}