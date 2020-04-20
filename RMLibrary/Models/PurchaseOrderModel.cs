using System;

namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a Purchase Order - buying merchandise from our suppliers
    /// </summary>
    public class PurchaseOrderModel : OrderModel
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public DateTime PostingDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime DocumentDate { get; set; }

    }
}