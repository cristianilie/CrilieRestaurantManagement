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
    public partial class FinishSalesOrderPreviewForm : Form
    {
        private ISalesOrderPreviewer callingForm;
        SalesOrderModel salesOrder;
        List<OrderProductModel> SalesOrderContentList;
        List<SalesPriceModel> SalesPricesList;
        TaxModel taxToUse;

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="_salesOrder"></param>
        /// <param name="salesOrderContent"></param>
        /// <param name="_taxToUse"></param>
        public FinishSalesOrderPreviewForm(ISalesOrderPreviewer caller, SalesOrderModel _salesOrder, List<OrderProductModel> salesOrderContent, TaxModel _taxToUse)
        {
            InitializeComponent();

            callingForm = caller;
            salesOrder = _salesOrder;
            taxToUse = _taxToUse;
            DisplaySalesOrderContent(salesOrderContent);

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

            CalculateSalesOrderValue();
        }

        /// <summary>
        /// Calculates the sales order totals
        /// </summary>
        private void CalculateSalesOrderValue()
        {
            decimal soTotal = 0;
            decimal soTax = 0;
            decimal soGrandTotal = 0;
            SalesPricesList = GlobalConfig.Connection.GetSalesPrices_All().Where(p => p.CurrentlyActivePrice == true).ToList();

            for (int i = 0; i < SalesOrderContentList.Count; i++)
            {
                decimal productPrice = SalesPricesList.Where(p => p.ProductId == SalesOrderContentList[i].ProductId && p.CurrentlyActivePrice == true)
                                                  .Single().SalesPrice;

                soTotal += SalesOrderContentList[i].OrderedQuantity * productPrice;
                soTax += SalesOrderContentList[i].OrderedQuantity * (productPrice / 100 * (taxToUse.Percent));
                soGrandTotal = soTotal + soTax;
            }

            TotalAmountSOTextBox.Text = soTotal.ToString("0.## Lei");
            TaxTotalAmountSOTextBox.Text = soTax.ToString("0.## Lei");
            GrandTotalAmountSOTextBox.Text = soGrandTotal.ToString("0.## Lei");
        }

        /// <summary>
        /// Cancels the "sales order finishing" process, and closes the current window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Calls the SalesOrderComplete method, to mark the sales order as "finshed" and remove product quantities from stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesOrderContentListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            OrderProductModel soProduct = ((OrderProductModel)e.ListItem);

            e.Value = $"({soProduct.OrderedQuantity}) {soProduct.ProductName}";
        }
    }
}
