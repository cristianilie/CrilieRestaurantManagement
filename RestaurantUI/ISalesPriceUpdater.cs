using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    public interface ISalesPriceUpdater
    {
        void SalesPriceUpdateComplete(ProductModel model);
    }
}
