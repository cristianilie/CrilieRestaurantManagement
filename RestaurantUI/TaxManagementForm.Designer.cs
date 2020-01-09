namespace RestaurantUI
{
    partial class TaxManagementForm
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
            this.ClearTaxTextBoxesButton = new System.Windows.Forms.Button();
            this.TaxDetailsLabel = new System.Windows.Forms.Label();
            this.TaxPercentLabel = new System.Windows.Forms.Label();
            this.TaxPercentTextBox = new System.Windows.Forms.TextBox();
            this.UpdateTaxButton = new System.Windows.Forms.Button();
            this.TaxDisplayNameLabel = new System.Windows.Forms.Label();
            this.TaxNameTextBox = new System.Windows.Forms.TextBox();
            this.TaxesListBox = new System.Windows.Forms.ListBox();
            this.CreateTaxButton = new System.Windows.Forms.Button();
            this.IsDefaultTaxCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ClearTaxTextBoxesButton
            // 
            this.ClearTaxTextBoxesButton.Location = new System.Drawing.Point(16, 251);
            this.ClearTaxTextBoxesButton.Name = "ClearTaxTextBoxesButton";
            this.ClearTaxTextBoxesButton.Size = new System.Drawing.Size(160, 28);
            this.ClearTaxTextBoxesButton.TabIndex = 35;
            this.ClearTaxTextBoxesButton.Text = "Clear";
            this.ClearTaxTextBoxesButton.UseVisualStyleBackColor = true;
            this.ClearTaxTextBoxesButton.Click += new System.EventHandler(this.ClearTaxTextBoxesButton_Click);
            // 
            // TaxDetailsLabel
            // 
            this.TaxDetailsLabel.AutoSize = true;
            this.TaxDetailsLabel.Location = new System.Drawing.Point(12, 9);
            this.TaxDetailsLabel.Name = "TaxDetailsLabel";
            this.TaxDetailsLabel.Size = new System.Drawing.Size(81, 18);
            this.TaxDetailsLabel.TabIndex = 34;
            this.TaxDetailsLabel.Text = "Tax Details";
            // 
            // TaxPercentLabel
            // 
            this.TaxPercentLabel.AutoSize = true;
            this.TaxPercentLabel.Location = new System.Drawing.Point(13, 84);
            this.TaxPercentLabel.Name = "TaxPercentLabel";
            this.TaxPercentLabel.Size = new System.Drawing.Size(59, 18);
            this.TaxPercentLabel.TabIndex = 31;
            this.TaxPercentLabel.Text = "Percent";
            // 
            // TaxPercentTextBox
            // 
            this.TaxPercentTextBox.Location = new System.Drawing.Point(16, 105);
            this.TaxPercentTextBox.Name = "TaxPercentTextBox";
            this.TaxPercentTextBox.Size = new System.Drawing.Size(160, 24);
            this.TaxPercentTextBox.TabIndex = 30;
            // 
            // UpdateTaxButton
            // 
            this.UpdateTaxButton.Location = new System.Drawing.Point(16, 217);
            this.UpdateTaxButton.Name = "UpdateTaxButton";
            this.UpdateTaxButton.Size = new System.Drawing.Size(160, 28);
            this.UpdateTaxButton.TabIndex = 29;
            this.UpdateTaxButton.Text = "Update";
            this.UpdateTaxButton.UseVisualStyleBackColor = true;
            this.UpdateTaxButton.Click += new System.EventHandler(this.UpdateTaxButton_Click);
            // 
            // TaxDisplayNameLabel
            // 
            this.TaxDisplayNameLabel.AutoSize = true;
            this.TaxDisplayNameLabel.Location = new System.Drawing.Point(13, 36);
            this.TaxDisplayNameLabel.Name = "TaxDisplayNameLabel";
            this.TaxDisplayNameLabel.Size = new System.Drawing.Size(100, 18);
            this.TaxDisplayNameLabel.TabIndex = 28;
            this.TaxDisplayNameLabel.Text = "Display Name";
            // 
            // TaxNameTextBox
            // 
            this.TaxNameTextBox.Location = new System.Drawing.Point(16, 57);
            this.TaxNameTextBox.Name = "TaxNameTextBox";
            this.TaxNameTextBox.Size = new System.Drawing.Size(160, 24);
            this.TaxNameTextBox.TabIndex = 27;
            // 
            // TaxesListBox
            // 
            this.TaxesListBox.FormattingEnabled = true;
            this.TaxesListBox.ItemHeight = 18;
            this.TaxesListBox.Location = new System.Drawing.Point(200, 43);
            this.TaxesListBox.Name = "TaxesListBox";
            this.TaxesListBox.Size = new System.Drawing.Size(181, 238);
            this.TaxesListBox.TabIndex = 26;
            this.TaxesListBox.SelectedIndexChanged += new System.EventHandler(this.TaxesListBox_SelectedIndexChanged);
            // 
            // CreateTaxButton
            // 
            this.CreateTaxButton.Location = new System.Drawing.Point(16, 183);
            this.CreateTaxButton.Name = "CreateTaxButton";
            this.CreateTaxButton.Size = new System.Drawing.Size(160, 28);
            this.CreateTaxButton.TabIndex = 25;
            this.CreateTaxButton.Text = "Create";
            this.CreateTaxButton.UseVisualStyleBackColor = true;
            this.CreateTaxButton.Click += new System.EventHandler(this.CreateTaxButton_Click);
            // 
            // IsDefaultTaxCheckBox
            // 
            this.IsDefaultTaxCheckBox.AutoSize = true;
            this.IsDefaultTaxCheckBox.Location = new System.Drawing.Point(16, 145);
            this.IsDefaultTaxCheckBox.Name = "IsDefaultTaxCheckBox";
            this.IsDefaultTaxCheckBox.Size = new System.Drawing.Size(116, 22);
            this.IsDefaultTaxCheckBox.TabIndex = 36;
            this.IsDefaultTaxCheckBox.Text = "Is Default Tax";
            this.IsDefaultTaxCheckBox.UseVisualStyleBackColor = true;
            // 
            // TaxManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(396, 290);
            this.Controls.Add(this.IsDefaultTaxCheckBox);
            this.Controls.Add(this.ClearTaxTextBoxesButton);
            this.Controls.Add(this.TaxDetailsLabel);
            this.Controls.Add(this.TaxPercentLabel);
            this.Controls.Add(this.TaxPercentTextBox);
            this.Controls.Add(this.UpdateTaxButton);
            this.Controls.Add(this.TaxDisplayNameLabel);
            this.Controls.Add(this.TaxNameTextBox);
            this.Controls.Add(this.TaxesListBox);
            this.Controls.Add(this.CreateTaxButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Tomato;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TaxManagementForm";
            this.ShowIcon = false;
            this.Text = "Tax Management Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearTaxTextBoxesButton;
        private System.Windows.Forms.Label TaxDetailsLabel;
        private System.Windows.Forms.Label TaxPercentLabel;
        private System.Windows.Forms.TextBox TaxPercentTextBox;
        private System.Windows.Forms.Button UpdateTaxButton;
        private System.Windows.Forms.Label TaxDisplayNameLabel;
        private System.Windows.Forms.TextBox TaxNameTextBox;
        private System.Windows.Forms.ListBox TaxesListBox;
        private System.Windows.Forms.Button CreateTaxButton;
        private System.Windows.Forms.CheckBox IsDefaultTaxCheckBox;
    }
}