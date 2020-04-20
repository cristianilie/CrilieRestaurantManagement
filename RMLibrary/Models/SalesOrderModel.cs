using System.Collections.Generic;

namespace RMLibrary.Models
{
    /// <summary>
    /// Represents a Sales order - a way to sell our products to our customers in the restaurant + home deliveries
    /// </summary>
    public class SalesOrderModel : OrderModel
    {
        public int TableId { get; set; }

        public int CustomerId { get; set; }

        public int CompanyId { get; set; }

        public string Name { get; set; }
    }
}