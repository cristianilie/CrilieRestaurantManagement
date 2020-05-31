using RMLibrary.Models;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class CustomerManagementLogic
    {
        public bool CheckIfCustomerNameExists(string firstName, string lastName, CustomerModel selectedCustomer)
        {
            if (selectedCustomer != null)
            {
                return !(GlobalConfig.Connection.GetCustomers_All()
                                                .Count(c => (c.FirstName.ToLower() == firstName.ToLower() || c.LastName.ToLower() == lastName.ToLower()) && c.Id == selectedCustomer.Id) > 0);
            }
            return GlobalConfig.Connection.GetCustomers_All()
                                          .Count(c => c.FirstName.ToLower() == firstName.ToLower() && c.LastName.ToLower() == lastName.ToLower()) > 0;
        }
    }
}