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
            this.ClearTextBoxesButton = new System.Windows.Forms.Button();
            this.UpdateProductPriceButton = new System.Windows.Forms.Button();
            this.SelectedProductPricesListBox = new System.Windows.Forms.ListBox();
            this.IsCurrentlyActivePriceCheckBox = new System.Windows.Forms.CheckBox();
            this.DeletePriceButton = new System.Windows.Forms.Button();
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
            this.ProductsListBox.Size = new System.Drawing.Size(143, 238);
            this.ProductsListBox.TabIndex = 59;
            this.ProductsListBox.SelectedIndexChanged += new System.EventHandler(this.ProductsListBox_SelectedIndexChanged);
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(258, 27);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(89, 24);
            this.PriceTextBox.TabIndex = 61;
            // 
            // AssociatePriceButton
            // 
            this.AssociatePriceButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AssociatePriceButton.Location = new System.Drawing.Point(258, 58);
            this.AssociatePriceButton.Name = "AssociatePriceButton";
            this.AssociatePriceButton.Size = new System.Drawing.Size(125, 30);
            this.AssociatePriceButton.TabIndex = 62;
            this.AssociatePriceButton.Text = "Associate Price";
            this.AssociatePriceButton.UseVisualStyleBackColor = false;
            this.AssociatePriceButton.Click += new System.EventHandler(this.AssociatePriceButton_Click);
            // 
            // ClearTextBoxesButton
            // 
            this.ClearTextBoxesButton.Location = new System.Drawing.Point(114, 272);
            this.ClearTextBoxesButton.Name = "ClearTextBoxesButton";
            this.ClearTextBoxesButton.Size = new System.Drawing.Size(96, 28);
            this.ClearTextBoxesButton.TabIndex = 68;
            this.ClearTextBoxesButton.Text = "Clear";
            this.ClearTextBoxesButton.UseVisualStyleBackColor = true;
            this.ClearTextBoxesButton.Click += new System.EventHandler(this.ClearTextBoxesButton_Click);
            // 
            // UpdateProductPriceButton
            // 
            this.UpdateProductPriceButton.Location = new System.Drawing.Point(12, 272);
            this.UpdateProductPriceButton.Name = "UpdateProductPriceButton";
            this.UpdateProductPriceButton.Size = new System.Drawing.Size(96, 28);
            this.UpdateProductPriceButton.TabIndex = 67;
            this.UpdateProductPriceButton.Text = "Update";
            this.UpdateProductPriceButton.UseVisualStyleBackColor = true;
            this.UpdateProductPriceButton.Click += new System.EventHandler(this.UpdateProductPriceButton_Click);
            // 
            // SelectedProductPricesListBox
            // 
            this.SelectedProductPricesListBox.FormattingEnabled = true;
            this.SelectedProductPricesListBox.ItemHeight = 18;
            this.SelectedProductPricesListBox.Location = new System.Drawing.Point(161, 27);
            this.SelectedProductPricesListBox.Name = "SelectedProductPricesListBox";
            this.SelectedProductPricesListBox.Size = new System.Drawing.Size(91, 238);
            this.SelectedProductPricesListBox.TabIndex = 69;
            this.SelectedProductPricesListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedProductPricesListBox_SelectedIndexChanged);
            // 
            // IsCurrentlyActivePriceCheckBox
            // 
            this.IsCurrentlyActivePriceCheckBox.AutoSize = true;
            this.IsCurrentlyActivePriceCheckBox.Location = new System.Drawing.Point(258, 94);
            this.IsCurrentlyActivePriceCheckBox.Name = "IsCurrentlyActivePriceCheckBox";
            this.IsCurrentlyActivePriceCheckBox.Size = new System.Drawing.Size(167, 22);
            this.IsCurrentlyActivePriceCheckBox.TabIndex = 70;
            this.IsCurrentlyActivePriceCheckBox.Text = "Currently Active Price";
            this.IsCurrentlyActivePriceCheckBox.UseVisualStyleBackColor = true;
            // 
            // DeletePriceButton
            // 
            this.DeletePriceButton.Location = new System.Drawing.Point(216, 272);
            this.DeletePriceButton.Name = "DeletePriceButton";
            this.DeletePriceButton.Size = new System.Drawing.Size(96, 28);
            this.DeletePriceButton.TabIndex = 71;
            this.DeletePriceButton.Text = "Delete Price";
            this.DeletePriceButton.UseVisualStyleBackColor = true;
            this.DeletePriceButton.Click += new System.EventHandler(this.DeletePriceButton_Click);
            // 
            // PricingManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(426, 315);
            this.Controls.Add(this.DeletePriceButton);
            this.Controls.Add(this.IsCurrentlyActivePriceCheckBox);
            this.Controls.Add(this.SelectedProductPricesListBox);
            this.Controls.Add(this.ClearTextBoxesButton);
            this.Controls.Add(this.UpdateProductPriceButton);
            this.Controls.Add(this.AssociatePriceButton);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.SelectProductLabel);
            this.Controls.Add(this.ProductsListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SeaGreen;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button ClearTextBoxesButton;
        private System.Windows.Forms.Button UpdateProductPriceButton;
        private System.Windows.Forms.ListBox SelectedProductPricesListBox;
        private System.Windows.Forms.CheckBox IsCurrentlyActivePriceCheckBox;
        private System.Windows.Forms.Button DeletePriceButton;
    }
}