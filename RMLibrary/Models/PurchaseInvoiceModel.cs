using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary.Models
{
    public class PurchaseInvoiceModel: PurchaseOrderModel
    {

        public int RelatedPurchaseOrderId { get; set; }

    }
}
