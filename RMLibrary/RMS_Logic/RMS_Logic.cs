using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary.RMS_Logic
{
    public static class RMS_Logic
    {
        public static CategoryManagementLogic CategoryLogic { get; set; } = new CategoryManagementLogic();

        public static CompanyManagementLogic CompanyLogic { get; set; } = new CompanyManagementLogic();

        public static CustomerManagementLogic CustomerLogic { get; set; } = new CustomerManagementLogic();

        public static SalesManagementLogic SalesLogic { get; set; } = new SalesManagementLogic();

        public static PurchasingManagementLogic PurchasingLogic { get; set; } = new PurchasingManagementLogic();

        public static PaymentTermManagementLogic PaymentTermLogic { get; set; } = new PaymentTermManagementLogic();

        public static ProductManagementLogic ProductLogic { get; set; } = new ProductManagementLogic();

        public static ProductRecipeManagementLogic RecipeLogic { get; set; } = new ProductRecipeManagementLogic();

        public static SalesPriceManagementLogic SalesPriceLogic { get; set; } = new SalesPriceManagementLogic();

        public static SearchPurchaseDocumentLogic SearchPurchaseDocumentLogic { get; set; } = new SearchPurchaseDocumentLogic();

        public static SelectProductLogic SelectProduct { get; set; } = new SelectProductLogic();

        public static TableManagementLogic TableLogic { get; set; } = new TableManagementLogic();

        public static TaxManagementLogic TaxLogic { get; set; } = new TaxManagementLogic();





    }
}
