using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary.Models
{
    public class OrderTotal
    {
        public decimal Total { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal GrandTotal { get; set; }

        public static OrderTotal operator +(OrderTotal first, OrderTotal second)
        {
            OrderTotal output = new OrderTotal();
            output.Total = first.Total + second.Total;
            output.TaxTotal = first.TaxTotal + second.TaxTotal;
            output.GrandTotal = first.GrandTotal + second.GrandTotal;

            return output;
        }
    }
}
