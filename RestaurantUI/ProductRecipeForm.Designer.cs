namespace RestaurantUI
{
    partial class ProductRecipeForm
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
            this.SelectRecipeItemstLabel = new System.Windows.Forms.Label();
            this.UpdateRecipeButton = new System.Windows.Forms.Button();
            this.RemoveRecipeItemButton = new System.Windows.Forms.Button();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.SelectRecipeItemButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.FinishRecipeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectRecipeItemstLabel
            // 
            this.SelectRecipeItemstLabel.AutoSize = true;
            this.SelectRecipeItemstLabel.Location = new System.Drawing.Point(215, 9);
            this.SelectRecipeItemstLabel.Name = "SelectRecipeItemstLabel";
            this.SelectRecipeItemstLabel.Size = new System.Drawing.Size(139, 18);
            this.SelectRecipeItemstLabel.TabIndex = 58;
            this.SelectRecipeItemstLabel.Text = "Select Recipe Items";
            // 
            // UpdateRecipeButton
            // 
            this.UpdateRecipeButton.Location = new System.Drawing.Point(21, 123);
            this.UpdateRecipeButton.Name = "UpdateRecipeButton";
            this.UpdateRecipeButton.Size = new System.Drawing.Size(160, 28);
            this.UpdateRecipeButton.TabIndex = 55;
            this.UpdateRecipeButton.Text = "Update";
            this.UpdateRecipeButton.UseVisualStyleBackColor = true;
            // 
            // RemoveRecipeItemButton
            // 
            this.RemoveRecipeItemButton.Location = new System.Drawing.Point(21, 89);
            this.RemoveRecipeItemButton.Name = "RemoveRecipeItemButton";
            this.RemoveRecipeItemButton.Size = new System.Drawing.Size(160, 28);
            this.RemoveRecipeItemButton.TabIndex = 54;
            this.RemoveRecipeItemButton.Text = "Remove Item";
            this.RemoveRecipeItemButton.UseVisualStyleBackColor = true;
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 18;
            this.ProductsListBox.Location = new System.Drawing.Point(218, 30);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(164, 166);
            this.ProductsListBox.TabIndex = 51;
            // 
            // SelectRecipeItemButton
            // 
            this.SelectRecipeItemButton.Location = new System.Drawing.Point(21, 55);
            this.SelectRecipeItemButton.Name = "SelectRecipeItemButton";
            this.SelectRecipeItemButton.Size = new System.Drawing.Size(160, 28);
            this.SelectRecipeItemButton.TabIndex = 50;
            this.SelectRecipeItemButton.Text = "Select Item";
            this.SelectRecipeItemButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(21, 157);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(160, 28);
            this.CancelButton.TabIndex = 59;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // FinishRecipeButton
            // 
            this.FinishRecipeButton.Location = new System.Drawing.Point(21, 21);
            this.FinishRecipeButton.Name = "FinishRecipeButton";
            this.FinishRecipeButton.Size = new System.Drawing.Size(160, 28);
            this.FinishRecipeButton.TabIndex = 60;
            this.FinishRecipeButton.Text = "Finish";
            this.FinishRecipeButton.UseVisualStyleBackColor = true;
            // 
            // ProductRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(401, 207);
            this.Controls.Add(this.FinishRecipeButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SelectRecipeItemstLabel);
            this.Controls.Add(this.UpdateRecipeButton);
            this.Controls.Add(this.RemoveRecipeItemButton);
            this.Controls.Add(this.ProductsListBox);
            this.Controls.Add(this.SelectRecipeItemButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.IndianRed;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProductRecipeForm";
            this.ShowIcon = false;
            this.Text = "ProductRecipeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectRecipeItemstLabel;
        private System.Windows.Forms.Button UpdateRecipeButton;
        private System.Windows.Forms.Button RemoveRecipeItemButton;
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.Button SelectRecipeItemButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button FinishRecipeButton;
    }
}