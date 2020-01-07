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
    public partial class CompanyManagementForm : Form
    {
        public List<CompanyModel> CompaniesList { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyManagementForm()
        {
            InitializeComponent();
            InitializeCompaniesList();
        }

        /// <summary>
        /// Creates a new Company entry in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCompanyButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                CompanyModel company = new CompanyModel { Name = CompanyNameTextBox.Text, Data = CompanyDataTextBox.Text, Adress = CompanyAdressTextBox.Text };
                GlobalConfig.Connection.CreateCompany(company);
                InitializeCompaniesList();
            }
        }

        /// <summary>
        /// Validates if the form textboxes contain at least 5 characters long, and the Company Name and Data
        /// doesnt already exists
        /// </summary>
        /// <returns></returns>
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
        }

        /// <summary>
        /// When the CompaniesListBox, selected item changes, it initializes the company related textboxes, with the selected item(company)'s properties
        /// ..so we can edit them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCompanyButton_Click(object sender, EventArgs e)
        {
            CompanyModel selectedCompany = (CompanyModel)CompaniesListBox.SelectedItem;
            if (selectedCompany != null && ValidateForm())
            {
                selectedCompany.Name = CompanyNameTextBox.Text;
                selectedCompany.Data = CompanyDataTextBox.Text;
                selectedCompany.Adress = CompanyAdressTextBox.Text;

                GlobalConfig.Connection.UpdateCompanyModel(selectedCompany);
            }
            InitializeCompaniesList();
        }

        /// <summary>
        /// Clears the form's textboxes and other selected elements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearCompanyTextBoxesButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
