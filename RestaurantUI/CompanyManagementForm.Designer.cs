namespace RestaurantUI
{
    partial class CompanyManagementForm
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
            this.UpdateCompanyButton = new System.Windows.Forms.Button();
            this.CompanyNameLabel = new System.Windows.Forms.Label();
            this.CompanyNameTextBox = new System.Windows.Forms.TextBox();
            this.CompaniesListBox = new System.Windows.Forms.ListBox();
            this.CreateCompanyButton = new System.Windows.Forms.Button();
            this.CompanyDataLabel = new System.Windows.Forms.Label();
            this.CompanyDataTextBox = new System.Windows.Forms.TextBox();
            this.CompanyAdressLabel = new System.Windows.Forms.Label();
            this.CompanyAdressTextBox = new System.Windows.Forms.TextBox();
            this.ClearCompanyTextBoxesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UpdateCompanyButton
            // 
            this.UpdateCompanyButton.Location = new System.Drawing.Point(15, 200);
            this.UpdateCompanyButton.Name = "UpdateCompanyButton";
            this.UpdateCompanyButton.Size = new System.Drawing.Size(160, 28);
            this.UpdateCompanyButton.TabIndex = 9;
            this.UpdateCompanyButton.Text = "Update";
            this.UpdateCompanyButton.UseVisualStyleBackColor = true;
            this.UpdateCompanyButton.Click += new System.EventHandler(this.UpdateCompanyButton_Click);
            // 
            // CompanyNameLabel
            // 
            this.CompanyNameLabel.AutoSize = true;
            this.CompanyNameLabel.Location = new System.Drawing.Point(12, 19);
            this.CompanyNameLabel.Name = "CompanyNameLabel";
            this.CompanyNameLabel.Size = new System.Drawing.Size(116, 18);
            this.CompanyNameLabel.TabIndex = 8;
            this.CompanyNameLabel.Text = "Company Name";
            // 
            // CompanyNameTextBox
            // 
            this.CompanyNameTextBox.Location = new System.Drawing.Point(15, 40);
            this.CompanyNameTextBox.Name = "CompanyNameTextBox";
            this.CompanyNameTextBox.Size = new System.Drawing.Size(160, 24);
            this.CompanyNameTextBox.TabIndex = 0;
            // 
            // CompaniesListBox
            // 
            this.CompaniesListBox.FormattingEnabled = true;
            this.CompaniesListBox.ItemHeight = 18;
            this.CompaniesListBox.Location = new System.Drawing.Point(199, 26);
            this.CompaniesListBox.Name = "CompaniesListBox";
            this.CompaniesListBox.Size = new System.Drawing.Size(181, 220);
            this.CompaniesListBox.TabIndex = 6;
            this.CompaniesListBox.SelectedIndexChanged += new System.EventHandler(this.CompaniesListBox_SelectedIndexChanged);
            // 
            // CreateCompanyButton
            // 
            this.CreateCompanyButton.Location = new System.Drawing.Point(15, 166);
            this.CreateCompanyButton.Name = "CreateCompanyButton";
            this.CreateCompanyButton.Size = new System.Drawing.Size(160, 28);
            this.CreateCompanyButton.TabIndex = 5;
            this.CreateCompanyButton.Text = "Create";
            this.CreateCompanyButton.UseVisualStyleBackColor = true;
            this.CreateCompanyButton.Click += new System.EventHandler(this.CreateCompanyButton_Click);
            // 
            // CompanyDataLabel
            // 
            this.CompanyDataLabel.AutoSize = true;
            this.CompanyDataLabel.Location = new System.Drawing.Point(12, 67);
            this.CompanyDataLabel.Name = "CompanyDataLabel";
            this.CompanyDataLabel.Size = new System.Drawing.Size(107, 18);
            this.CompanyDataLabel.TabIndex = 11;
            this.CompanyDataLabel.Text = "Company Data";
            // 
            // CompanyDataTextBox
            // 
            this.CompanyDataTextBox.Location = new System.Drawing.Point(15, 88);
            this.CompanyDataTextBox.Name = "CompanyDataTextBox";
            this.CompanyDataTextBox.Size = new System.Drawing.Size(160, 24);
            this.CompanyDataTextBox.TabIndex = 1;
            // 
            // CompanyAdressLabel
            // 
            this.CompanyAdressLabel.AutoSize = true;
            this.CompanyAdressLabel.Location = new System.Drawing.Point(12, 115);
            this.CompanyAdressLabel.Name = "CompanyAdressLabel";
            this.CompanyAdressLabel.Size = new System.Drawing.Size(122, 18);
            this.CompanyAdressLabel.TabIndex = 13;
            this.CompanyAdressLabel.Text = "Company Adress";
            // 
            // CompanyAdressTextBox
            // 
            this.CompanyAdressTextBox.Location = new System.Drawing.Point(15, 136);
            this.CompanyAdressTextBox.Name = "CompanyAdressTextBox";
            this.CompanyAdressTextBox.Size = new System.Drawing.Size(160, 24);
            this.CompanyAdressTextBox.TabIndex = 2;
            // 
            // ClearCompanyTextBoxesButton
            // 
            this.ClearCompanyTextBoxesButton.Location = new System.Drawing.Point(15, 234);
            this.ClearCompanyTextBoxesButton.Name = "ClearCompanyTextBoxesButton";
            this.ClearCompanyTextBoxesButton.Size = new System.Drawing.Size(160, 28);
            this.ClearCompanyTextBoxesButton.TabIndex = 14;
            this.ClearCompanyTextBoxesButton.Text = "Clear";
            this.ClearCompanyTextBoxesButton.UseVisualStyleBackColor = true;
            this.ClearCompanyTextBoxesButton.Click += new System.EventHandler(this.ClearCompanyTextBoxesButton_Click);
            // 
            // CompanyManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(394, 267);
            this.Controls.Add(this.ClearCompanyTextBoxesButton);
            this.Controls.Add(this.CompanyAdressLabel);
            this.Controls.Add(this.CompanyAdressTextBox);
            this.Controls.Add(this.CompanyDataLabel);
            this.Controls.Add(this.CompanyDataTextBox);
            this.Controls.Add(this.UpdateCompanyButton);
            this.Controls.Add(this.CompanyNameLabel);
            this.Controls.Add(this.CompanyNameTextBox);
            this.Controls.Add(this.CompaniesListBox);
            this.Controls.Add(this.CreateCompanyButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Firebrick;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CompanyManagementForm";
            this.ShowIcon = false;
            this.Text = "Company Management Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateCompanyButton;
        private System.Windows.Forms.Label CompanyNameLabel;
        private System.Windows.Forms.TextBox CompanyNameTextBox;
        private System.Windows.Forms.ListBox CompaniesListBox;
        private System.Windows.Forms.Button CreateCompanyButton;
        private System.Windows.Forms.Label CompanyDataLabel;
        private System.Windows.Forms.TextBox CompanyDataTextBox;
        private System.Windows.Forms.Label CompanyAdressLabel;
        private System.Windows.Forms.TextBox CompanyAdressTextBox;
        private System.Windows.Forms.Button ClearCompanyTextBoxesButton;
    }
}