namespace RestaurantUI
{
    partial class CategoryManagementForm
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
            this.CreateCategoryButton = new System.Windows.Forms.Button();
            this.ProductCategoriesListBox = new System.Windows.Forms.ListBox();
            this.CategoryNameTextBox = new System.Windows.Forms.TextBox();
            this.CategoryNameLabel = new System.Windows.Forms.Label();
            this.UpdateCategoryButton = new System.Windows.Forms.Button();
            this.ClearCategoryNameTextBoxButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateCategoryButton
            // 
            this.CreateCategoryButton.Location = new System.Drawing.Point(15, 78);
            this.CreateCategoryButton.Name = "CreateCategoryButton";
            this.CreateCategoryButton.Size = new System.Drawing.Size(143, 28);
            this.CreateCategoryButton.TabIndex = 0;
            this.CreateCategoryButton.Text = "Create";
            this.CreateCategoryButton.UseVisualStyleBackColor = true;
            // 
            // ProductCategoriesListBox
            // 
            this.ProductCategoriesListBox.FormattingEnabled = true;
            this.ProductCategoriesListBox.ItemHeight = 18;
            this.ProductCategoriesListBox.Location = new System.Drawing.Point(197, 12);
            this.ProductCategoriesListBox.Name = "ProductCategoriesListBox";
            this.ProductCategoriesListBox.Size = new System.Drawing.Size(158, 166);
            this.ProductCategoriesListBox.TabIndex = 1;
            // 
            // CategoryNameTextBox
            // 
            this.CategoryNameTextBox.Location = new System.Drawing.Point(15, 30);
            this.CategoryNameTextBox.Name = "CategoryNameTextBox";
            this.CategoryNameTextBox.Size = new System.Drawing.Size(143, 24);
            this.CategoryNameTextBox.TabIndex = 2;
            // 
            // CategoryNameLabel
            // 
            this.CategoryNameLabel.AutoSize = true;
            this.CategoryNameLabel.Location = new System.Drawing.Point(12, 9);
            this.CategoryNameLabel.Name = "CategoryNameLabel";
            this.CategoryNameLabel.Size = new System.Drawing.Size(112, 18);
            this.CategoryNameLabel.TabIndex = 3;
            this.CategoryNameLabel.Text = "Category Name";
            // 
            // UpdateCategoryButton
            // 
            this.UpdateCategoryButton.Location = new System.Drawing.Point(15, 112);
            this.UpdateCategoryButton.Name = "UpdateCategoryButton";
            this.UpdateCategoryButton.Size = new System.Drawing.Size(143, 28);
            this.UpdateCategoryButton.TabIndex = 4;
            this.UpdateCategoryButton.Text = "Update";
            this.UpdateCategoryButton.UseVisualStyleBackColor = true;
            // 
            // ClearCategoryNameTextBoxButton
            // 
            this.ClearCategoryNameTextBoxButton.Location = new System.Drawing.Point(15, 146);
            this.ClearCategoryNameTextBoxButton.Name = "ClearCategoryNameTextBoxButton";
            this.ClearCategoryNameTextBoxButton.Size = new System.Drawing.Size(143, 28);
            this.ClearCategoryNameTextBoxButton.TabIndex = 5;
            this.ClearCategoryNameTextBoxButton.Text = "Clear";
            this.ClearCategoryNameTextBoxButton.UseVisualStyleBackColor = true;
            // 
            // CategoryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(383, 198);
            this.Controls.Add(this.ClearCategoryNameTextBoxButton);
            this.Controls.Add(this.UpdateCategoryButton);
            this.Controls.Add(this.CategoryNameLabel);
            this.Controls.Add(this.CategoryNameTextBox);
            this.Controls.Add(this.ProductCategoriesListBox);
            this.Controls.Add(this.CreateCategoryButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CategoryManagementForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Category Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateCategoryButton;
        private System.Windows.Forms.ListBox ProductCategoriesListBox;
        private System.Windows.Forms.TextBox CategoryNameTextBox;
        private System.Windows.Forms.Label CategoryNameLabel;
        private System.Windows.Forms.Button UpdateCategoryButton;
        private System.Windows.Forms.Button ClearCategoryNameTextBoxButton;
    }
}