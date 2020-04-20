using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary.Models
{
    public class PaymentTermsModel
    {
        public int Id { get; set; }

        public int PaymentTerm_Days { get; set; }

        public bool IsDefaultPaymentTerm { get; set; }

    }
}
