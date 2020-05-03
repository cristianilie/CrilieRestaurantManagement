using RMLibrary;
using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantUI
{
    public partial class TableManagementForm : Form
    {
        public List<TableModel> TablesList { get; set; } = GlobalConfig.Connection.GetTables_All();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TableManagementForm()
        {
            InitializeComponent();
            InitializeTablesList();
        }

        /// <summary>
        /// Creates a new table(table to sit at restaurant)
        /// </summary>
        private void CreateTableButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                TableModel selectedTable = (TableModel)TablesListBox.SelectedItem;
                if (CheckIfTableNameExists())
                    MessageBox.Show("Table name already exists! Please pick another table name");
                else
                    GlobalConfig.Connection.CreateTable(new TableModel { Name = TableNameTextBox.Text });
            }
            InitializeTablesList();
        }

        /// <summary>
        /// Checks if the name of the table we are trying to create already exists
        /// </summary>
        private bool CheckIfTableNameExists()
        {
            return TablesList.Where(c => c.Name == TableNameTextBox.Text).Count() > 0;
        }

        /// <summary>
        /// Checks if the new table name has at leat 3 characters
        /// </summary>
        private bool ValidateForm()
        {
            if (TableNameLabel.Text.Count() > 2 )
                return true;

            return false;
        }

        /// <summary>
        /// Initializes the tables list, and connects it with the tables listbox
        /// </summary>
        private void InitializeTablesList()
        {
            TablesList = GlobalConfig.Connection.GetTables_All();

            TablesListBox.DataSource = null;
            TablesListBox.DisplayMember = "Name";
            TablesListBox.DataSource = TablesList;

            ResetForm();
        }

        /// <summary>
        /// Resets the form elements/selected items and clears the selected table
        /// </summary>
        private void ResetForm()
        {
            TablesListBox.ClearSelected();
            TablesListBox.SelectedItem = null;
            TableNameTextBox.Text = "";
        }

        /// <summary>
        /// Exist the form
        /// </summary>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clears the selected elements and the table name textbox content
        /// </summary>
        private void ClearTableTextBoxButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Updates the selected table item, and refreshes the form elements/listbox
        /// </summary>
        private void UpdateTableButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (CheckIfTableNameExists())
                {
                    MessageBox.Show("Table name already exists! Please pick another table name");
                }
                else
                {
                    TableModel tblToUpdate = (TableModel)TablesListBox.SelectedItem;
                    tblToUpdate.Name = TableNameTextBox.Text;
                    GlobalConfig.Connection.UpdateTableModel(tblToUpdate);
                    InitializeTablesList();
                    ResetForm();
                }

            }
        }

        /// <summary>
        /// When the selected table changes, it displays the table name in the TableNameTextBox
        /// </summary>
        private void TablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TablesListBox.SelectedItem != null)
            {
                TableModel selectedTable = (TableModel)TablesListBox.SelectedItem;
                TableNameTextBox.Text = selectedTable.Name;
            }
        }
    }
}
