using RMLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class SalesPriceManagementLogic
    {
        /// <summary>
        /// Returns a list of prices associated with the selected product
        /// </summary>
        /// <returns>A list of sales prices associated with the selected product</returns>
        public List<SalesPriceModel> GetSelectedProductPrices(ProductModel selectedProduct, List<SalesPriceModel> PriceList_All)
        {

            List<SalesPriceModel> output = new List<SalesPriceModel>();

            if (selectedProduct != null && PriceList_All != null)
                output = PriceList_All.Where(p => p.ProductId == selectedProduct.Id).ToList();

            //selectedActivePrice = output.Where(q => q.CurrentlyActivePrice == true).FirstOrDefault();

            return output;
        }

        /// <summary>
        /// Searches for the current "active price", sets it to false and updates it into the database
        /// </summary>
        public void UncheckPreviousActivePrice(SalesPriceModel currentActivePrice)
        {
            if (currentActivePrice != null)
            {
                currentActivePrice.CurrentlyActivePrice = false;
                GlobalConfig.Connection.UpdateSalesPriceModel(currentActivePrice);
            }
        }

        /// <summary>
        /// Gets the current active sales price
        /// </summary>
        public SalesPriceModel GetProductActivePrice(int productId)
        {
            return GlobalConfig.Connection.GetProduct_SalesPrice_ByProductId(productId).Where(a => a.CurrentlyActivePrice == true).FirstOrDefault();
        }

        /// <summary>
        /// Checks if the price already exists for the selected product
        /// </summary>
        /// <returns>true if price exists/ false otherwise</returns>
        public bool CheckIfPriceAlreadyExists(decimal priceToCheck, int productId, bool isActivePrice)
        {
            return GlobalConfig.Connection.GetSalesPrices_All().Count(p => p.SalesPrice == priceToCheck &&
                                                                      p.ProductId == productId && 
                                                                      p.CurrentlyActivePrice  == isActivePrice) > 0;
        }
    }
}