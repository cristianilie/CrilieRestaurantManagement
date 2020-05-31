using RMLibrary.Models;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class CompanyManagementLogic
    {
        public bool CheckIfCompanyNameExists(string companyName, string companyData, CompanyModel selectedCompany)
        {
            if (selectedCompany != null)
            {
                return !(GlobalConfig.Connection.GetCompanies_All()
                                                .Where(c => (c.Name.ToLower() == companyName.ToLower() || c.Data.ToLower() == companyData.ToLower()) && c.Id == selectedCompany.Id)
                                                .Count() > 0);
            }

            return GlobalConfig.Connection.GetCompanies_All()
                                          .Where(c => c.Name.ToLower() == companyName.ToLower() || c.Data.ToLower() == companyData.ToLower())
                                          .Count() > 0;
        }
    }
}