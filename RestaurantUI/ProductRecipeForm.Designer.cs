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
            this.DeleteRecipeButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.RecipeListLabel = new System.Windows.Forms.Label();
            this.RecipesListBox = new System.Windows.Forms.ListBox();
            this.RecipeNameLabel = new System.Windows.Forms.Label();
            this.RecipeNameTextBox = new System.Windows.Forms.TextBox();
            this.SelectedRecipeItemsLabel = new System.Windows.Forms.Label();
            this.SelectedRecipeContentListbox = new System.Windows.Forms.ListBox();
            this.CreateRecipeButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SelectRecipeItemstLabel = new System.Windows.Forms.Label();
            this.UpdateRecipeButton = new System.Windows.Forms.Button();
            this.RemoveRecipeItemButton = new System.Windows.Forms.Button();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.AddRecipeItemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeleteRecipeButton
            // 
            this.DeleteRecipeButton.Location = new System.Drawing.Point(15, 194);
            this.DeleteRecipeButton.Name = "DeleteRecipeButton";
            this.DeleteRecipeButton.Size = new System.Drawing.Size(128, 28);
            this.DeleteRecipeButton.TabIndex = 85;
            this.DeleteRecipeButton.Text = "Delete Recipe";
            this.DeleteRecipeButton.UseVisualStyleBackColor = true;
            this.DeleteRecipeButton.Click += new System.EventHandler(this.DeleteRecipeButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(605, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(26, 26);
            this.ExitButton.TabIndex = 84;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // RecipeListLabel
            // 
            this.RecipeListLabel.AutoSize = true;
            this.RecipeListLabel.Location = new System.Drawing.Point(475, 37);
            this.RecipeListLabel.Name = "RecipeListLabel";
            this.RecipeListLabel.Size = new System.Drawing.Size(75, 16);
            this.RecipeListLabel.TabIndex = 83;
            this.RecipeListLabel.Text = "Recipe List";
            // 
            // RecipesListBox
            // 
            this.RecipesListBox.FormattingEnabled = true;
            this.RecipesListBox.ItemHeight = 16;
            this.RecipesListBox.Location = new System.Drawing.Point(478, 58);
            this.RecipesListBox.Name = "RecipesListBox";
            this.RecipesListBox.Size = new System.Drawing.Size(135, 180);
            this.RecipesListBox.TabIndex = 82;
            this.RecipesListBox.SelectedIndexChanged += new System.EventHandler(this.RecipesListBox_SelectedIndexChanged);
            // 
            // RecipeNameLabel
            // 
            this.RecipeNameLabel.AutoSize = true;
            this.RecipeNameLabel.Location = new System.Drawing.Point(12, 9);
            this.RecipeNameLabel.Name = "RecipeNameLabel";
            this.RecipeNameLabel.Size = new System.Drawing.Size(92, 16);
            this.RecipeNameLabel.TabIndex = 81;
            this.RecipeNameLabel.Text = "Recipe Name";
            // 
            // RecipeNameTextBox
            // 
            this.RecipeNameTextBox.Location = new System.Drawing.Point(15, 30);
            this.RecipeNameTextBox.Name = "RecipeNameTextBox";
            this.RecipeNameTextBox.Size = new System.Drawing.Size(128, 22);
            this.RecipeNameTextBox.TabIndex = 80;
            // 
            // SelectedRecipeItemsLabel
            // 
            this.SelectedRecipeItemsLabel.AutoSize = true;
            this.SelectedRecipeItemsLabel.Location = new System.Drawing.Point(314, 37);
            this.SelectedRecipeItemsLabel.Name = "SelectedRecipeItemsLabel";
            this.SelectedRecipeItemsLabel.Size = new System.Drawing.Size(144, 16);
            this.SelectedRecipeItemsLabel.TabIndex = 79;
            this.SelectedRecipeItemsLabel.Text = "Selected Recipe Items";
            // 
            // SelectedRecipeContentListbox
            // 
            this.SelectedRecipeContentListbox.FormattingEnabled = true;
            this.SelectedRecipeContentListbox.ItemHeight = 16;
            this.SelectedRecipeContentListbox.Location = new System.Drawing.Point(317, 58);
            this.SelectedRecipeContentListbox.Name = "SelectedRecipeContentListbox";
            this.SelectedRecipeContentListbox.Size = new System.Drawing.Size(135, 180);
            this.SelectedRecipeContentListbox.TabIndex = 78;
            this.SelectedRecipeContentListbox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.SelectedRecipeContentListbox_Format);
            // 
            // CreateRecipeButton
            // 
            this.CreateRecipeButton.Location = new System.Drawing.Point(15, 58);
            this.CreateRecipeButton.Name = "CreateRecipeButton";
            this.CreateRecipeButton.Size = new System.Drawing.Size(128, 28);
            this.CreateRecipeButton.TabIndex = 77;
            this.CreateRecipeButton.Text = "Create";
            this.CreateRecipeButton.UseVisualStyleBackColor = true;
            this.CreateRecipeButton.Click += new System.EventHandler(this.CreateRecipeButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(15, 228);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(128, 28);
            this.ClearButton.TabIndex = 76;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SelectRecipeItemstLabel
            // 
            this.SelectRecipeItemstLabel.AutoSize = true;
            this.SelectRecipeItemstLabel.Location = new System.Drawing.Point(157, 37);
            this.SelectRecipeItemstLabel.Name = "SelectRecipeItemstLabel";
            this.SelectRecipeItemstLabel.Size = new System.Drawing.Size(128, 16);
            this.SelectRecipeItemstLabel.TabIndex = 75;
            this.SelectRecipeItemstLabel.Text = "Select Recipe Items";
            // 
            // UpdateRecipeButton
            // 
            this.UpdateRecipeButton.Location = new System.Drawing.Point(15, 160);
            this.UpdateRecipeButton.Name = "UpdateRecipeButton";
            this.UpdateRecipeButton.Size = new System.Drawing.Size(128, 28);
            this.UpdateRecipeButton.TabIndex = 74;
            this.UpdateRecipeButton.Text = "Update";
            this.UpdateRecipeButton.UseVisualStyleBackColor = true;
            this.UpdateRecipeButton.Click += new System.EventHandler(this.UpdateRecipeButton_Click);
            // 
            // RemoveRecipeItemButton
            // 
            this.RemoveRecipeItemButton.Location = new System.Drawing.Point(15, 126);
            this.RemoveRecipeItemButton.Name = "RemoveRecipeItemButton";
            this.RemoveRecipeItemButton.Size = new System.Drawing.Size(128, 28);
            this.RemoveRecipeItemButton.TabIndex = 73;
            this.RemoveRecipeItemButton.Text = "Remove Item";
            this.RemoveRecipeItemButton.UseVisualStyleBackColor = true;
            this.RemoveRecipeItemButton.Click += new System.EventHandler(this.RemoveRecipeItemButton_Click);
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 16;
            this.ProductsListBox.Location = new System.Drawing.Point(160, 58);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(135, 180);
            this.ProductsListBox.TabIndex = 72;
            // 
            // AddRecipeItemButton
            // 
            this.AddRecipeItemButton.Location = new System.Drawing.Point(15, 92);
            this.AddRecipeItemButton.Name = "AddRecipeItemButton";
            this.AddRecipeItemButton.Size = new System.Drawing.Size(128, 28);
            this.AddRecipeItemButton.TabIndex = 71;
            this.AddRecipeItemButton.Text = "Add Item";
            this.AddRecipeItemButton.UseVisualStyleBackColor = true;
            this.AddRecipeItemButton.Click += new System.EventHandler(this.AddRecipeItemButton_Click);
            // 
            // ProductRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(637, 276);
            this.Controls.Add(this.DeleteRecipeButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RecipeListLabel);
            this.Controls.Add(this.RecipesListBox);
            this.Controls.Add(this.RecipeNameLabel);
            this.Controls.Add(this.RecipeNameTextBox);
            this.Controls.Add(this.SelectedRecipeItemsLabel);
            this.Controls.Add(this.SelectedRecipeContentListbox);
            this.Controls.Add(this.CreateRecipeButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SelectRecipeItemstLabel);
            this.Controls.Add(this.UpdateRecipeButton);
            this.Controls.Add(this.RemoveRecipeItemButton);
            this.Controls.Add(this.ProductsListBox);
            this.Controls.Add(this.AddRecipeItemButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkOrange;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductRecipeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewProductRecipeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button DeleteRecipeButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label RecipeListLabel;
        private System.Windows.Forms.ListBox RecipesListBox;
        private System.Windows.Forms.Label RecipeNameLabel;
        private System.Windows.Forms.TextBox RecipeNameTextBox;
        private System.Windows.Forms.Label SelectedRecipeItemsLabel;
        private System.Windows.Forms.ListBox SelectedRecipeContentListbox;
        private System.Windows.Forms.Button CreateRecipeButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label SelectRecipeItemstLabel;
        private System.Windows.Forms.Button UpdateRecipeButton;
        private System.Windows.Forms.Button RemoveRecipeItemButton;
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.Button AddRecipeItemButton;
    }
}