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
            this.ExitFormButton = new System.Windows.Forms.Button();
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
            this.CreateCategoryButton.Click += new System.EventHandler(this.CreateCategoryButton_Click);
            // 
            // ProductCategoriesListBox
            // 
            this.ProductCategoriesListBox.FormattingEnabled = true;
            this.ProductCategoriesListBox.ItemHeight = 18;
            this.ProductCategoriesListBox.Location = new System.Drawing.Point(189, 30);
            this.ProductCategoriesListBox.Name = "ProductCategoriesListBox";
            this.ProductCategoriesListBox.Size = new System.Drawing.Size(171, 166);
            this.ProductCategoriesListBox.TabIndex = 1;
            this.ProductCategoriesListBox.SelectedIndexChanged += new System.EventHandler(this.ProductCategoriesListBox_SelectedIndexChanged);
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
            this.UpdateCategoryButton.Click += new System.EventHandler(this.UpdateCategoryButton_Click);
            // 
            // ClearCategoryNameTextBoxButton
            // 
            this.ClearCategoryNameTextBoxButton.Location = new System.Drawing.Point(15, 146);
            this.ClearCategoryNameTextBoxButton.Name = "ClearCategoryNameTextBoxButton";
            this.ClearCategoryNameTextBoxButton.Size = new System.Drawing.Size(143, 28);
            this.ClearCategoryNameTextBoxButton.TabIndex = 5;
            this.ClearCategoryNameTextBoxButton.Text = "Clear";
            this.ClearCategoryNameTextBoxButton.UseVisualStyleBackColor = true;
            this.ClearCategoryNameTextBoxButton.Click += new System.EventHandler(this.ClearCategoryNameTextBoxButton_Click);
            // 
            // ExitFormButton
            // 
            this.ExitFormButton.Location = new System.Drawing.Point(358, 1);
            this.ExitFormButton.Name = "ExitFormButton";
            this.ExitFormButton.Size = new System.Drawing.Size(26, 26);
            this.ExitFormButton.TabIndex = 6;
            this.ExitFormButton.Text = "X";
            this.ExitFormButton.UseVisualStyleBackColor = true;
            this.ExitFormButton.Click += new System.EventHandler(this.ExitFormButton_Click);
            // 
            // CategoryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(386, 208);
            this.Controls.Add(this.ExitFormButton);
            this.Controls.Add(this.ClearCategoryNameTextBoxButton);
            this.Controls.Add(this.UpdateCategoryButton);
            this.Controls.Add(this.CategoryNameLabel);
            this.Controls.Add(this.CategoryNameTextBox);
            this.Controls.Add(this.ProductCategoriesListBox);
            this.Controls.Add(this.CreateCategoryButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Button ExitFormButton;
    }
}