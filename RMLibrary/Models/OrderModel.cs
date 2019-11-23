using System.Collections.Generic;

namespace RMLibrary.Models
{
    /// <summary>
    /// Base class for sales and purchase orders
    /// </summary>
    public class OrderModel
    {
        public int Id { get; set; }

        public List<OrderProductModel> OrderProductsList { get; set; }

        public OrderStatus Status { get; set; }


    }
}