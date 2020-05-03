using RMLibrary;
using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class CompanyManagementForm : Form
    {
        private ICompanyRequester callingForm;
        public List<CompanyModel> CompaniesList { get; set; }

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form or uses the null default parameter if its not called by a form
        /// that doesnt implements the ICompanyRequester interface
        /// </summary>
        public CompanyManagementForm(ICompanyRequester caller = null)
        {
            InitializeComponent();
            InitializeCompaniesList();

            if (caller != null)
                callingForm = caller;
        }

        /// <summary>
        /// Creates a new Company entry in the database
        /// </summary>
        private void CreateCompanyButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                CompanyModel company = new CompanyModel { 
                    Name = CompanyNameTextBox.Text, 
                    Data = CompanyDataTextBox.Text, 
                    Adress = CompanyAdressTextBox.Text, 
                    DeliveryAdress = DeliveryAdressTextBox.Text 
                };
                GlobalConfig.Connection.CreateCompany(company);
                InitializeCompaniesList();
            }
        }

        /// <summary>
        /// Validates if the form textboxes contain at least 5 characters long, and the Company Name and Data
        /// doesnt already exists
        /// </summary>
        /// <returns>true - if company details are valid and company name doesnt already exists in the database
        /// false - otherwise</returns>
        private bool ValidateForm()
        {
            if (CompanyNameTextBox.Text.Count() > 4 && CompanyDataTextBox.Text.Count() > 4 && CompanyAdressTextBox.Text.Count() > 4)
            {
                if (CompaniesList.Count(c => c.Name == CompanyNameTextBox.Text || c.Data == CompanyDataTextBox.Text) > 0)
                {
                    MessageBox.Show("Company Name/Data already exists");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Company Name/Data/Adress should have at least 5 characters each!");
            }
            return false;
        }

        /// <summary>
        /// Initializes the companies list, and connects it with the companies listbox
        /// </summary>
        private void InitializeCompaniesList()
        {
            CompaniesList = GlobalConfig.Connection.GetCompanies_All();

            CompaniesListBox.DataSource = null;
            CompaniesListBox.DisplayMember = "Name";
            CompaniesListBox.DataSource = CompaniesList;

            ResetForm();
        }

        /// <summary>
        /// Resets the form elements/selected items and clears the related textboxes
        /// </summary>
        private void ResetForm()
        {
            CompaniesListBox.ClearSelected();
            CompaniesListBox.SelectedItem = null;
            CompanyNameTextBox.Text = "";
            CompanyDataTextBox.Text = "";
            CompanyAdressTextBox.Text = "";
            DeliveryAdressTextBox.Text = "";
        }

        /// <summary>
        /// When the CompaniesListBox, selected item changes, it initializes the company related textboxes, with the selected item(company)'s properties
        /// </summary>
        private void CompaniesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyModel selectedCompany = (CompanyModel)CompaniesListBox.SelectedItem;
            if (selectedCompany != null)
            {
                CompanyNameTextBox.Text = selectedCompany.Name;
                CompanyDataTextBox.Text = selectedCompany.Data;
                CompanyAdressTextBox.Text = selectedCompany.Adress;
            }
        }

        /// <summary>
        /// Updates the selected company entry in the Company database table
        /// </summary>
        private void UpdateCompanyButton_Click(object sender, EventArgs e)
        {
            CompanyModel selectedCompany = (CompanyModel)CompaniesListBox.SelectedItem;
            if (selectedCompany != null && ValidateForm())
            {
                selectedCompany.Name = CompanyNameTextBox.Text;
                selectedCompany.Data = CompanyDataTextBox.Text;
                selectedCompany.Adress = CompanyAdressTextBox.Text;
                selectedCompany.DeliveryAdress = DeliveryAdressTextBox.Text;

                GlobalConfig.Connection.UpdateCompanyModel(selectedCompany);
            }
            InitializeCompaniesList();
        }

        /// <summary>
        /// Clears the form's textboxes and other selected elements
        /// </summary>
        private void ClearCompanyTextBoxesButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Select a company model and send the model back to the calling form
        /// </summary>
        private void SelectCompanyButton_Click(object sender, EventArgs e)
        {
            CompanyModel selectedCompany = (CompanyModel)CompaniesListBox.SelectedItem;

            if (selectedCompany != null)
            {
                callingForm.CompanySelected(selectedCompany);
                this.Close();
            }
        }
    }
}
