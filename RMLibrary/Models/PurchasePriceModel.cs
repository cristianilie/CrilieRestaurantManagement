using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary.Models
{
    public class PurchasePriceModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal PurchasePrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int PurchaseOrderId { get; set; }
    }
}
