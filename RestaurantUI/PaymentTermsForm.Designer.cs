namespace RestaurantUI
{
    partial class PaymentTermsForm
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
            this.IsDefaultPaymentTermCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.PaymentTermTextBox = new System.Windows.Forms.TextBox();
            this.SelectPaymentTermLabel = new System.Windows.Forms.Label();
            this.PaymentTermsListBox = new System.Windows.Forms.ListBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IsDefaultPaymentTermCheckBox
            // 
            this.IsDefaultPaymentTermCheckBox.AutoSize = true;
            this.IsDefaultPaymentTermCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsDefaultPaymentTermCheckBox.Location = new System.Drawing.Point(106, 77);
            this.IsDefaultPaymentTermCheckBox.Name = "IsDefaultPaymentTermCheckBox";
            this.IsDefaultPaymentTermCheckBox.Size = new System.Drawing.Size(196, 20);
            this.IsDefaultPaymentTermCheckBox.TabIndex = 79;
            this.IsDefaultPaymentTermCheckBox.Text = "Is Default Payment Term";
            this.IsDefaultPaymentTermCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(234, 173);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(67, 28);
            this.ClearButton.TabIndex = 77;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(166, 173);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(67, 28);
            this.UpdateButton.TabIndex = 76;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // PaymentTermTextBox
            // 
            this.PaymentTermTextBox.Location = new System.Drawing.Point(106, 32);
            this.PaymentTermTextBox.Name = "PaymentTermTextBox";
            this.PaymentTermTextBox.Size = new System.Drawing.Size(55, 22);
            this.PaymentTermTextBox.TabIndex = 74;
            // 
            // SelectPaymentTermLabel
            // 
            this.SelectPaymentTermLabel.AutoSize = true;
            this.SelectPaymentTermLabel.Location = new System.Drawing.Point(9, 11);
            this.SelectPaymentTermLabel.Name = "SelectPaymentTermLabel";
            this.SelectPaymentTermLabel.Size = new System.Drawing.Size(152, 16);
            this.SelectPaymentTermLabel.TabIndex = 73;
            this.SelectPaymentTermLabel.Text = "Select PaymentTerm";
            // 
            // PaymentTermsListBox
            // 
            this.PaymentTermsListBox.FormattingEnabled = true;
            this.PaymentTermsListBox.ItemHeight = 16;
            this.PaymentTermsListBox.Location = new System.Drawing.Point(12, 32);
            this.PaymentTermsListBox.Name = "PaymentTermsListBox";
            this.PaymentTermsListBox.Size = new System.Drawing.Size(76, 164);
            this.PaymentTermsListBox.TabIndex = 72;
            this.PaymentTermsListBox.SelectedIndexChanged += new System.EventHandler(this.PaymentTermsListBox_SelectedIndexChanged);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(98, 173);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(67, 28);
            this.CreateButton.TabIndex = 81;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(276, 1);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(26, 26);
            this.ExitButton.TabIndex = 86;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PaymentTermsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(303, 215);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.IsDefaultPaymentTermCheckBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.PaymentTermTextBox);
            this.Controls.Add(this.SelectPaymentTermLabel);
            this.Controls.Add(this.PaymentTermsListBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.OrangeRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PaymentTermsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentTermsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox IsDefaultPaymentTermCheckBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TextBox PaymentTermTextBox;
        private System.Windows.Forms.Label SelectPaymentTermLabel;
        private System.Windows.Forms.ListBox PaymentTermsListBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button ExitButton;
    }
}