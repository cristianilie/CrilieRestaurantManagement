namespace RestaurantUI
{
    partial class PurchasePriceManagementForm
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
            this.SelectedProductPricesListBox = new System.Windows.Forms.ListBox();
            this.ClearTextBoxesButton = new System.Windows.Forms.Button();
            this.UpdateProductPriceButton = new System.Windows.Forms.Button();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.SelectProductLabel = new System.Windows.Forms.Label();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.SelectedPriceLabel = new System.Windows.Forms.Label();
            this.PurchaseDateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectedProductPricesListBox
            // 
            this.SelectedProductPricesListBox.FormattingEnabled = true;
            this.SelectedProductPricesListBox.ItemHeight = 16;
            this.SelectedProductPricesListBox.Location = new System.Drawing.Point(161, 32);
            this.SelectedProductPricesListBox.Name = "SelectedProductPricesListBox";
            this.SelectedProductPricesListBox.Size = new System.Drawing.Size(91, 228);
            this.SelectedProductPricesListBox.TabIndex = 78;
            this.SelectedProductPricesListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedProductPricesListBox_SelectedIndexChanged);
            // 
            // ClearTextBoxesButton
            // 
            this.ClearTextBoxesButton.Location = new System.Drawing.Point(258, 232);
            this.ClearTextBoxesButton.Name = "ClearTextBoxesButton";
            this.ClearTextBoxesButton.Size = new System.Drawing.Size(96, 28);
            this.ClearTextBoxesButton.TabIndex = 77;
            this.ClearTextBoxesButton.Text = "Clear";
            this.ClearTextBoxesButton.UseVisualStyleBackColor = true;
            this.ClearTextBoxesButton.Click += new System.EventHandler(this.ClearTextBoxesButton_Click);
            // 
            // UpdateProductPriceButton
            // 
            this.UpdateProductPriceButton.Location = new System.Drawing.Point(258, 198);
            this.UpdateProductPriceButton.Name = "UpdateProductPriceButton";
            this.UpdateProductPriceButton.Size = new System.Drawing.Size(96, 28);
            this.UpdateProductPriceButton.TabIndex = 76;
            this.UpdateProductPriceButton.Text = "Update";
            this.UpdateProductPriceButton.UseVisualStyleBackColor = true;
            this.UpdateProductPriceButton.Click += new System.EventHandler(this.UpdateProductPriceButton_Click);
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(258, 32);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(67, 22);
            this.PriceTextBox.TabIndex = 74;
            this.PriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceTextBox_KeyPress);
            // 
            // SelectProductLabel
            // 
            this.SelectProductLabel.AutoSize = true;
            this.SelectProductLabel.Location = new System.Drawing.Point(12, 11);
            this.SelectProductLabel.Name = "SelectProductLabel";
            this.SelectProductLabel.Size = new System.Drawing.Size(109, 16);
            this.SelectProductLabel.TabIndex = 73;
            this.SelectProductLabel.Text = "Select Product";
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 16;
            this.ProductsListBox.Location = new System.Drawing.Point(12, 32);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(143, 228);
            this.ProductsListBox.TabIndex = 72;
            this.ProductsListBox.SelectedIndexChanged += new System.EventHandler(this.ProductsListBox_SelectedIndexChanged);
            // 
            // SelectedPriceLabel
            // 
            this.SelectedPriceLabel.AutoSize = true;
            this.SelectedPriceLabel.Location = new System.Drawing.Point(255, 13);
            this.SelectedPriceLabel.Name = "SelectedPriceLabel";
            this.SelectedPriceLabel.Size = new System.Drawing.Size(110, 16);
            this.SelectedPriceLabel.TabIndex = 79;
            this.SelectedPriceLabel.Text = "Selected Price";
            // 
            // PurchaseDateLabel
            // 
            this.PurchaseDateLabel.AutoSize = true;
            this.PurchaseDateLabel.Location = new System.Drawing.Point(258, 57);
            this.PurchaseDateLabel.Name = "PurchaseDateLabel";
            this.PurchaseDateLabel.Size = new System.Drawing.Size(110, 16);
            this.PurchaseDateLabel.TabIndex = 81;
            this.PurchaseDateLabel.Text = "Purchase Date";
            // 
            // PurchasePriceManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(369, 272);
            this.Controls.Add(this.PurchaseDateLabel);
            this.Controls.Add(this.SelectedPriceLabel);
            this.Controls.Add(this.SelectedProductPricesListBox);
            this.Controls.Add(this.ClearTextBoxesButton);
            this.Controls.Add(this.UpdateProductPriceButton);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.SelectProductLabel);
            this.Controls.Add(this.ProductsListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Firebrick;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PurchasePriceManagementForm";
            this.Text = "Purchase Price Management Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox SelectedProductPricesListBox;
        private System.Windows.Forms.Button ClearTextBoxesButton;
        private System.Windows.Forms.Button UpdateProductPriceButton;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Label SelectProductLabel;
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.Label SelectedPriceLabel;
        private System.Windows.Forms.Label PurchaseDateLabel;
    }
}