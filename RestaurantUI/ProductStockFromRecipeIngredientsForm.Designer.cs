namespace RestaurantUI
{
    partial class ProductStockFromRecipeIngredientsForm
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
            this.ProductListLabel = new System.Windows.Forms.Label();
            this.CreateProductStockButton = new System.Windows.Forms.Button();
            this.IngredientsListBox = new System.Windows.Forms.ListBox();
            this.RecipeIngredientsLabel = new System.Windows.Forms.Label();
            this.ProductListBox = new System.Windows.Forms.ListBox();
            this.ProductStockDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.ProductTotalStockQuantityLabel = new System.Windows.Forms.Label();
            this.ProductBookedQuantityLabel = new System.Windows.Forms.Label();
            this.ProductAvailableQuantityLabel = new System.Windows.Forms.Label();
            this.ProductAvailableStockLabel = new System.Windows.Forms.Label();
            this.ProductBookedStockLabel = new System.Windows.Forms.Label();
            this.ProductTotalStockLabel = new System.Windows.Forms.Label();
            this.IngredientStockGroupBox = new System.Windows.Forms.GroupBox();
            this.IngredientTotalStockQuantityLabel = new System.Windows.Forms.Label();
            this.IngredientBookedQuantityLabel = new System.Windows.Forms.Label();
            this.IngredientAvailableQuantityLabel = new System.Windows.Forms.Label();
            this.IngredientAvailableStockLabel = new System.Windows.Forms.Label();
            this.IngredientBookedStockLabel = new System.Windows.Forms.Label();
            this.IngredientTotalStockLabel = new System.Windows.Forms.Label();
            this.QuantityToCreateLabel = new System.Windows.Forms.Label();
            this.QuantityToCreateTextBox = new System.Windows.Forms.TextBox();
            this.FinishButton = new System.Windows.Forms.Button();
            this.ProductStockDetailsGroupBox.SuspendLayout();
            this.IngredientStockGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductListLabel
            // 
            this.ProductListLabel.AutoSize = true;
            this.ProductListLabel.Location = new System.Drawing.Point(12, 18);
            this.ProductListLabel.Name = "ProductListLabel";
            this.ProductListLabel.Size = new System.Drawing.Size(89, 16);
            this.ProductListLabel.TabIndex = 52;
            this.ProductListLabel.Text = "Product List";
            // 
            // CreateProductStockButton
            // 
            this.CreateProductStockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateProductStockButton.Location = new System.Drawing.Point(383, 95);
            this.CreateProductStockButton.Name = "CreateProductStockButton";
            this.CreateProductStockButton.Size = new System.Drawing.Size(150, 28);
            this.CreateProductStockButton.TabIndex = 51;
            this.CreateProductStockButton.Text = "Create Product Stock";
            this.CreateProductStockButton.UseVisualStyleBackColor = true;
            this.CreateProductStockButton.Click += new System.EventHandler(this.CreateProductStockButton_Click);
            // 
            // IngredientsListBox
            // 
            this.IngredientsListBox.FormattingEnabled = true;
            this.IngredientsListBox.ItemHeight = 16;
            this.IngredientsListBox.Location = new System.Drawing.Point(201, 48);
            this.IngredientsListBox.Name = "IngredientsListBox";
            this.IngredientsListBox.Size = new System.Drawing.Size(164, 196);
            this.IngredientsListBox.TabIndex = 50;
            this.IngredientsListBox.SelectedIndexChanged += new System.EventHandler(this.IngredientsListBox_SelectedIndexChanged);
            // 
            // RecipeIngredientsLabel
            // 
            this.RecipeIngredientsLabel.AutoSize = true;
            this.RecipeIngredientsLabel.Location = new System.Drawing.Point(196, 18);
            this.RecipeIngredientsLabel.Name = "RecipeIngredientsLabel";
            this.RecipeIngredientsLabel.Size = new System.Drawing.Size(139, 16);
            this.RecipeIngredientsLabel.TabIndex = 53;
            this.RecipeIngredientsLabel.Text = "Recipe Ingredients";
            // 
            // ProductListBox
            // 
            this.ProductListBox.FormattingEnabled = true;
            this.ProductListBox.ItemHeight = 16;
            this.ProductListBox.Location = new System.Drawing.Point(17, 48);
            this.ProductListBox.Name = "ProductListBox";
            this.ProductListBox.Size = new System.Drawing.Size(164, 196);
            this.ProductListBox.TabIndex = 54;
            this.ProductListBox.SelectedIndexChanged += new System.EventHandler(this.ProductListBox_SelectedIndexChanged);
            // 
            // ProductStockDetailsGroupBox
            // 
            this.ProductStockDetailsGroupBox.Controls.Add(this.ProductTotalStockQuantityLabel);
            this.ProductStockDetailsGroupBox.Controls.Add(this.ProductBookedQuantityLabel);
            this.ProductStockDetailsGroupBox.Controls.Add(this.ProductAvailableQuantityLabel);
            this.ProductStockDetailsGroupBox.Controls.Add(this.ProductAvailableStockLabel);
            this.ProductStockDetailsGroupBox.Controls.Add(this.ProductBookedStockLabel);
            this.ProductStockDetailsGroupBox.Controls.Add(this.ProductTotalStockLabel);
            this.ProductStockDetailsGroupBox.Location = new System.Drawing.Point(15, 248);
            this.ProductStockDetailsGroupBox.Name = "ProductStockDetailsGroupBox";
            this.ProductStockDetailsGroupBox.Size = new System.Drawing.Size(166, 102);
            this.ProductStockDetailsGroupBox.TabIndex = 55;
            this.ProductStockDetailsGroupBox.TabStop = false;
            this.ProductStockDetailsGroupBox.Text = "Product Stock";
            // 
            // ProductTotalStockQuantityLabel
            // 
            this.ProductTotalStockQuantityLabel.AutoSize = true;
            this.ProductTotalStockQuantityLabel.Location = new System.Drawing.Point(99, 19);
            this.ProductTotalStockQuantityLabel.Name = "ProductTotalStockQuantityLabel";
            this.ProductTotalStockQuantityLabel.Size = new System.Drawing.Size(16, 16);
            this.ProductTotalStockQuantityLabel.TabIndex = 13;
            this.ProductTotalStockQuantityLabel.Text = "0";
            // 
            // ProductBookedQuantityLabel
            // 
            this.ProductBookedQuantityLabel.AutoSize = true;
            this.ProductBookedQuantityLabel.Location = new System.Drawing.Point(74, 44);
            this.ProductBookedQuantityLabel.Name = "ProductBookedQuantityLabel";
            this.ProductBookedQuantityLabel.Size = new System.Drawing.Size(16, 16);
            this.ProductBookedQuantityLabel.TabIndex = 12;
            this.ProductBookedQuantityLabel.Text = "0";
            // 
            // ProductAvailableQuantityLabel
            // 
            this.ProductAvailableQuantityLabel.AutoSize = true;
            this.ProductAvailableQuantityLabel.Location = new System.Drawing.Point(86, 69);
            this.ProductAvailableQuantityLabel.Name = "ProductAvailableQuantityLabel";
            this.ProductAvailableQuantityLabel.Size = new System.Drawing.Size(16, 16);
            this.ProductAvailableQuantityLabel.TabIndex = 11;
            this.ProductAvailableQuantityLabel.Text = "0";
            // 
            // ProductAvailableStockLabel
            // 
            this.ProductAvailableStockLabel.AutoSize = true;
            this.ProductAvailableStockLabel.Location = new System.Drawing.Point(6, 69);
            this.ProductAvailableStockLabel.Name = "ProductAvailableStockLabel";
            this.ProductAvailableStockLabel.Size = new System.Drawing.Size(82, 16);
            this.ProductAvailableStockLabel.TabIndex = 10;
            this.ProductAvailableStockLabel.Text = "Available :";
            // 
            // ProductBookedStockLabel
            // 
            this.ProductBookedStockLabel.AutoSize = true;
            this.ProductBookedStockLabel.Location = new System.Drawing.Point(6, 44);
            this.ProductBookedStockLabel.Name = "ProductBookedStockLabel";
            this.ProductBookedStockLabel.Size = new System.Drawing.Size(70, 16);
            this.ProductBookedStockLabel.TabIndex = 9;
            this.ProductBookedStockLabel.Text = "Booked :";
            // 
            // ProductTotalStockLabel
            // 
            this.ProductTotalStockLabel.AutoSize = true;
            this.ProductTotalStockLabel.Location = new System.Drawing.Point(6, 19);
            this.ProductTotalStockLabel.Name = "ProductTotalStockLabel";
            this.ProductTotalStockLabel.Size = new System.Drawing.Size(95, 16);
            this.ProductTotalStockLabel.TabIndex = 8;
            this.ProductTotalStockLabel.Text = "Total Stock :";
            // 
            // IngredientStockGroupBox
            // 
            this.IngredientStockGroupBox.Controls.Add(this.IngredientTotalStockQuantityLabel);
            this.IngredientStockGroupBox.Controls.Add(this.IngredientBookedQuantityLabel);
            this.IngredientStockGroupBox.Controls.Add(this.IngredientAvailableQuantityLabel);
            this.IngredientStockGroupBox.Controls.Add(this.IngredientAvailableStockLabel);
            this.IngredientStockGroupBox.Controls.Add(this.IngredientBookedStockLabel);
            this.IngredientStockGroupBox.Controls.Add(this.IngredientTotalStockLabel);
            this.IngredientStockGroupBox.Location = new System.Drawing.Point(199, 248);
            this.IngredientStockGroupBox.Name = "IngredientStockGroupBox";
            this.IngredientStockGroupBox.Size = new System.Drawing.Size(166, 102);
            this.IngredientStockGroupBox.TabIndex = 56;
            this.IngredientStockGroupBox.TabStop = false;
            this.IngredientStockGroupBox.Text = "Ingredient Stock";
            // 
            // IngredientTotalStockQuantityLabel
            // 
            this.IngredientTotalStockQuantityLabel.AutoSize = true;
            this.IngredientTotalStockQuantityLabel.Location = new System.Drawing.Point(99, 19);
            this.IngredientTotalStockQuantityLabel.Name = "IngredientTotalStockQuantityLabel";
            this.IngredientTotalStockQuantityLabel.Size = new System.Drawing.Size(16, 16);
            this.IngredientTotalStockQuantityLabel.TabIndex = 13;
            this.IngredientTotalStockQuantityLabel.Text = "0";
            // 
            // IngredientBookedQuantityLabel
            // 
            this.IngredientBookedQuantityLabel.AutoSize = true;
            this.IngredientBookedQuantityLabel.Location = new System.Drawing.Point(74, 44);
            this.IngredientBookedQuantityLabel.Name = "IngredientBookedQuantityLabel";
            this.IngredientBookedQuantityLabel.Size = new System.Drawing.Size(16, 16);
            this.IngredientBookedQuantityLabel.TabIndex = 12;
            this.IngredientBookedQuantityLabel.Text = "0";
            // 
            // IngredientAvailableQuantityLabel
            // 
            this.IngredientAvailableQuantityLabel.AutoSize = true;
            this.IngredientAvailableQuantityLabel.Location = new System.Drawing.Point(86, 69);
            this.IngredientAvailableQuantityLabel.Name = "IngredientAvailableQuantityLabel";
            this.IngredientAvailableQuantityLabel.Size = new System.Drawing.Size(16, 16);
            this.IngredientAvailableQuantityLabel.TabIndex = 11;
            this.IngredientAvailableQuantityLabel.Text = "0";
            // 
            // IngredientAvailableStockLabel
            // 
            this.IngredientAvailableStockLabel.AutoSize = true;
            this.IngredientAvailableStockLabel.Location = new System.Drawing.Point(6, 69);
            this.IngredientAvailableStockLabel.Name = "IngredientAvailableStockLabel";
            this.IngredientAvailableStockLabel.Size = new System.Drawing.Size(82, 16);
            this.IngredientAvailableStockLabel.TabIndex = 10;
            this.IngredientAvailableStockLabel.Text = "Available :";
            // 
            // IngredientBookedStockLabel
            // 
            this.IngredientBookedStockLabel.AutoSize = true;
            this.IngredientBookedStockLabel.Location = new System.Drawing.Point(6, 44);
            this.IngredientBookedStockLabel.Name = "IngredientBookedStockLabel";
            this.IngredientBookedStockLabel.Size = new System.Drawing.Size(70, 16);
            this.IngredientBookedStockLabel.TabIndex = 9;
            this.IngredientBookedStockLabel.Text = "Booked :";
            // 
            // IngredientTotalStockLabel
            // 
            this.IngredientTotalStockLabel.AutoSize = true;
            this.IngredientTotalStockLabel.Location = new System.Drawing.Point(6, 19);
            this.IngredientTotalStockLabel.Name = "IngredientTotalStockLabel";
            this.IngredientTotalStockLabel.Size = new System.Drawing.Size(95, 16);
            this.IngredientTotalStockLabel.TabIndex = 8;
            this.IngredientTotalStockLabel.Text = "Total Stock :";
            // 
            // QuantityToCreateLabel
            // 
            this.QuantityToCreateLabel.AutoSize = true;
            this.QuantityToCreateLabel.Location = new System.Drawing.Point(380, 48);
            this.QuantityToCreateLabel.Name = "QuantityToCreateLabel";
            this.QuantityToCreateLabel.Size = new System.Drawing.Size(133, 16);
            this.QuantityToCreateLabel.TabIndex = 58;
            this.QuantityToCreateLabel.Text = "Quantity to create:";
            // 
            // QuantityToCreateTextBox
            // 
            this.QuantityToCreateTextBox.Location = new System.Drawing.Point(383, 67);
            this.QuantityToCreateTextBox.Name = "QuantityToCreateTextBox";
            this.QuantityToCreateTextBox.Size = new System.Drawing.Size(61, 22);
            this.QuantityToCreateTextBox.TabIndex = 57;
            this.QuantityToCreateTextBox.Text = "1";
            this.QuantityToCreateTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuantityToCreateTextBox_KeyPress);
            // 
            // FinishButton
            // 
            this.FinishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishButton.Location = new System.Drawing.Point(383, 322);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(150, 28);
            this.FinishButton.TabIndex = 60;
            this.FinishButton.Text = "Finish";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // ProductStockFromRecipeIngredientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(541, 367);
            this.Controls.Add(this.QuantityToCreateLabel);
            this.Controls.Add(this.CreateProductStockButton);
            this.Controls.Add(this.QuantityToCreateTextBox);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.IngredientStockGroupBox);
            this.Controls.Add(this.ProductStockDetailsGroupBox);
            this.Controls.Add(this.ProductListBox);
            this.Controls.Add(this.RecipeIngredientsLabel);
            this.Controls.Add(this.ProductListLabel);
            this.Controls.Add(this.IngredientsListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightSalmon;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductStockFromRecipeIngredientsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Product Stock From Recipe Ingredients";
            this.ProductStockDetailsGroupBox.ResumeLayout(false);
            this.ProductStockDetailsGroupBox.PerformLayout();
            this.IngredientStockGroupBox.ResumeLayout(false);
            this.IngredientStockGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductListLabel;
        private System.Windows.Forms.Button CreateProductStockButton;
        private System.Windows.Forms.ListBox IngredientsListBox;
        private System.Windows.Forms.Label RecipeIngredientsLabel;
        private System.Windows.Forms.ListBox ProductListBox;
        private System.Windows.Forms.GroupBox ProductStockDetailsGroupBox;
        private System.Windows.Forms.Label ProductTotalStockQuantityLabel;
        private System.Windows.Forms.Label ProductBookedQuantityLabel;
        private System.Windows.Forms.Label ProductAvailableQuantityLabel;
        private System.Windows.Forms.Label ProductAvailableStockLabel;
        private System.Windows.Forms.Label ProductBookedStockLabel;
        private System.Windows.Forms.Label ProductTotalStockLabel;
        private System.Windows.Forms.GroupBox IngredientStockGroupBox;
        private System.Windows.Forms.Label IngredientTotalStockQuantityLabel;
        private System.Windows.Forms.Label IngredientBookedQuantityLabel;
        private System.Windows.Forms.Label IngredientAvailableQuantityLabel;
        private System.Windows.Forms.Label IngredientAvailableStockLabel;
        private System.Windows.Forms.Label IngredientBookedStockLabel;
        private System.Windows.Forms.Label IngredientTotalStockLabel;
        private System.Windows.Forms.Label QuantityToCreateLabel;
        private System.Windows.Forms.TextBox QuantityToCreateTextBox;
        private System.Windows.Forms.Button FinishButton;
    }
}