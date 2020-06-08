using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class SearchPurchaseDocumentLogic
    {
        /// <summary>
        /// Initializes the Purchase Order List
        /// </summary>
        public List<PurchaseOrderModel> InitializePurchaseOrderList()
        {
            return GlobalConfig.Connection.GetPurchaseOrders_All();
        }

        /// <summary>
        /// Initializes the Purchase Invoice List
        /// </summary>
        public List<PurchaseInvoiceModel> InitializePurchaseInvoiceList()
        {
            return GlobalConfig.Connection.GetPurchaseInvoices_All();
        }

        /// <summary>
        /// Filters the Purchase Order list by the specified parameters/default parameter values
        /// </summary>
        public List<PurchaseOrderModel> FilterPurchaseOrder_ListBy(List<PurchaseOrderModel> PurchaseOrderList, string vendorName = "", DateTime documentDate = default(DateTime))
        {
            if (PurchaseOrderList == null)
                PurchaseOrderList = InitializePurchaseOrderList();

            if (vendorName != "")
                PurchaseOrderList = FilterPurchaseOrderByCompanyName(vendorName);

            if (documentDate != default(DateTime))
            {
                if (vendorName != "")
                    PurchaseOrderList = PurchaseOrderList.Where(c => c.PostingDate.Date >= documentDate.Date).ToList();
                else
                    PurchaseOrderList = FilterPurchaseOrderByDocumentDate(documentDate);
            }

            if (documentDate == default(DateTime) && vendorName == "")
                PurchaseOrderList = InitializePurchaseOrderList();

            return PurchaseOrderList;
        }

        /// <summary>
        /// Filters the purchase order list by order status
        /// </summary>
        public List<PurchaseOrderModel> FilterPurchaseOrderList_ByOrderStatus(List<PurchaseOrderModel> PurchaseOrderList, OrderStatus orderStatus)
        {
            return PurchaseOrderList.Where(o => o.Status == orderStatus).ToList();
        }

        /// <summary>
        /// Filters the Purchase Invoice list by the specified parameters/default parameter values
        /// </summary>
        public List<PurchaseInvoiceModel> FilterPurchaseInvoiceListBy(List<PurchaseInvoiceModel> PurchaseInvoiceList, string vendorName = "", DateTime documentDate = default(DateTime))
        {
            if (PurchaseInvoiceList == null)
                PurchaseInvoiceList = InitializePurchaseInvoiceList();

            if (vendorName != "")
                PurchaseInvoiceList = FilterPurchaseInvoiceByCompanyName(vendorName);

            if (documentDate != default(DateTime))
            {
                if (vendorName != "")
                    PurchaseInvoiceList = PurchaseInvoiceList.Where(c => c.PostingDate.Date >= documentDate.Date).ToList();
                else
                    PurchaseInvoiceList = FilterPurchaseInvoiceByDocumentDate(documentDate);
            }

            if (documentDate == default(DateTime) && vendorName == "")
                PurchaseInvoiceList = InitializePurchaseInvoiceList();

            return PurchaseInvoiceList;
        }

        /// <summary>
        /// Filter Purchase Order by supplier name
        /// </summary>
        public List<PurchaseOrderModel> FilterPurchaseOrderByCompanyName(string vendorName)
        {
            List<CompanyModel> company = GlobalConfig.Connection.GetCompanies_All().Where(q => q.Name.ToLower().Contains(vendorName.ToLower())).Distinct().ToList();
            List<PurchaseOrderModel> poByCompanyName = new List<PurchaseOrderModel>();

            foreach (var comp in company)
            {
                poByCompanyName.AddRange(GlobalConfig.Connection.GetPurchaseOrders_All().Where(c => c.SupplierId == comp.Id).ToList());
            }

            return poByCompanyName;
        }

        /// <summary>
        /// Filter Purchase Invoice by supplier name
        /// </summary>
        /// <returns>A list of purchase invoices, filtered by supplier/company name</returns>
        public List<PurchaseInvoiceModel> FilterPurchaseInvoiceByCompanyName(string vendorName)
        {
            List<CompanyModel> company = GlobalConfig.Connection.GetCompanies_All().Where(q => q.Name.ToLower().Contains(vendorName.ToLower())).Distinct().ToList();
            List<PurchaseInvoiceModel> invoicesByCompanyName = new List<PurchaseInvoiceModel>();

            foreach (var comp in company)
            {
                invoicesByCompanyName.AddRange(GlobalConfig.Connection.GetPurchaseInvoices_All().Where(c => c.SupplierId == comp.Id).ToList());
            }

            return invoicesByCompanyName;
        }

        /// <summary>
        /// Filter Purchase Order by document date
        /// </summary>
        /// <returns>A list of purchase orders, filtered by documentDate</returns>
        public List<PurchaseOrderModel> FilterPurchaseOrderByDocumentDate(DateTime documentDate)
        {
            List<PurchaseOrderModel> poByDocumentDate = new List<PurchaseOrderModel>();

            poByDocumentDate.AddRange(GlobalConfig.Connection.GetPurchaseOrders_All().Where(c => c.PostingDate.Date >= documentDate.Date).ToList());

            return poByDocumentDate;
        }

        /// <summary>
        /// Filter Purchase invoice by document date
        /// </summary>
        /// <returns>A list of purchase invoices, filtered by documentDate</returns>
        public List<PurchaseInvoiceModel> FilterPurchaseInvoiceByDocumentDate(DateTime documentDate)
        {
            List<PurchaseInvoiceModel> invoicesByDocumentDate = new List<PurchaseInvoiceModel>();

            invoicesByDocumentDate.AddRange(GlobalConfig.Connection.GetPurchaseInvoices_All().Where(c => c.PostingDate.Date >= documentDate.Date).ToList());

            return invoicesByDocumentDate;
        }
    }
}