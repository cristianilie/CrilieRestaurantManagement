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
    public partial class FinishSalesOrderPreviewForm : Form
    {
        private ISalesOrderPreviewer callingForm;
        private SalesOrderModel salesOrder;
        private List<OrderProductModel> SalesOrderContentList;
        private TaxModel taxToUse;

        public OrderTotal SalesOrderTotal { get; set; }


        /// <summary>
        /// Overloaded constructor that recieves data from the calling form that will be used to preview the "bill"
        /// and finish the sale process for the current order
        /// </summary>
        public FinishSalesOrderPreviewForm(ISalesOrderPreviewer caller, SalesOrderModel _salesOrder, List<OrderProductModel> salesOrderContent, TaxModel _taxToUse)
        {
            InitializeComponent();

            callingForm = caller;
            salesOrder = _salesOrder;
            taxToUse = _taxToUse;
            DisplaySalesOrderContent(salesOrderContent);
            ToggleFinishOrder_Button(salesOrder);

            CustomerTextBox.Text = salesOrder.Name;
        }

        /// <summary>
        /// If the sales order has the "finished" status - it disables the "finish order" button/otherwise it enables it
        /// </summary>
        private void ToggleFinishOrder_Button(SalesOrderModel salesOrder)
        {
            if (salesOrder.Status == OrderStatus.Finished)
                FinishSalesOrderButton.Enabled = false;
            else
                FinishSalesOrderButton.Enabled = true;
        }

        /// <summary>
        /// Displays the sales order content and calls "CalculateSalesOrderValue" method to calculate the sales order totals
        /// </summary>
        /// <param name="_salesOrderContent"></param>
        private void DisplaySalesOrderContent(List<OrderProductModel> _salesOrderContent)
        {
            SalesOrderContentList = _salesOrderContent;

            SalesOrderContentListBox.DataSource = null;
            SalesOrderContentListBox.DisplayMember = "ProductName";
            SalesOrderContentListBox.DataSource = SalesOrderContentList;

            SalesOrderTotal = RMS_Logic.SalesLogic.CalculateSalesOrderTotal(taxToUse, SalesOrderContentList);
            DisplaySalesOrderTotals(SalesOrderTotal);
        }
        
        /// <summary>
        /// Display the sales order totals in their associated textboxes
        /// </summary>
        private void DisplaySalesOrderTotals(OrderTotal orderTotal)
        {
            TotalAmountSOTextBox.Text = orderTotal.Total.ToString("0.## Lei");
            TaxTotalAmountSOTextBox.Text = orderTotal.TaxTotal.ToString("0.## Lei");
            GrandTotalAmountSOTextBox.Text = orderTotal.GrandTotal.ToString("0.## Lei");
        }

        /// <summary>
        /// Cancels the "sales order finishing" process, and closes the current window
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Calls the SalesOrderComplete method, to mark the sales order as "finshed" and remove product quantities from stock
        /// </summary>
        private void FinishSalesOrderButton_Click(object sender, EventArgs e)
        {
            if (salesOrder != null)
            {
                callingForm.SalesOrderComplete(salesOrder);
                this.Close();
            }
        }
        
        /// <summary>
        /// Formats the sales order content listbox so that when an item's quantity is displayed left to its name
        /// </summary>
        private void SalesOrderContentListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            OrderProductModel soProduct = ((OrderProductModel)e.ListItem);

            e.Value = $"({soProduct.OrderedQuantity}) {soProduct.ProductName}";
        }
    }
}
