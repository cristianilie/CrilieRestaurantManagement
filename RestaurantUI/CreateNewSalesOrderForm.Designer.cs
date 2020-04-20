namespace RestaurantUI
{
    partial class CreateNewSalesOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectTableButton = new System.Windows.Forms.Button();
            this.TablesListBox = new System.Windows.Forms.ListBox();
            this.CustomersListBox = new System.Windows.Forms.ListBox();
            this.SelectCustomerButton = new System.Windows.Forms.Button();
            this.CompaniesListBox = new System.Windows.Forms.ListBox();
            this.SelectCompanyButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectTableButton
            // 
            this.SelectTableButton.Location = new System.Drawing.Point(12, 205);
            this.SelectTableButton.Name = "SelectTableButton";
            this.SelectTableButton.Size = new System.Drawing.Size(75, 23);
            this.SelectTableButton.TabIndex = 0;
            this.SelectTableButton.Text = "Select";
            this.SelectTableButton.UseVisualStyleBackColor = true;
            this.SelectTableButton.Click += new System.EventHandler(this.SelectTableButton_Click);
            // 
            // TablesListBox
            // 
            this.TablesListBox.FormattingEnabled = true;
            this.TablesListBox.ItemHeight = 16;
            this.TablesListBox.Location = new System.Drawing.Point(12, 35);
            this.TablesListBox.Name = "TablesListBox";
            this.TablesListBox.Size = new System.Drawing.Size(136, 164);
            this.TablesListBox.TabIndex = 1;
            // 
            // CustomersListBox
            // 
            this.CustomersListBox.FormattingEnabled = true;
            this.CustomersListBox.ItemHeight = 16;
            this.CustomersListBox.Location = new System.Drawing.Point(157, 35);
            this.CustomersListBox.Name = "CustomersListBox";
            this.CustomersListBox.Size = new System.Drawing.Size(136, 164);
            this.CustomersListBox.TabIndex = 3;
            // 
            // SelectCustomerButton
            // 
            this.SelectCustomerButton.Location = new System.Drawing.Point(154, 205);
            this.SelectCustomerButton.Name = "SelectCustomerButton";
            this.SelectCustomerButton.Size = new System.Drawing.Size(75, 23);
            this.SelectCustomerButton.TabIndex = 2;
            this.SelectCustomerButton.Text = "Select";
            this.SelectCustomerButton.UseVisualStyleBackColor = true;
            this.SelectCustomerButton.Click += new System.EventHandler(this.SelectCustomerButton_Click);
            // 
            // CompaniesListBox
            // 
            this.CompaniesListBox.FormattingEnabled = true;
            this.CompaniesListBox.ItemHeight = 16;
            this.CompaniesListBox.Location = new System.Drawing.Point(299, 35);
            this.CompaniesListBox.Name = "CompaniesListBox";
            this.CompaniesListBox.Size = new System.Drawing.Size(136, 164);
            this.CompaniesListBox.TabIndex = 5;
            // 
            // SelectCompanyButton
            // 
            this.SelectCompanyButton.Location = new System.Drawing.Point(296, 205);
            this.SelectCompanyButton.Name = "SelectCompanyButton";
            this.SelectCompanyButton.Size = new System.Drawing.Size(75, 23);
            this.SelectCompanyButton.TabIndex = 4;
            this.SelectCompanyButton.Text = "Select";
            this.SelectCompanyButton.UseVisualStyleBackColor = true;
            this.SelectCompanyButton.Click += new System.EventHandler(this.SelectCompanyButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(425, -1);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(23, 23);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select the order delivery method:";
            // 
            // CreateNewSalesOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 235);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CompaniesListBox);
            this.Controls.Add(this.SelectCompanyButton);
            this.Controls.Add(this.CustomersListBox);
            this.Controls.Add(this.SelectCustomerButton);
            this.Controls.Add(this.TablesListBox);
            this.Controls.Add(this.SelectTableButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.IndianRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateNewSalesOrderForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateNewSalesOrderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectTableButton;
        private System.Windows.Forms.ListBox TablesListBox;
        private System.Windows.Forms.ListBox CustomersListBox;
        private System.Windows.Forms.Button SelectCustomerButton;
        private System.Windows.Forms.ListBox CompaniesListBox;
        private System.Windows.Forms.Button SelectCompanyButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label1;
    }
}