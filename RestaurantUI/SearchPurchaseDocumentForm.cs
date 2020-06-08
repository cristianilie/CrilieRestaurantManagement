using RMLibrary;
using RMLibrary.Models;
using RMLibrary.RMS_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class SearchPurchaseDocumentForm : Form
    {
        public List<PurchaseOrderModel> PurchaseOrderList { get; set; }
        public List<PurchaseInvoiceModel> PurchaseInvoiceList { get; set; }
        public RequestedPurchasingDocument RequestedDocument { get; set; }

        private IDocumentRequester callingForm;

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form
        /// </summary>
        /// <param name="caller">Parameter used to call this form and request data by forms that implement IDocumentRequester interface</param>
        /// <param name="_documentType">The requested purchase document type(purchase order/invoice)</param>
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
        private void ChangeUIByDocType(RequestedPurchasingDocument documentType)
        {
            if (documentType == RequestedPurchasingDocument.PurchaseOrder)
            {
                DocumentLabel.Text = "Order";
                ActivePOCheckBox.Enabled = true;
                FinishedPOCheckBox.Enabled = true;
            }
            else
            {
                DocumentLabel.Text = "Invoice";
                ActivePOCheckBox.Enabled = false;
                FinishedPOCheckBox.Enabled = false;
            }
        }

        /// <summary>
        /// Finishes the document selection process and sents the data back to the calling form to display it
        /// And closes the current window
        /// </summary>
        private void SelectDocumentButton_Click(object sender, EventArgs e)
        {
            if (RequestedDocument == RequestedPurchasingDocument.PurchaseOrder)
                SelectPurchaseOrder();

            if (RequestedDocument == RequestedPurchasingDocument.PurchaseInvoice)
                SelectPurchaseInvoice();
        }

        /// <summary>
        /// Selects the desired purchase invoice, sends it to the requesting form and closes the current form
        /// </summary>
        private void SelectPurchaseInvoice()
        {
            if (POrderContentDataGridView.CurrentCell != null)
            {
                PurchaseInvoiceModel selectedDocument = (PurchaseInvoiceModel)(POrderContentDataGridView.Rows[POrderContentDataGridView.CurrentCell.RowIndex].DataBoundItem);

                if (selectedDocument != null)
                {
                    callingForm.DocumentSelected(RequestedDocument, null, selectedDocument);
                    this.Close();
                }
            }

        }

        /// <summary>
        /// Selects the desired purchase order, sends it to the requesting form and closes the current form
        /// </summary>
        private void SelectPurchaseOrder()
        {
            if (POrderContentDataGridView.CurrentCell != null)
            {
                PurchaseOrderModel selectedDocument = (PurchaseOrderModel)(POrderContentDataGridView.Rows[POrderContentDataGridView.CurrentCell.RowIndex].DataBoundItem);

                if (selectedDocument != null)
                {
                    callingForm.DocumentSelected(RequestedDocument, selectedDocument);
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Initializes the searched document list with documents matching the selected filters
        /// </summary>
        private void InitializeDocumentList()
        {
            if (RequestedDocument == RequestedPurchasingDocument.PurchaseOrder)
            {
                PurchaseOrderList = GlobalConfig.Connection.GetPurchaseOrders_All();
                PurchaseOrderList = RMS_Logic.SearchPurchaseDocumentLogic.
                                    FilterPurchaseOrder_ListBy(PurchaseOrderList, SearchProductTextBox.Text, FilterDocumentDateTimePicker.Value.Date);

                if (ActivePOCheckBox.Checked && !FinishedPOCheckBox.Checked)
                    PurchaseOrderList = RMS_Logic.SearchPurchaseDocumentLogic.FilterPurchaseOrderList_ByOrderStatus(PurchaseOrderList, OrderStatus.Active);

                if (!ActivePOCheckBox.Checked && FinishedPOCheckBox.Checked)
                    PurchaseOrderList = RMS_Logic.SearchPurchaseDocumentLogic.FilterPurchaseOrderList_ByOrderStatus(PurchaseOrderList, OrderStatus.Finished);

                POrderContentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                POrderContentDataGridView.DataSource = null;
                POrderContentDataGridView.AutoGenerateColumns = true;
                POrderContentDataGridView.DataSource = PurchaseOrderList;
            }
            else
            {
                PurchaseInvoiceList = GlobalConfig.Connection.GetPurchaseInvoices_All();
                PurchaseInvoiceList = RMS_Logic.SearchPurchaseDocumentLogic.
                                        FilterPurchaseInvoiceListBy(PurchaseInvoiceList, SearchProductTextBox.Text, FilterDocumentDateTimePicker.Value.Date);

                POrderContentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                POrderContentDataGridView.DataSource = null;
                POrderContentDataGridView.AutoGenerateColumns = true;
                POrderContentDataGridView.DataSource = PurchaseInvoiceList;
            }
        }



        /// <summary>
        /// Searches a document by vendor name and other active date filters
        /// </summary>
        private void SearchByVendorNameButton_Click(object sender, EventArgs e)
        {
            InitializeDocumentList();
        }

        /// <summary>
        /// Calcens the document selection process and closes the current window
        /// </summary>
        private void CancelSelectButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchDocument_Click(object sender, EventArgs e)
        {
            InitializeDocumentList();
        }
    }
}
