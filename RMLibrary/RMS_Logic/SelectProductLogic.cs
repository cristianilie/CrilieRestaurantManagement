using RMLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class SelectProductLogic
    {
        /// <summary>
        /// Returns a list of products whose names contain the searched text
        /// </summary>
        /// <param name="searchedProductName">The searched text</param>
        public List<ProductModel> GetMatchingProducts(string searchedProductName)
        {
            return searchedProductName == "" || searchedProductName == " " ?
                                 GlobalConfig.Connection.GetProducts_All() :
                                 GlobalConfig.Connection.GetProducts_All().Where(p => p.Name.ToLower().Contains(searchedProductName.ToLower())).ToList();
        }

    }
}