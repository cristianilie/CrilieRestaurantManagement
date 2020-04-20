using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    public interface IDocumentRequester
    {
        void DocumentSelected(RequestedPurchasingDocument _documentType, PurchaseOrderModel po_model = null, PurchaseInvoiceModel inv_model = null);

    }
}
