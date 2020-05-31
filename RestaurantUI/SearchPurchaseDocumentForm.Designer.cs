namespace RestaurantUI
{
    partial class SearchPurchaseDocumentForm
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
            this.SelectLabel = new System.Windows.Forms.Label();
            this.DocumentLabel = new System.Windows.Forms.Label();
            this.POrderContentDataGridView = new System.Windows.Forms.DataGridView();
            this.SelectDocumentButton = new System.Windows.Forms.Button();
            this.CancelSelectButton = new System.Windows.Forms.Button();
            this.FilterDocumentGroupBox = new System.Windows.Forms.GroupBox();
            this.FilterDocumentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DocumentDateLabel = new System.Windows.Forms.Label();
            this.SearchProductTextBox = new System.Windows.Forms.TextBox();
            this.VendorNameLabel = new System.Windows.Forms.Label();
            this.SearchDocument = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.POrderContentDataGridView)).BeginInit();
            this.FilterDocumentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectLabel
            // 
            this.SelectLabel.AutoSize = true;
            this.SelectLabel.Location = new System.Drawing.Point(12, 9);
            this.SelectLabel.Name = "SelectLabel";
            this.SelectLabel.Size = new System.Drawing.Size(52, 16);
            this.SelectLabel.TabIndex = 9;
            this.SelectLabel.Text = "Select";
            // 
            // DocumentLabel
            // 
            this.DocumentLabel.AutoSize = true;
            this.DocumentLabel.Location = new System.Drawing.Point(70, 9);
            this.DocumentLabel.Name = "DocumentLabel";
            this.DocumentLabel.Size = new System.Drawing.Size(47, 16);
            this.DocumentLabel.TabIndex = 10;
            this.DocumentLabel.Text = "Order";
            // 
            // POrderContentDataGridView
            // 
            this.POrderContentDataGridView.AllowUserToOrderColumns = true;
            this.POrderContentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.POrderContentDataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.POrderContentDataGridView.Location = new System.Drawing.Point(12, 38);
            this.POrderContentDataGridView.Name = "POrderContentDataGridView";
            this.POrderContentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.POrderContentDataGridView.Size = new System.Drawing.Size(668, 262);
            this.POrderContentDataGridView.TabIndex = 11;
            // 
            // SelectDocumentButton
            // 
            this.SelectDocumentButton.BackColor = System.Drawing.Color.Gray;
            this.SelectDocumentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectDocumentButton.Location = new System.Drawing.Point(696, 265);
            this.SelectDocumentButton.Name = "SelectDocumentButton";
            this.SelectDocumentButton.Size = new System.Drawing.Size(123, 23);
            this.SelectDocumentButton.TabIndex = 41;
            this.SelectDocumentButton.Text = "Select";
            this.SelectDocumentButton.UseVisualStyleBackColor = false;
            this.SelectDocumentButton.Click += new System.EventHandler(this.SelectDocumentButton_Click);
            // 
            // CancelSelectButton
            // 
            this.CancelSelectButton.BackColor = System.Drawing.Color.Gray;
            this.CancelSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelSelectButton.Location = new System.Drawing.Point(833, 265);
            this.CancelSelectButton.Name = "CancelSelectButton";
            this.CancelSelectButton.Size = new System.Drawing.Size(123, 23);
            this.CancelSelectButton.TabIndex = 42;
            this.CancelSelectButton.Text = "Cancel";
            this.CancelSelectButton.UseVisualStyleBackColor = false;
            this.CancelSelectButton.Click += new System.EventHandler(this.CancelSelectButton_Click);
            // 
            // FilterDocumentGroupBox
            // 
            this.FilterDocumentGroupBox.Controls.Add(this.SearchDocument);
            this.FilterDocumentGroupBox.Controls.Add(this.FilterDocumentDateTimePicker);
            this.FilterDocumentGroupBox.Controls.Add(this.DocumentDateLabel);
            this.FilterDocumentGroupBox.Controls.Add(this.SearchProductTextBox);
            this.FilterDocumentGroupBox.Controls.Add(this.VendorNameLabel);
            this.FilterDocumentGroupBox.ForeColor = System.Drawing.Color.Gold;
            this.FilterDocumentGroupBox.Location = new System.Drawing.Point(696, 38);
            this.FilterDocumentGroupBox.Name = "FilterDocumentGroupBox";
            this.FilterDocumentGroupBox.Size = new System.Drawing.Size(260, 142);
            this.FilterDocumentGroupBox.TabIndex = 43;
            this.FilterDocumentGroupBox.TabStop = false;
            this.FilterDocumentGroupBox.Text = "Filter By";
            // 
            // FilterDocumentDateTimePicker
            // 
            this.FilterDocumentDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FilterDocumentDateTimePicker.Location = new System.Drawing.Point(108, 72);
            this.FilterDocumentDateTimePicker.Name = "FilterDocumentDateTimePicker";
            this.FilterDocumentDateTimePicker.Size = new System.Drawing.Size(143, 22);
            this.FilterDocumentDateTimePicker.TabIndex = 46;
            // 
            // DocumentDateLabel
            // 
            this.DocumentDateLabel.AutoSize = true;
            this.DocumentDateLabel.Location = new System.Drawing.Point(6, 77);
            this.DocumentDateLabel.Name = "DocumentDateLabel";
            this.DocumentDateLabel.Size = new System.Drawing.Size(77, 16);
            this.DocumentDateLabel.TabIndex = 45;
            this.DocumentDateLabel.Text = "Doc. Date";
            // 
            // SearchProductTextBox
            // 
            this.SearchProductTextBox.Location = new System.Drawing.Point(108, 38);
            this.SearchProductTextBox.Name = "SearchProductTextBox";
            this.SearchProductTextBox.Size = new System.Drawing.Size(143, 22);
            this.SearchProductTextBox.TabIndex = 15;
            // 
            // VendorNameLabel
            // 
            this.VendorNameLabel.AutoSize = true;
            this.VendorNameLabel.Location = new System.Drawing.Point(6, 41);
            this.VendorNameLabel.Name = "VendorNameLabel";
            this.VendorNameLabel.Size = new System.Drawing.Size(103, 16);
            this.VendorNameLabel.TabIndex = 14;
            this.VendorNameLabel.Text = "Vendor Name";
            // 
            // SearchDocument
            // 
            this.SearchDocument.BackColor = System.Drawing.Color.Gray;
            this.SearchDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchDocument.Location = new System.Drawing.Point(108, 113);
            this.SearchDocument.Name = "SearchDocument";
            this.SearchDocument.Size = new System.Drawing.Size(143, 23);
            this.SearchDocument.TabIndex = 47;
            this.SearchDocument.Text = "Search";
            this.SearchDocument.UseVisualStyleBackColor = false;
            this.SearchDocument.Click += new System.EventHandler(this.SearchDocument_Click);
            // 
            // SearchPurchaseDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(976, 324);
            this.Controls.Add(this.FilterDocumentGroupBox);
            this.Controls.Add(this.CancelSelectButton);
            this.Controls.Add(this.SelectDocumentButton);
            this.Controls.Add(this.POrderContentDataGridView);
            this.Controls.Add(this.DocumentLabel);
            this.Controls.Add(this.SelectLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gold;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SearchPurchaseDocumentForm";
            this.Text = "SearchPurchaseDocumentForm";
            ((System.ComponentModel.ISupportInitialize)(this.POrderContentDataGridView)).EndInit();
            this.FilterDocumentGroupBox.ResumeLayout(false);
            this.FilterDocumentGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectLabel;
        private System.Windows.Forms.Label DocumentLabel;
        private System.Windows.Forms.DataGridView POrderContentDataGridView;
        private System.Windows.Forms.Button SelectDocumentButton;
        private System.Windows.Forms.Button CancelSelectButton;
        private System.Windows.Forms.GroupBox FilterDocumentGroupBox;
        private System.Windows.Forms.TextBox SearchProductTextBox;
        private System.Windows.Forms.Label VendorNameLabel;
        private System.Windows.Forms.DateTimePicker FilterDocumentDateTimePicker;
        private System.Windows.Forms.Label DocumentDateLabel;
        private System.Windows.Forms.Button SearchDocument;
    }
}