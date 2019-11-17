using System.Collections.Generic;

namespace RMLibrary.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public List<OrderProductModel> MyProperty { get; set; }

        public TableModel TableId { get; set; }

        public OrderStatus Status { get; set; }

        public CustomerAdress AdressId { get; set; }

        public Customer CustomerId { get; set; }

    }
}