namespace RestaurantUI
{
    partial class PricingManagementForm
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
            this.SelectProductLabel = new System.Windows.Forms.Label();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.AssociatePriceButton = new System.Windows.Forms.Button();
            this.ImportPriceListButton = new System.Windows.Forms.Button();
            this.PriceListPathLabel = new System.Windows.Forms.Label();
            this.PriceListFilePathLabel = new System.Windows.Forms.Label();
            this.ClearTextBoxesButton = new System.Windows.Forms.Button();
            this.UpdateProductPriceButton = new System.Windows.Forms.Button();
            this.FinishPriceImportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectProductLabel
            // 
            this.SelectProductLabel.AutoSize = true;
            this.SelectProductLabel.Location = new System.Drawing.Point(12, 6);
            this.SelectProductLabel.Name = "SelectProductLabel";
            this.SelectProductLabel.Size = new System.Drawing.Size(105, 18);
            this.SelectProductLabel.TabIndex = 60;
            this.SelectProductLabel.Text = "Select Product";
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 18;
            this.ProductsListBox.Location = new System.Drawing.Point(12, 27);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(164, 184);
            this.ProductsListBox.TabIndex = 59;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(221, 25);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(89, 24);
            this.PriceTextBox.TabIndex = 61;
            // 
            // AssociatePriceButton
            // 
            this.AssociatePriceButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AssociatePriceButton.Location = new System.Drawing.Point(221, 56);
            this.AssociatePriceButton.Name = "AssociatePriceButton";
            this.AssociatePriceButton.Size = new System.Drawing.Size(159, 30);
            this.AssociatePriceButton.TabIndex = 62;
            this.AssociatePriceButton.Text = "Associate Price";
            this.AssociatePriceButton.UseVisualStyleBackColor = false;
            // 
            // ImportPriceListButton
            // 
            this.ImportPriceListButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ImportPriceListButton.Location = new System.Drawing.Point(221, 120);
            this.ImportPriceListButton.Name = "ImportPriceListButton";
            this.ImportPriceListButton.Size = new System.Drawing.Size(159, 30);
            this.ImportPriceListButton.TabIndex = 63;
            this.ImportPriceListButton.Text = "Import Price List";
            this.ImportPriceListButton.UseVisualStyleBackColor = false;
            // 
            // PriceListPathLabel
            // 
            this.PriceListPathLabel.AutoSize = true;
            this.PriceListPathLabel.Location = new System.Drawing.Point(218, 162);
            this.PriceListPathLabel.Name = "PriceListPathLabel";
            this.PriceListPathLabel.Size = new System.Drawing.Size(111, 18);
            this.PriceListPathLabel.TabIndex = 64;
            this.PriceListPathLabel.Text = "Price List Path: ";
            // 
            // PriceListFilePathLabel
            // 
            this.PriceListFilePathLabel.AutoSize = true;
            this.PriceListFilePathLabel.Location = new System.Drawing.Point(335, 162);
            this.PriceListFilePathLabel.Name = "PriceListFilePathLabel";
            this.PriceListFilePathLabel.Size = new System.Drawing.Size(20, 18);
            this.PriceListFilePathLabel.TabIndex = 65;
            this.PriceListFilePathLabel.Text = "...";
            // 
            // ClearTextBoxesButton
            // 
            this.ClearTextBoxesButton.Location = new System.Drawing.Point(148, 227);
            this.ClearTextBoxesButton.Name = "ClearTextBoxesButton";
            this.ClearTextBoxesButton.Size = new System.Drawing.Size(127, 28);
            this.ClearTextBoxesButton.TabIndex = 68;
            this.ClearTextBoxesButton.Text = "Clear";
            this.ClearTextBoxesButton.UseVisualStyleBackColor = true;
            this.ClearTextBoxesButton.Click += new System.EventHandler(this.ClearTextBoxesButton_Click);
            // 
            // UpdateProductPriceButton
            // 
            this.UpdateProductPriceButton.Location = new System.Drawing.Point(15, 227);
            this.UpdateProductPriceButton.Name = "UpdateProductPriceButton";
            this.UpdateProductPriceButton.Size = new System.Drawing.Size(127, 28);
            this.UpdateProductPriceButton.TabIndex = 67;
            this.UpdateProductPriceButton.Text = "Update";
            this.UpdateProductPriceButton.UseVisualStyleBackColor = true;
            // 
            // FinishPriceImportButton
            // 
            this.FinishPriceImportButton.Location = new System.Drawing.Point(221, 183);
            this.FinishPriceImportButton.Name = "FinishPriceImportButton";
            this.FinishPriceImportButton.Size = new System.Drawing.Size(159, 28);
            this.FinishPriceImportButton.TabIndex = 66;
            this.FinishPriceImportButton.Text = "Finish Import";
            this.FinishPriceImportButton.UseVisualStyleBackColor = true;
            // 
            // PricingManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(421, 262);
            this.Controls.Add(this.ClearTextBoxesButton);
            this.Controls.Add(this.UpdateProductPriceButton);
            this.Controls.Add(this.FinishPriceImportButton);
            this.Controls.Add(this.PriceListFilePathLabel);
            this.Controls.Add(this.PriceListPathLabel);
            this.Controls.Add(this.ImportPriceListButton);
            this.Controls.Add(this.AssociatePriceButton);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.SelectProductLabel);
            this.Controls.Add(this.ProductsListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SeaGreen;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PricingManagementForm";
            this.ShowIcon = false;
            this.Text = "Pricing Management Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectProductLabel;
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Button AssociatePriceButton;
        private System.Windows.Forms.Button ImportPriceListButton;
        private System.Windows.Forms.Label PriceListPathLabel;
        private System.Windows.Forms.Label PriceListFilePathLabel;
        private System.Windows.Forms.Button ClearTextBoxesButton;
        private System.Windows.Forms.Button UpdateProductPriceButton;
        private System.Windows.Forms.Button FinishPriceImportButton;
    }
}