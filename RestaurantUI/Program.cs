﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RestaurantManagementForm());
            //Application.Run(new SalesPriceManagementForm());


        }
    }
}

//Icons(magnifying glass) made by<a href="https://www.flaticon.com/authors/freepik" title="Freepik"> Freepik</a> from<a href="https://www.flaticon.com/" title="Flaticon"> www.flaticon.com</a>
//<divIcons made by <a href="https://www.flaticon.com/authors/smashicons" title="Smashicons">Smashicons</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>
