namespace RestaurantUI
{
    partial class CustomerManagementForm
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
            this.DeliveryAdressLabel = new System.Windows.Forms.Label();
            this.DeliveryAdressTextBox = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.UpdateCustomerButton = new System.Windows.Forms.Button();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.CustomersListBox = new System.Windows.Forms.ListBox();
            this.CreateCustomerButton = new System.Windows.Forms.Button();
            this.CustomerDetailsLabel = new System.Windows.Forms.Label();
            this.ClearCustomerTextBoxesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeliveryAdressLabel
            // 
            this.DeliveryAdressLabel.AutoSize = true;
            this.DeliveryAdressLabel.Location = new System.Drawing.Point(12, 132);
            this.DeliveryAdressLabel.Name = "DeliveryAdressLabel";
            this.DeliveryAdressLabel.Size = new System.Drawing.Size(110, 18);
            this.DeliveryAdressLabel.TabIndex = 22;
            this.DeliveryAdressLabel.Text = "Delivery Adress";
            // 
            // DeliveryAdressTextBox
            // 
            this.DeliveryAdressTextBox.Location = new System.Drawing.Point(15, 153);
            this.DeliveryAdressTextBox.Name = "DeliveryAdressTextBox";
            this.DeliveryAdressTextBox.Size = new System.Drawing.Size(160, 24);
            this.DeliveryAdressTextBox.TabIndex = 21;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(12, 84);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(80, 18);
            this.LastNameLabel.TabIndex = 20;
            this.LastNameLabel.Text = "Last Name";
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(15, 105);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(160, 24);
            this.LastNameTextBox.TabIndex = 19;
            // 
            // UpdateCustomerButton
            // 
            this.UpdateCustomerButton.Location = new System.Drawing.Point(15, 217);
            this.UpdateCustomerButton.Name = "UpdateCustomerButton";
            this.UpdateCustomerButton.Size = new System.Drawing.Size(160, 28);
            this.UpdateCustomerButton.TabIndex = 18;
            this.UpdateCustomerButton.Text = "Update";
            this.UpdateCustomerButton.UseVisualStyleBackColor = true;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(12, 36);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(81, 18);
            this.FirstNameLabel.TabIndex = 17;
            this.FirstNameLabel.Text = "First Name";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(15, 57);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(160, 24);
            this.FirstNameTextBox.TabIndex = 16;
            // 
            // CustomersListBox
            // 
            this.CustomersListBox.FormattingEnabled = true;
            this.CustomersListBox.ItemHeight = 18;
            this.CustomersListBox.Location = new System.Drawing.Point(199, 43);
            this.CustomersListBox.Name = "CustomersListBox";
            this.CustomersListBox.Size = new System.Drawing.Size(181, 238);
            this.CustomersListBox.TabIndex = 15;
            // 
            // CreateCustomerButton
            // 
            this.CreateCustomerButton.Location = new System.Drawing.Point(15, 183);
            this.CreateCustomerButton.Name = "CreateCustomerButton";
            this.CreateCustomerButton.Size = new System.Drawing.Size(160, 28);
            this.CreateCustomerButton.TabIndex = 14;
            this.CreateCustomerButton.Text = "Create";
            this.CreateCustomerButton.UseVisualStyleBackColor = true;
            // 
            // CustomerDetailsLabel
            // 
            this.CustomerDetailsLabel.AutoSize = true;
            this.CustomerDetailsLabel.Location = new System.Drawing.Point(11, 9);
            this.CustomerDetailsLabel.Name = "CustomerDetailsLabel";
            this.CustomerDetailsLabel.Size = new System.Drawing.Size(123, 18);
            this.CustomerDetailsLabel.TabIndex = 23;
            this.CustomerDetailsLabel.Text = "Customer Details";
            // 
            // ClearCustomerTextBoxesButton
            // 
            this.ClearCustomerTextBoxesButton.Location = new System.Drawing.Point(15, 251);
            this.ClearCustomerTextBoxesButton.Name = "ClearCustomerTextBoxesButton";
            this.ClearCustomerTextBoxesButton.Size = new System.Drawing.Size(160, 28);
            this.ClearCustomerTextBoxesButton.TabIndex = 24;
            this.ClearCustomerTextBoxesButton.Text = "Clear";
            this.ClearCustomerTextBoxesButton.UseVisualStyleBackColor = true;
            // 
            // CustomerManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(395, 295);
            this.Controls.Add(this.ClearCustomerTextBoxesButton);
            this.Controls.Add(this.CustomerDetailsLabel);
            this.Controls.Add(this.DeliveryAdressLabel);
            this.Controls.Add(this.DeliveryAdressTextBox);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.UpdateCustomerButton);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.CustomersListBox);
            this.Controls.Add(this.CreateCustomerButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Firebrick;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CustomerManagementForm";
            this.ShowIcon = false;
            this.Text = "Customer Management Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DeliveryAdressLabel;
        private System.Windows.Forms.TextBox DeliveryAdressTextBox;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.Button UpdateCustomerButton;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.ListBox CustomersListBox;
        private System.Windows.Forms.Button CreateCustomerButton;
        private System.Windows.Forms.Label CustomerDetailsLabel;
        private System.Windows.Forms.Button ClearCustomerTextBoxesButton;
    }
}