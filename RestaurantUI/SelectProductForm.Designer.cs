namespace RestaurantUI
{
    partial class SelectProductForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ProductListLabel
            // 
            this.ProductListLabel.AutoSize = true;
            this.ProductListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductListLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.ProductListLabel.Location = new System.Drawing.Point(27, 9);
            this.ProductListLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProductListLabel.Name = "ProductListLabel";
            this.ProductListLabel.Size = new System.Drawing.Size(109, 16);
            this.ProductListLabel.TabIndex = 53;
            this.ProductListLabel.Text = "Select Product";
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.CancelButton.Location = new System.Drawing.Point(125, 329);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(103, 34);
            this.CancelButton.TabIndex = 52;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.SelectButton.Location = new System.Drawing.Point(13, 329);
            this.SelectButton.Margin = new System.Windows.Forms.Padding(4);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(104, 34);
            this.SelectButton.TabIndex = 51;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductsListBox.ForeColor = System.Drawing.Color.DarkOrange;
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 16;
            this.ProductsListBox.Location = new System.Drawing.Point(12, 29);
            this.ProductsListBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(217, 292);
            this.ProductsListBox.TabIndex = 50;
            // 
            // SelectProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(242, 376);
            this.Controls.Add(this.ProductListLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.ProductsListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkOrange;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectProductForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SelectProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductListLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.ListBox ProductsListBox;
    }
}