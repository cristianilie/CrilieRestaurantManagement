using System.Collections.Generic;

namespace RMLibrary.Models
{
    public class SalesOrderModel : OrderModel
    {
        public TableModel TableId { get; set; }

        public Customer CustomerId { get; set; }



    }
}