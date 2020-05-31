using RMLibrary.Models;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class ProductManagementLogic
    {
        /// <summary>
        /// Retrieves the selected product's category, or "null" if the product isn't associated with a category
        /// </summary>
        public ProductCategoryModel GetExistingProductCategory(ProductModel selectedProduct)
        {
            return GlobalConfig.Connection.GetProductCategories_All().Where(c => c.ProductId == selectedProduct.Id)
                                              .FirstOrDefault();
        }

        /// <summary>
        /// Checks if the product name already exists
        /// </summary>
        public bool CheckIfProductNameExists(string productName, int productId)
        {
            if (GlobalConfig.Connection.GetProducts_All().Where(p => p.Name.ToLower() == productName.ToLower() && p.Id == productId).Count() > 0)
                return false;// because we are updating the existing product
            else
                return GlobalConfig.Connection.GetProducts_All().Where(p => p.Name.ToLower() == productName.ToLower()).Count() > 0;
        }

    }
}