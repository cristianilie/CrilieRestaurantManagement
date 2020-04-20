namespace RestaurantUI
{
    partial class FinishSalesOrderPreviewForm
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
            this.SelectedOrderTotalGroupBox = new System.Windows.Forms.GroupBox();
            this.GrandTotalAmountSOTextBox = new System.Windows.Forms.TextBox();
            this.TaxTotalAmountSOTextBox = new System.Windows.Forms.TextBox();
            this.TotalAmountSOTextBox = new System.Windows.Forms.TextBox();
            this.GrandTotalLabel = new System.Windows.Forms.Label();
            this.TaxTotalLabel = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.PrintBillButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.FinishSalesOrderButton = new System.Windows.Forms.Button();
            this.SalesOrderContentListBox = new System.Windows.Forms.ListBox();
            this.FinishOrderLabel = new System.Windows.Forms.Label();
            this.SalesORderContentLabel = new System.Windows.Forms.Label();
            this.SelectedOrderTotalGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectedOrderTotalGroupBox
            // 
            this.SelectedOrderTotalGroupBox.Controls.Add(this.GrandTotalAmountSOTextBox);
            this.SelectedOrderTotalGroupBox.Controls.Add(this.TaxTotalAmountSOTextBox);
            this.SelectedOrderTotalGroupBox.Controls.Add(this.TotalAmountSOTextBox);
            this.SelectedOrderTotalGroupBox.Controls.Add(this.GrandTotalLabel);
            this.SelectedOrderTotalGroupBox.Controls.Add(this.TaxTotalLabel);
            this.SelectedOrderTotalGroupBox.Controls.Add(this.TotalLabel);
            this.SelectedOrderTotalGroupBox.Location = new System.Drawing.Point(11, 294);
            this.SelectedOrderTotalGroupBox.Name = "SelectedOrderTotalGroupBox";
            this.SelectedOrderTotalGroupBox.Size = new System.Drawing.Size(266, 101);
            this.SelectedOrderTotalGroupBox.TabIndex = 32;
            this.SelectedOrderTotalGroupBox.TabStop = false;
            this.SelectedOrderTotalGroupBox.Text = "Selected Order Total";
            // 
            // GrandTotalAmountSOTextBox
            // 
            this.GrandTotalAmountSOTextBox.Location = new System.Drawing.Point(108, 69);
            this.GrandTotalAmountSOTextBox.Name = "GrandTotalAmountSOTextBox";
            this.GrandTotalAmountSOTextBox.ReadOnly = true;
            this.GrandTotalAmountSOTextBox.Size = new System.Drawing.Size(113, 21);
            this.GrandTotalAmountSOTextBox.TabIndex = 18;
            // 
            // TaxTotalAmountSOTextBox
            // 
            this.TaxTotalAmountSOTextBox.Location = new System.Drawing.Point(81, 41);
            this.TaxTotalAmountSOTextBox.Name = "TaxTotalAmountSOTextBox";
            this.TaxTotalAmountSOTextBox.ReadOnly = true;
            this.TaxTotalAmountSOTextBox.Size = new System.Drawing.Size(140, 21);
            this.TaxTotalAmountSOTextBox.TabIndex = 17;
            // 
            // TotalAmountSOTextBox
            // 
            this.TotalAmountSOTextBox.Location = new System.Drawing.Point(81, 16);
            this.TotalAmountSOTextBox.Name = "TotalAmountSOTextBox";
            this.TotalAmountSOTextBox.ReadOnly = true;
            this.TotalAmountSOTextBox.Size = new System.Drawing.Size(140, 21);
            this.TotalAmountSOTextBox.TabIndex = 16;
            // 
            // GrandTotalLabel
            // 
            this.GrandTotalLabel.AutoSize = true;
            this.GrandTotalLabel.Location = new System.Drawing.Point(33, 69);
            this.GrandTotalLabel.Name = "GrandTotalLabel";
            this.GrandTotalLabel.Size = new System.Drawing.Size(90, 15);
            this.GrandTotalLabel.TabIndex = 10;
            this.GrandTotalLabel.Text = "Grand Total :";
            // 
            // TaxTotalLabel
            // 
            this.TaxTotalLabel.AutoSize = true;
            this.TaxTotalLabel.Location = new System.Drawing.Point(33, 44);
            this.TaxTotalLabel.Name = "TaxTotalLabel";
            this.TaxTotalLabel.Size = new System.Drawing.Size(38, 15);
            this.TaxTotalLabel.TabIndex = 9;
            this.TaxTotalLabel.Text = "Tax :";
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(33, 19);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(47, 15);
            this.TotalLabel.TabIndex = 8;
            this.TotalLabel.Text = "Total :";
            // 
            // PrintBillButton
            // 
            this.PrintBillButton.Location = new System.Drawing.Point(114, 401);
            this.PrintBillButton.Name = "PrintBillButton";
            this.PrintBillButton.Size = new System.Drawing.Size(62, 23);
            this.PrintBillButton.TabIndex = 31;
            this.PrintBillButton.Text = "Print";
            this.PrintBillButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(215, 401);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(62, 23);
            this.CancelButton.TabIndex = 30;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FinishSalesOrderButton
            // 
            this.FinishSalesOrderButton.Location = new System.Drawing.Point(11, 401);
            this.FinishSalesOrderButton.Name = "FinishSalesOrderButton";
            this.FinishSalesOrderButton.Size = new System.Drawing.Size(64, 23);
            this.FinishSalesOrderButton.TabIndex = 29;
            this.FinishSalesOrderButton.Text = "Finish";
            this.FinishSalesOrderButton.UseVisualStyleBackColor = true;
            this.FinishSalesOrderButton.Click += new System.EventHandler(this.FinishSalesOrderButton_Click);
            // 
            // SalesOrderContentListBox
            // 
            this.SalesOrderContentListBox.FormattingEnabled = true;
            this.SalesOrderContentListBox.ItemHeight = 15;
            this.SalesOrderContentListBox.Location = new System.Drawing.Point(11, 59);
            this.SalesOrderContentListBox.Name = "SalesOrderContentListBox";
            this.SalesOrderContentListBox.Size = new System.Drawing.Size(266, 229);
            this.SalesOrderContentListBox.TabIndex = 28;
            this.SalesOrderContentListBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.SalesOrderContentListBox_Format);
            // 
            // FinishOrderLabel
            // 
            this.FinishOrderLabel.AutoSize = true;
            this.FinishOrderLabel.Location = new System.Drawing.Point(9, 9);
            this.FinishOrderLabel.Name = "FinishOrderLabel";
            this.FinishOrderLabel.Size = new System.Drawing.Size(86, 15);
            this.FinishOrderLabel.TabIndex = 33;
            this.FinishOrderLabel.Text = "Finish Order";
            // 
            // SalesORderContentLabel
            // 
            this.SalesORderContentLabel.AutoSize = true;
            this.SalesORderContentLabel.Location = new System.Drawing.Point(9, 41);
            this.SalesORderContentLabel.Name = "SalesORderContentLabel";
            this.SalesORderContentLabel.Size = new System.Drawing.Size(140, 15);
            this.SalesORderContentLabel.TabIndex = 34;
            this.SalesORderContentLabel.Text = "Sales Order Content:";
            // 
            // FinishSalesOrderPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(289, 440);
            this.Controls.Add(this.SalesORderContentLabel);
            this.Controls.Add(this.FinishOrderLabel);
            this.Controls.Add(this.SelectedOrderTotalGroupBox);
            this.Controls.Add(this.PrintBillButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.FinishSalesOrderButton);
            this.Controls.Add(this.SalesOrderContentListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkOrange;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FinishSalesOrderPreviewForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FinishSalesOrderPreviewForm";
            this.SelectedOrderTotalGroupBox.ResumeLayout(false);
            this.SelectedOrderTotalGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SelectedOrderTotalGroupBox;
        private System.Windows.Forms.TextBox GrandTotalAmountSOTextBox;
        private System.Windows.Forms.TextBox TaxTotalAmountSOTextBox;
        private System.Windows.Forms.TextBox TotalAmountSOTextBox;
        private System.Windows.Forms.Label GrandTotalLabel;
        private System.Windows.Forms.Label TaxTotalLabel;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Button PrintBillButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button FinishSalesOrderButton;
        private System.Windows.Forms.ListBox SalesOrderContentListBox;
        private System.Windows.Forms.Label FinishOrderLabel;
        private System.Windows.Forms.Label SalesORderContentLabel;
    }
}