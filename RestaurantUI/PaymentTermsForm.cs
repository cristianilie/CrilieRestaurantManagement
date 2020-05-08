﻿using RMLibrary;
using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class PaymentTermsForm : Form
    {
        private IPaymentTermRequester callingForm;
        public List<PaymentTermsModel> PaymentTermsList { get; set; }

        /// <summary>
        /// Overloaded constructor that recieves data from the calling form or uses a default value of null
        /// when the form is not linked with Sales/Purchasing modules
        /// </summary>
        public PaymentTermsForm(IPaymentTermRequester caller = null)
        {
            InitializeComponent();
            InitializePaymentTermList();

            if (caller != null)
                callingForm = caller;
        }

        /// <summary>
        /// Validates that the user has inserted a valid payment term number of days(integer)
        /// </summary>
        private bool ValidateForm()
        {
            string termTxt = PaymentTermTextBox.Text.Replace(" ", "");
            bool isParsable = false;

            if (termTxt.Count() > 0)
            {
                foreach (char c in termTxt.ToCharArray())
                {
                    if (!char.IsDigit(c))
                        return false;
                }

                isParsable = int.TryParse(termTxt, out int num);
            }
            else
            {
                MessageBox.Show("Please insert a valid Payment Term(number of days)");
            }

            return isParsable;
        }

        /// <summary>
        /// Check if a payment term(as number of days) already exists
        /// </summary>
        private bool CheckIfPaymentTermExists(int paymentTermDays)
        {
            return PaymentTermsList.Where(t => t.PaymentTerm_Days == paymentTermDays).Count() > 0;
        }

        /// <summary>
        /// Initializes the PaymentTerm list, and connects it with the PaymentTermsListBox
        /// </summary>
        private void InitializePaymentTermList()
        {
            PaymentTermsList = GlobalConfig.Connection.GetPaymentTerms_All();

            PaymentTermsListBox.DataSource = null;
            PaymentTermsListBox.DisplayMember = "PaymentTerm_Days";
            PaymentTermsListBox.DataSource = PaymentTermsList;

            ResetForm();
        }

        /// <summary>
        /// Resets the form elements/selected items and clears the related textboxes
        /// </summary>
        private void ResetForm()
        {
            PaymentTermsListBox.ClearSelected();
            PaymentTermsListBox.SelectedItem = null;
            PaymentTermTextBox.Text = "";
            IsDefaultPaymentTermCheckBox.Checked = false;
        }

        /// <summary>
        /// Creates a new PaymentTermsModel
        /// </summary>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PaymentTermsModel paymentTerm = new PaymentTermsModel
                {
                    PaymentTerm_Days = int.Parse(PaymentTermTextBox.Text),
                    IsDefaultPaymentTerm = IsDefaultPaymentTermCheckBox.Checked
                };

                if (paymentTerm.IsDefaultPaymentTerm)
                    UncheckPreviousDefaultPaymentTerm();

                if (!CheckIfPaymentTermExists(paymentTerm.PaymentTerm_Days))
                {
                    GlobalConfig.Connection.CreatePaymentTerm(paymentTerm);
                    InitializePaymentTermList();
                }
                else
                {
                    MessageBox.Show("Payment Term already exists!");
                }

            }
        }

        /// <summary>
        /// Unchecks the previous default payment term
        /// </summary>
        private void UncheckPreviousDefaultPaymentTerm()
        {
            PaymentTermsModel previousDefaultPT = PaymentTermsList.Where(q => q.IsDefaultPaymentTerm == true).FirstOrDefault();
            if (previousDefaultPT != null)
            {
                previousDefaultPT.IsDefaultPaymentTerm = false;
                GlobalConfig.Connection.UpdatePaymentTermModel(previousDefaultPT);
            }
        }

        /// <summary>
        /// Clears fields/resets selected items
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Updates a PaymentTermsModel's details 
        /// </summary>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            PaymentTermsModel selectedPaymentTerm = (PaymentTermsModel)PaymentTermsListBox.SelectedItem;
            if (selectedPaymentTerm != null)
            {
                if (IsDefaultPaymentTermCheckBox.Checked)
                    UncheckPreviousDefaultPaymentTerm();

                if (ValidateForm() && !CheckIfPaymentTermExists(selectedPaymentTerm.PaymentTerm_Days) )
                {
                    selectedPaymentTerm.PaymentTerm_Days = int.Parse(PaymentTermTextBox.Text);
                    selectedPaymentTerm.IsDefaultPaymentTerm = IsDefaultPaymentTermCheckBox.Checked;

                    GlobalConfig.Connection.UpdatePaymentTermModel(selectedPaymentTerm);
                }
                else
                {
                    if(CheckIfPaymentTermExists(selectedPaymentTerm.PaymentTerm_Days))
                        MessageBox.Show("Payment Term already exists!");
                }

                InitializePaymentTermList();
            }
        }

        /// <summary>
        /// Displays the selected PaymentTermsModel information in the associated textbox/checkbox
        /// </summary>
        private void PaymentTermsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentTermsModel selectedPaymentTerm = (PaymentTermsModel)PaymentTermsListBox.SelectedItem;

            if (selectedPaymentTerm != null)
            {
                PaymentTermTextBox.Text = selectedPaymentTerm.PaymentTerm_Days.ToString();
                IsDefaultPaymentTermCheckBox.Checked = selectedPaymentTerm.IsDefaultPaymentTerm;
            }
        }

        /// <summary>
        ///If the form  was openened by being called from another form that implements the IPaymentTermRequester interface
        ///sends back/updates information in the calling form
        ///Closes the current form
        /// </summary>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (callingForm != null)
                callingForm.PaymentTermComplete();

            this.Close();
        }
    }
}