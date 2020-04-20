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
    public partial class CustomerManagementForm : Form
    {
        public List<CustomerModel> CustomerList { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerManagementForm()
        {
            InitializeComponent();
            InitializeCustomersList();
        }

        /// <summary>
        /// Validates if the form textboxes are least 2, 2 and 5 characters long, and the First and Last Name aren't already created
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            if (FirstNameTextBox.Text.Count() > 2 && LastNameTextBox.Text.Count() > 2 && DeliveryAdressTextBox.Text.Count() > 5)
            {
                if (CustomerList.Count(c => c.FirstName == FirstNameTextBox.Text && c.LastName == LastNameTextBox.Text) > 0)
                {
                    MessageBox.Show("Customer First and Last Name already exists");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("First & Last Nameshould have at least 2 characters each / Delivery Adress should have at least 5!");
            }
            return false;
        }

        /// <summary>
        /// Initializes the customers list, and connects it with the customers listbox
        /// </summary>
        private void InitializeCustomersList()
        {
            CustomerList = GlobalConfig.Connection.GetCustomers_All();

            CustomersListBox.DataSource = null;
            CustomersListBox.DisplayMember = "Name";
            CustomersListBox.DataSource = CustomerList;

            ResetForm();
        }

        /// <summary>
        /// Resets the form elements/selected items and clears the related textboxes
        /// </summary>
        private void ResetForm()
        {
            CustomersListBox.ClearSelected();
            CustomersListBox.SelectedItem = null;
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            DeliveryAdressTextBox.Text = "";
        }

        /// <summary>
        /// Creates a new customer entry in the Customer database table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCustomerButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                CustomerModel customer = new CustomerModel { 
                                                             FirstName = FirstNameTextBox.Text, 
                                                             LastName = LastNameTextBox.Text, 
                                                             DeliveryAdress = DeliveryAdressTextBox.Text 
                                                           };
                GlobalConfig.Connection.CreateCustomer(customer);
                InitializeCustomersList();
            }
        }

        /// <summary>
        /// When the CustomersListBox selected item changes, it initializes the customer related textboxes, with the selected item(customer)'s properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerModel selectedCustomer = (CustomerModel)CustomersListBox.SelectedItem;
            if (selectedCustomer != null)
            {
                FirstNameTextBox.Text = selectedCustomer.FirstName;
                LastNameTextBox.Text = selectedCustomer.LastName;
                DeliveryAdressTextBox.Text = selectedCustomer.DeliveryAdress;
            }
        }

        /// <summary>
        /// Updates the database entry for the selected Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerModel selectedCustomer = (CustomerModel)CustomersListBox.SelectedItem;
            if (selectedCustomer != null && ValidateForm())
            {
                selectedCustomer.FirstName = FirstNameTextBox.Text;
                selectedCustomer.LastName = LastNameTextBox.Text;
                selectedCustomer.DeliveryAdress = DeliveryAdressTextBox.Text;

                GlobalConfig.Connection.UpdateCustomerModel(selectedCustomer);
            }
            InitializeCustomersList();
        }
        
        /// <summary>
        /// Clears the textboxes and other selected fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearCustomerTextBoxesButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
