using RMLibrary;
using RMLibrary.Models;
using RMLibrary.Models.Helpers;
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
    public partial class CreateNewSalesOrderForm : Form
    {
        public List<TableModel> TablesList { get; set; }

        public List<CustomerModel> CustomersList { get; set; }

        public List<CompanyModel> CompaniesList { get; set; }

        private TableModel deliveryMethodTable;

        private IDeliveryMethod deliveryMethod;


        private IDeliveryMethodRequester callingForm;

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form
        /// </summary>
        /// <param name="caller"></param>
        public CreateNewSalesOrderForm(IDeliveryMethodRequester caller)
        {
            callingForm = caller;
            InitializeComponent();
            InitializeLists();
        }

        /// <summary>
        /// Selects a table(in the restaurant) and sends the data to the calling form to open a new sales order
        /// associated with that table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectTableButton_Click(object sender, EventArgs e)
        {
            if (TablesListBox.SelectedItem != null)
            {
                deliveryMethodTable = (TableModel)TablesListBox.SelectedItem;
                callingForm.DeliveryMethodSelectionComplete(null,deliveryMethodTable);
                this.Close();
            }
        }

        /// <summary>
        /// Initializes the lists with the delivery methods
        /// </summary>
        private void InitializeLists()
        {
            TablesList = GlobalConfig.Connection.GetTables_All();
            CustomersList = GlobalConfig.Connection.GetCustomers_All();
            CompaniesList = GlobalConfig.Connection.GetCompanies_All();

            TablesListBox.DataSource = null;
            TablesListBox.DisplayMember = "Name";
            TablesListBox.DataSource = TablesList;

            CustomersListBox.DataSource = null;
            CustomersListBox.DisplayMember = "Name";
            CustomersListBox.DataSource = CustomersList;

            CompaniesListBox.DataSource = null;
            CompaniesListBox.DisplayMember = "Name";
            CompaniesListBox.DataSource = CompaniesList;

            ResetForm();
        }

        /// <summary>
        /// Resets the form elements/selected items 
        /// </summary>
        private void ResetForm()
        {
            TablesListBox.ClearSelected();
            TablesListBox.SelectedItem = null;

            CustomersListBox.ClearSelected();
            CustomersListBox.SelectedItem = null;

            CompaniesListBox.ClearSelected();
            CompaniesListBox.SelectedItem = null;
        }

        /// <summary>
        /// Selects a Customer  and sends the company info to the calling form
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCustomerButton_Click(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem != null)
            {
                deliveryMethod = (CustomerModel)CustomersListBox.SelectedItem;
                callingForm.DeliveryMethodSelectionComplete(deliveryMethod);
                this.Close();
            }
        }

        /// <summary>
        /// Selects a Company as customer and sends the company info to the calling form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCompanyButton_Click(object sender, EventArgs e)
        {
            if (CompaniesListBox.SelectedItem != null)
            {
                deliveryMethod = (CompanyModel)CompaniesListBox.SelectedItem;
                callingForm.DeliveryMethodSelectionComplete(deliveryMethod);
                this.Close();
            }
        }

        /// <summary>
        /// Calls the DeliveryMethodSelectionComplete method with no parameter(using the null default values) and closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            callingForm.DeliveryMethodSelectionComplete();
            this.Close();
        }
    }
}
