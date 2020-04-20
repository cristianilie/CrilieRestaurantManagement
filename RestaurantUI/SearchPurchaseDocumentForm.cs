using RMLibrary;
using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class SearchPurchaseDocumentForm : Form
    {
        public List<PurchaseOrderModel> PurchaseOrderList { get; set; }
        public List<PurchaseInvoiceModel> PurchaseInvoiceList { get; set; }

        public List<CompanyModel> CompanyList { get; set; } = GlobalConfig.Connection.GetCompanies_All();

        public RequestedPurchasingDocument RequestedDocument { get; set; }

        private IDocumentRequester callingForm;

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="_documentType"></param>
        public SearchPurchaseDocumentForm(IDocumentRequester caller, RequestedPurchasingDocument _documentType)
        {
            InitializeComponent();
            RequestedDocument = _documentType;
            ChangeUIByDocType(RequestedDocument);
            InitializeDocumentList();

            callingForm = caller;
        }

        /// <summary>
        /// Changes the DocumentLabel text by the purchase document type we are searching for(Order/Invoice)
        /// </summary>
        /// <param name="docType"></param>
        private void ChangeUIByDocType(RequestedPurchasingDocument docType)
        {
            if (RequestedDocument == RequestedPurchasingDocument.PurchaseOrder)
            {
                DocumentLabel.Text = "Order";
            }
            else
            {
                DocumentLabel.Text = "Invoice";
            }
        }

        /// <summary>
        /// Finishes the document selection process and sents the data back to the calling form to display it
        /// And closes the current window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDocumentButton_Click(object sender, EventArgs e)
        {

                if (RequestedDocument == RequestedPurchasingDocument.PurchaseOrder)
                {
                    PurchaseOrderModel selectedDocument = (PurchaseOrderModel)(POrderContentDataGridView.Rows[POrderContentDataGridView.CurrentCell.RowIndex].DataBoundItem);
                   
                    if (selectedDocument!= null)
                    {
                        callingForm.DocumentSelected(RequestedDocument, selectedDocument);
                        this.Close();
                    }
                }

                if (RequestedDocument == RequestedPurchasingDocument.PurchaseInvoice)
                {
                    PurchaseInvoiceModel selectedDocument = (PurchaseInvoiceModel)(POrderContentDataGridView.Rows[POrderContentDataGridView.CurrentCell.RowIndex].DataBoundItem);

                    if (selectedDocument != null)
                    {
                        callingForm.DocumentSelected(RequestedDocument, null,selectedDocument);
                        this.Close();
                    }
                }
        }

        /// <summary>
        /// Initializes the Purchase Order List
        /// </summary>
        private void InitializePurchaseOrderList()
        {
            if (PurchaseOrderList == null || PurchaseOrderList.Count() == 0)
            {
                PurchaseOrderList = GlobalConfig.Connection.GetPurchaseOrders_All();
            }
            else
            {
                PurchaseOrderList.Clear();
                PurchaseOrderList = GlobalConfig.Connection.GetPurchaseOrders_All();
            }
        }

        /// <summary>
        /// Initializes the Purchase Invoice List
        /// </summary>
        private void InitializePurchaseInvoiceList()
        {
            if (PurchaseInvoiceList == null || PurchaseInvoiceList.Count() == 0)
            {
                PurchaseInvoiceList = GlobalConfig.Connection.GetPurchaseInvoices_All();
            }
            else
            {
                PurchaseInvoiceList.Clear();
                PurchaseInvoiceList = GlobalConfig.Connection.GetPurchaseInvoices_All();
            }
        }

        /// <summary>
        /// Filters the Purchase Order list by the specified parameters/default parameter values
        /// </summary>
        /// <param name="vendorName"></param>
        /// <param name="documentDate"></param>
        private void FilterPurchaseOrder_ListBy(string vendorName = "", DateTime documentDate = default(DateTime))
        {
            if (PurchaseOrderList == null)
                InitializePurchaseOrderList();

            if (vendorName != "")
            {
                PurchaseOrderList = FilterPurchaseOrderByCompanyName(vendorName);

                if (documentDate != default(DateTime))
                    PurchaseOrderList = FilterPurchaseOrderByDocumentDate(documentDate);
            }
            else if (documentDate != default(DateTime))
            {
                PurchaseOrderList = FilterPurchaseOrderByDocumentDate(documentDate);
            }
            else
            {
                InitializePurchaseOrderList();
            }
        }

        /// <summary>
        /// Filters the Purchase Invoice list by the specified parameters/default parameter values
        /// </summary>
        /// <param name="vendorName"></param>
        /// <param name="documentDate"></param>
        private void FilterPurchaseInvoiceListBy(string vendorName = "", DateTime documentDate = default(DateTime))
        {
            if (PurchaseInvoiceList == null)
                InitializePurchaseInvoiceList();

            if (vendorName != "")
            {
                PurchaseInvoiceList = FilterPurchaseInvoiceByCompanyName(vendorName);

                if (documentDate != default(DateTime))
                    PurchaseInvoiceList = FilterPurchaseInvoiceByDocumentDate(documentDate);
            }
            else if (documentDate != default(DateTime))
            {
                PurchaseInvoiceList = FilterPurchaseInvoiceByDocumentDate(documentDate);
            }
            else
            {
                InitializePurchaseInvoiceList();
            }
        }

        /// <summary>
        /// Filter Purchase Order by supplier name
        /// </summary>
        /// <param name="vendorName"></param>
        /// <returns></returns>
        private List<PurchaseOrderModel> FilterPurchaseOrderByCompanyName(string vendorName)
        {
            List<CompanyModel> company = CompanyList.Where(q => q.Name.ToLower().Contains(vendorName.ToLower())).Distinct().ToList();
            List<PurchaseOrderModel> poByCompanyName = new List<PurchaseOrderModel>();

            foreach (var comp in company)
            {
                poByCompanyName.AddRange(PurchaseOrderList.Where(c => c.SupplierId == comp.Id).ToList());
            }
            return poByCompanyName;
        }

        /// <summary>
        /// Filter Purchase Invoice by supplier name
        /// </summary>
        /// <param name="vendorName"></param>
        /// <returns></returns>
        private List<PurchaseInvoiceModel> FilterPurchaseInvoiceByCompanyName(string vendorName)
        {
            List<CompanyModel> company = CompanyList.Where(q => q.Name.ToLower().Contains(vendorName.ToLower())).Distinct().ToList();
            List<PurchaseInvoiceModel> invoicesByCompanyName = new List<PurchaseInvoiceModel>();

            foreach (var comp in company)
            {
                invoicesByCompanyName.AddRange(PurchaseInvoiceList.Where(c => c.SupplierId == comp.Id).ToList());
            }
            return invoicesByCompanyName;
        }

        /// <summary>
        /// Filter Purchase Order by document date
        /// </summary>
        /// <param name="documentDate"></param>
        /// <returns></returns>
        private List<PurchaseOrderModel> FilterPurchaseOrderByDocumentDate(DateTime documentDate)
        {
            List<PurchaseOrderModel> poByDocumentDate = new List<PurchaseOrderModel>();

            poByDocumentDate.AddRange(PurchaseOrderList.Where(c =>c.PostingDate.Date >= documentDate.Date).ToList());

            return poByDocumentDate;
        }

        /// <summary>
        /// Filter Purchase invoice by document date
        /// </summary>
        /// <param name="documentDate"></param>
        /// <returns></returns>
        private List<PurchaseInvoiceModel> FilterPurchaseInvoiceByDocumentDate(DateTime documentDate)
        {
            List<PurchaseInvoiceModel> invoicesByDocumentDate = new List<PurchaseInvoiceModel>();

            invoicesByDocumentDate.AddRange(PurchaseInvoiceList.Where(c => c.PostingDate.Date >= documentDate.Date).ToList());

            return invoicesByDocumentDate;
        }

        /// <summary>
        /// Initializes the searched document list with documents matching the selected filters
        /// </summary>
        private void InitializeDocumentList()
        {
            if (RequestedDocument == RequestedPurchasingDocument.PurchaseOrder)
            {
                InitializePurchaseOrderList();
                FilterPurchaseOrder_ListBy(SearchProductTextBox.Text, FilterDocumentDateTimePicker.Value.Date);

                POrderContentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                POrderContentDataGridView.DataSource = null;
                POrderContentDataGridView.AutoGenerateColumns = true;
                POrderContentDataGridView.DataSource = PurchaseOrderList;
            }
            else
            {
                InitializePurchaseInvoiceList();
                FilterPurchaseInvoiceListBy(SearchProductTextBox.Text, FilterDocumentDateTimePicker.Value.Date);

                POrderContentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                POrderContentDataGridView.DataSource = null;
                POrderContentDataGridView.AutoGenerateColumns = true;
                POrderContentDataGridView.DataSource = PurchaseInvoiceList;
            }
        }

        /// <summary>
        /// Searches a document by vendor name and other active date filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchByVendorNameButton_Click(object sender, EventArgs e)
        {
            InitializeDocumentList();
        }

        /// <summary>
        /// Calcens the document selection process and closes the current window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelSelectButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
