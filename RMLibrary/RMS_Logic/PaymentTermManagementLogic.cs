using RMLibrary.Models;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class PaymentTermManagementLogic
    {
        /// <summary>
        /// Unchecks the previous default payment term
        /// </summary>
        public void UncheckPreviousDefaultPaymentTerm()
        {
            PaymentTermsModel previousDefaultPT = GlobalConfig.Connection.GetPaymentTerms_All().Where(q => q.IsDefaultPaymentTerm == true).FirstOrDefault();

            if (previousDefaultPT != null)
            {
                previousDefaultPT.IsDefaultPaymentTerm = false;
                GlobalConfig.Connection.UpdatePaymentTermModel(previousDefaultPT);
            }
        }

        /// <summary>
        /// Check if a payment term(as number of days) already exists
        /// </summary>
        public bool CheckIfPaymentTermExists(int paymentTermDays, PaymentTermsModel selectedPaymentTerm)
        {
            if (selectedPaymentTerm != null)
            {
                return !(GlobalConfig.Connection.GetPaymentTerms_All().Where(t => t.PaymentTerm_Days == paymentTermDays && t.Id == selectedPaymentTerm.Id).Count() > 0);
            }
            return GlobalConfig.Connection.GetPaymentTerms_All().Where(t => t.PaymentTerm_Days == paymentTermDays).Count() > 0;
        }
    }
}