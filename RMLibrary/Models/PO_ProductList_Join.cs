﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary.Models
{
    public class PurchaseOrderDetails_Join
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal PurchasePrice { get; set; }

        public int TaxId { get; set; }

       // public int OrderId { get; set; }
    }
}
