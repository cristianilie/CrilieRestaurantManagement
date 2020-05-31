using RMLibrary.Models;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class TaxManagementLogic
    {
        /// <summary>
        /// Searches for the current "default selected tax", sets it to false and updates it into the database
        /// </summary>
        public void UncheckPreviousDefaultTax()
        {
            TaxModel previousDefaultTax = GlobalConfig.Connection.GetTaxes_All().Where(q => q.DefaultSelectedTax == true).FirstOrDefault();
            if (previousDefaultTax != null)
            {
                previousDefaultTax.DefaultSelectedTax = false;
                GlobalConfig.Connection.UpdateTaxModel(previousDefaultTax);
            }
        }
    }
}