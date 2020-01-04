namespace RestaurantUI
{
    partial class ProductManagementForm
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
            this.ClearProductTextBoxesButton = new System.Windows.Forms.Button();
            this.UpdateProductButton = new System.Windows.Forms.Button();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.CreateProductButton = new System.Windows.Forms.Button();
            this.RecipesListBox = new System.Windows.Forms.ListBox();
            this.AssociateRecipeButton = new System.Windows.Forms.Button();
            this.ProductListLabel = new System.Windows.Forms.Label();
            this.RecipeListLabel = new System.Windows.Forms.Label();
            this.ProductCategoryLabel = new System.Windows.Forms.Label();
            this.ProductCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.CreateNewCategorylinkLabel = new System.Windows.Forms.LinkLabel();
            this.CreateNewRecipeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ProductRecipeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ClearProductTextBoxesButton
            // 
            this.ClearProductTextBoxesButton.Location = new System.Drawing.Point(308, 312);
            this.ClearProductTextBoxesButton.Name = "ClearProductTextBoxesButton";
            this.ClearProductTextBoxesButton.Size = new System.Drawing.Size(70, 28);
            this.ClearProductTextBoxesButton.TabIndex = 45;
            this.ClearProductTextBoxesButton.Text = "Clear";
            this.ClearProductTextBoxesButton.UseVisualStyleBackColor = true;
            this.ClearProductTextBoxesButton.Click += new System.EventHandler(this.ClearProductTextBoxesButton_Click);
            // 
            // UpdateProductButton
            // 
            this.UpdateProductButton.Location = new System.Drawing.Point(162, 312);
            this.UpdateProductButton.Name = "UpdateProductButton";
            this.UpdateProductButton.Size = new System.Drawing.Size(140, 28);
            this.UpdateProductButton.TabIndex = 41;
            this.UpdateProductButton.Text = "Update Product";
            this.UpdateProductButton.UseVisualStyleBackColor = true;
            this.UpdateProductButton.Click += new System.EventHandler(this.UpdateProductButton_Click);
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.AutoSize = true;
            this.ProductNameLabel.Location = new System.Drawing.Point(13, 36);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(104, 18);
            this.ProductNameLabel.TabIndex = 40;
            this.ProductNameLabel.Text = "Product Name";
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.Location = new System.Drawing.Point(16, 57);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(160, 24);
            this.ProductNameTextBox.TabIndex = 39;
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 18;
            this.ProductsListBox.Location = new System.Drawing.Point(200, 43);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(164, 238);
            this.ProductsListBox.TabIndex = 38;
            this.ProductsListBox.SelectedIndexChanged += new System.EventHandler(this.ProductsListBox_SelectedIndexChanged);
            // 
            // CreateProductButton
            // 
            this.CreateProductButton.Location = new System.Drawing.Point(16, 312);
            this.CreateProductButton.Name = "CreateProductButton";
            this.CreateProductButton.Size = new System.Drawing.Size(140, 28);
            this.CreateProductButton.TabIndex = 37;
            this.CreateProductButton.Text = "Create Product";
            this.CreateProductButton.UseVisualStyleBackColor = true;
            this.CreateProductButton.Click += new System.EventHandler(this.CreateProductButton_Click);
            // 
            // RecipesListBox
            // 
            this.RecipesListBox.FormattingEnabled = true;
            this.RecipesListBox.ItemHeight = 18;
            this.RecipesListBox.Location = new System.Drawing.Point(370, 43);
            this.RecipesListBox.Name = "RecipesListBox";
            this.RecipesListBox.Size = new System.Drawing.Size(163, 238);
            this.RecipesListBox.TabIndex = 47;
            // 
            // AssociateRecipeButton
            // 
            this.AssociateRecipeButton.Location = new System.Drawing.Point(16, 242);
            this.AssociateRecipeButton.Name = "AssociateRecipeButton";
            this.AssociateRecipeButton.Size = new System.Drawing.Size(160, 28);
            this.AssociateRecipeButton.TabIndex = 48;
            this.AssociateRecipeButton.Text = "Associate Recipe";
            this.AssociateRecipeButton.UseVisualStyleBackColor = true;
            this.AssociateRecipeButton.Click += new System.EventHandler(this.AssociateRecipeButton_Click);
            // 
            // ProductListLabel
            // 
            this.ProductListLabel.AutoSize = true;
            this.ProductListLabel.Location = new System.Drawing.Point(197, 22);
            this.ProductListLabel.Name = "ProductListLabel";
            this.ProductListLabel.Size = new System.Drawing.Size(87, 18);
            this.ProductListLabel.TabIndex = 49;
            this.ProductListLabel.Text = "Product List";
            // 
            // RecipeListLabel
            // 
            this.RecipeListLabel.AutoSize = true;
            this.RecipeListLabel.Location = new System.Drawing.Point(367, 22);
            this.RecipeListLabel.Name = "RecipeListLabel";
            this.RecipeListLabel.Size = new System.Drawing.Size(81, 18);
            this.RecipeListLabel.TabIndex = 50;
            this.RecipeListLabel.Text = "Recipe List";
            // 
            // ProductCategoryLabel
            // 
            this.ProductCategoryLabel.AutoSize = true;
            this.ProductCategoryLabel.Location = new System.Drawing.Point(13, 114);
            this.ProductCategoryLabel.Name = "ProductCategoryLabel";
            this.ProductCategoryLabel.Size = new System.Drawing.Size(124, 18);
            this.ProductCategoryLabel.TabIndex = 53;
            this.ProductCategoryLabel.Text = "Product Category";
            // 
            // ProductCategoryComboBox
            // 
            this.ProductCategoryComboBox.FormattingEnabled = true;
            this.ProductCategoryComboBox.Location = new System.Drawing.Point(16, 140);
            this.ProductCategoryComboBox.Name = "ProductCategoryComboBox";
            this.ProductCategoryComboBox.Size = new System.Drawing.Size(160, 26);
            this.ProductCategoryComboBox.TabIndex = 54;
            // 
            // CreateNewCategorylinkLabel
            // 
            this.CreateNewCategorylinkLabel.AutoSize = true;
            this.CreateNewCategorylinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewCategorylinkLabel.LinkColor = System.Drawing.Color.DodgerBlue;
            this.CreateNewCategorylinkLabel.Location = new System.Drawing.Point(88, 169);
            this.CreateNewCategorylinkLabel.Name = "CreateNewCategorylinkLabel";
            this.CreateNewCategorylinkLabel.Size = new System.Drawing.Size(88, 16);
            this.CreateNewCategorylinkLabel.TabIndex = 55;
            this.CreateNewCategorylinkLabel.TabStop = true;
            this.CreateNewCategorylinkLabel.Text = "Create New";
            this.CreateNewCategorylinkLabel.VisitedLinkColor = System.Drawing.Color.DarkCyan;
            this.CreateNewCategorylinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateNewCategorylinkLabel_LinkClicked);
            // 
            // CreateNewRecipeLinkLabel
            // 
            this.CreateNewRecipeLinkLabel.AutoSize = true;
            this.CreateNewRecipeLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewRecipeLinkLabel.LinkColor = System.Drawing.Color.DodgerBlue;
            this.CreateNewRecipeLinkLabel.Location = new System.Drawing.Point(88, 273);
            this.CreateNewRecipeLinkLabel.Name = "CreateNewRecipeLinkLabel";
            this.CreateNewRecipeLinkLabel.Size = new System.Drawing.Size(88, 16);
            this.CreateNewRecipeLinkLabel.TabIndex = 56;
            this.CreateNewRecipeLinkLabel.TabStop = true;
            this.CreateNewRecipeLinkLabel.Text = "Create New";
            this.CreateNewRecipeLinkLabel.VisitedLinkColor = System.Drawing.Color.DarkCyan;
            this.CreateNewRecipeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateNewRecipeLinkLabel_LinkClicked);
            // 
            // ProductRecipeCheckBox
            // 
            this.ProductRecipeCheckBox.AutoSize = true;
            this.ProductRecipeCheckBox.Location = new System.Drawing.Point(16, 214);
            this.ProductRecipeCheckBox.Name = "ProductRecipeCheckBox";
            this.ProductRecipeCheckBox.Size = new System.Drawing.Size(129, 22);
            this.ProductRecipeCheckBox.TabIndex = 46;
            this.ProductRecipeCheckBox.Text = "Product Recipe";
            this.ProductRecipeCheckBox.UseVisualStyleBackColor = true;
            // 
            // ProductManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(552, 354);
            this.Controls.Add(this.CreateNewRecipeLinkLabel);
            this.Controls.Add(this.CreateNewCategorylinkLabel);
            this.Controls.Add(this.ProductCategoryComboBox);
            this.Controls.Add(this.ProductCategoryLabel);
            this.Controls.Add(this.RecipeListLabel);
            this.Controls.Add(this.ProductListLabel);
            this.Controls.Add(this.AssociateRecipeButton);
            this.Controls.Add(this.RecipesListBox);
            this.Controls.Add(this.ProductRecipeCheckBox);
            this.Controls.Add(this.ClearProductTextBoxesButton);
            this.Controls.Add(this.UpdateProductButton);
            this.Controls.Add(this.ProductNameLabel);
            this.Controls.Add(this.ProductNameTextBox);
            this.Controls.Add(this.ProductsListBox);
            this.Controls.Add(this.CreateProductButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductManagementForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Management Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ClearProductTextBoxesButton;
        private System.Windows.Forms.Button UpdateProductButton;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.Button CreateProductButton;
        private System.Windows.Forms.ListBox RecipesListBox;
        private System.Windows.Forms.Button AssociateRecipeButton;
        private System.Windows.Forms.Label ProductListLabel;
        private System.Windows.Forms.Label RecipeListLabel;
        private System.Windows.Forms.Label ProductCategoryLabel;
        private System.Windows.Forms.ComboBox ProductCategoryComboBox;
        private System.Windows.Forms.LinkLabel CreateNewCategorylinkLabel;
        private System.Windows.Forms.LinkLabel CreateNewRecipeLinkLabel;
        private System.Windows.Forms.CheckBox ProductRecipeCheckBox;
    }
}