﻿using RMLibrary.Models;
using RMLibrary.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    public interface IDeliveryMethodRequester
    {
        void DeliveryMethodSelectionComplete(IDeliveryMethod model = null, TableModel table = null);
    }
}
