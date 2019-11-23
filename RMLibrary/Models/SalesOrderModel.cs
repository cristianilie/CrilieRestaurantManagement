using System.Collections.Generic;

namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a Sales order - a way to sell our products to our customers in the restaurant + home deliveries
    /// </summary>
    public class SalesOrderModel : OrderModel
    {
        public TableModel TableId { get; set; }

        public CustomerModel CustomerId { get; set; }

    }
}