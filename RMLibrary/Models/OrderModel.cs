using System.Collections.Generic;

namespace RMLibrary.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public List<OrderProductModel> OrderProductsList { get; set; }

        public OrderStatus Status { get; set; }


    }
}