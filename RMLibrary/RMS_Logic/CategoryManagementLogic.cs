using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary.RMS_Logic
{
    public class CategoryManagementLogic
    {

        /// <summary>
        /// Checks if a category name exists in the category list
        /// </summary>
        public bool CheckIfCategoryNameExists(string categoryName)
        {
            return GlobalConfig.Connection.GetCategories_All().Count(s => s.Name == categoryName) > 0;
        }
    }
}
