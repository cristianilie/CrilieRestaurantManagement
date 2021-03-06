﻿using RMLibrary;
using RMLibrary.Models;
using RMLibrary.RMS_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class TaxManagementForm : Form
    {
        public List<TaxModel> TaxList { get; set; }

        /// <summary>
        /// Default Contructor
        /// </summary>
        public TaxManagementForm()
        {
            InitializeComponent();
            InitializeTaxList();
        }

        /// <summary>
        /// Creates a new tax entry in the Tax database table
        /// </summary>
        private void CreateTaxButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                TaxModel tax = new TaxModel
                {
                    Name = TaxNameTextBox.Text,
                    Percent = int.Parse(TaxPercentTextBox.Text),
                    DefaultSelectedTax = IsDefaultTaxCheckBox.Checked ? true : false
                };

                if (tax.DefaultSelectedTax)
                    RMS_Logic.TaxLogic.UncheckPreviousDefaultTax();

                GlobalConfig.Connection.CreateTax(tax);
                InitializeTaxList();
            }
        }
        
        /// <summary>
        /// Validates if the form textboxes are least  2 and 1 characters long, and the Tax wasn't already created
        /// </summary>
        private bool ValidateForm()
        {
            if (TaxNameTextBox.Text.Count() > 1 && TaxPercentTextBox.Text.Count() > 0)
            {
                if (TaxList.Count(c => c.Name == TaxNameTextBox.Text && c.Percent == int.Parse(TaxPercentTextBox.Text)) > 0)
                {
                    MessageBox.Show("Tax already exists");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Tax Name should have at least 2 characters / Tax Percent should have at least 1 number!");
            }
            return false;
        }

        /// <summary>
        /// Initializes the customers list, and connects it with the customers listbox
        /// </summary>
        private void InitializeTaxList()
        {
            TaxList = GlobalConfig.Connection.GetTaxes_All();

            TaxesListBox.DataSource = null;
            TaxesListBox.DisplayMember = "Name";
            TaxesListBox.DataSource = TaxList;

            ResetForm();
        }

        /// <summary>
        /// Resets the form elements/selected items and clears the related textboxes
        /// </summary>
        private void ResetForm()
        {
            TaxesListBox.ClearSelected();
            TaxesListBox.SelectedItem = null;
            TaxNameTextBox.Text = "";
            TaxPercentTextBox.Text = "";
            IsDefaultTaxCheckBox.Checked = false;
        }

        /// <summary>
        /// When the TaxesListbox selected item changes, it initializes the Tax related textboxes, with the selected item(tax)'s properties
        /// </summary>
        private void TaxesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaxModel selectedTax = (TaxModel)TaxesListBox.SelectedItem;
            if (selectedTax != null)
            {
                TaxNameTextBox.Text = selectedTax.Name;
                TaxPercentTextBox.Text = selectedTax.Percent.ToString();
                IsDefaultTaxCheckBox.Checked = selectedTax.DefaultSelectedTax;
            }
        }

        /// <summary>
        /// Updates the database entry for the selected Tax
        /// </summary>
        private void UpdateTaxButton_Click(object sender, EventArgs e)
        {
            TaxModel selectedTax = (TaxModel)TaxesListBox.SelectedItem;
            if (selectedTax != null)
            {
                if (IsDefaultTaxCheckBox.Checked)
                    RMS_Logic.TaxLogic.UncheckPreviousDefaultTax();

                selectedTax.Name = TaxNameTextBox.Text;
                selectedTax.Percent = int.Parse(TaxPercentTextBox.Text);
                selectedTax.DefaultSelectedTax = IsDefaultTaxCheckBox.Checked;

                GlobalConfig.Connection.UpdateTaxModel(selectedTax);
                InitializeTaxList();
            }
        }


        /// <summary>
        /// Clears the textboxes and other selected fields
        /// </summary>
        private void ClearTaxTextBoxesButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
