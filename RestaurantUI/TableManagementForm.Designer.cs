namespace RestaurantUI
{
    partial class TableManagementForm
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
            this.ClearTableTextBoxButton = new System.Windows.Forms.Button();
            this.UpdateTableButton = new System.Windows.Forms.Button();
            this.TableNameLabel = new System.Windows.Forms.Label();
            this.TableNameTextBox = new System.Windows.Forms.TextBox();
            this.TablesListBox = new System.Windows.Forms.ListBox();
            this.CreateTableButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClearTableTextBoxButton
            // 
            this.ClearTableTextBoxButton.Location = new System.Drawing.Point(14, 142);
            this.ClearTableTextBoxButton.Name = "ClearTableTextBoxButton";
            this.ClearTableTextBoxButton.Size = new System.Drawing.Size(160, 28);
            this.ClearTableTextBoxButton.TabIndex = 35;
            this.ClearTableTextBoxButton.Text = "Clear";
            this.ClearTableTextBoxButton.UseVisualStyleBackColor = true;
            this.ClearTableTextBoxButton.Click += new System.EventHandler(this.ClearTableTextBoxButton_Click);
            // 
            // UpdateTableButton
            // 
            this.UpdateTableButton.Location = new System.Drawing.Point(14, 108);
            this.UpdateTableButton.Name = "UpdateTableButton";
            this.UpdateTableButton.Size = new System.Drawing.Size(160, 28);
            this.UpdateTableButton.TabIndex = 29;
            this.UpdateTableButton.Text = "Update";
            this.UpdateTableButton.UseVisualStyleBackColor = true;
            this.UpdateTableButton.Click += new System.EventHandler(this.UpdateTableButton_Click);
            // 
            // TableNameLabel
            // 
            this.TableNameLabel.AutoSize = true;
            this.TableNameLabel.Location = new System.Drawing.Point(12, 23);
            this.TableNameLabel.Name = "TableNameLabel";
            this.TableNameLabel.Size = new System.Drawing.Size(153, 18);
            this.TableNameLabel.TabIndex = 28;
            this.TableNameLabel.Text = "Table Name / Number";
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.Location = new System.Drawing.Point(15, 44);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(160, 24);
            this.TableNameTextBox.TabIndex = 27;
            // 
            // TablesListBox
            // 
            this.TablesListBox.FormattingEnabled = true;
            this.TablesListBox.ItemHeight = 18;
            this.TablesListBox.Location = new System.Drawing.Point(200, 43);
            this.TablesListBox.Name = "TablesListBox";
            this.TablesListBox.Size = new System.Drawing.Size(181, 130);
            this.TablesListBox.TabIndex = 26;
            this.TablesListBox.SelectedIndexChanged += new System.EventHandler(this.TablesListBox_SelectedIndexChanged);
            // 
            // CreateTableButton
            // 
            this.CreateTableButton.Location = new System.Drawing.Point(14, 74);
            this.CreateTableButton.Name = "CreateTableButton";
            this.CreateTableButton.Size = new System.Drawing.Size(160, 28);
            this.CreateTableButton.TabIndex = 25;
            this.CreateTableButton.Text = "Create";
            this.CreateTableButton.UseVisualStyleBackColor = true;
            this.CreateTableButton.Click += new System.EventHandler(this.CreateTableButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(367, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(26, 26);
            this.ExitButton.TabIndex = 85;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // TableManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(393, 190);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ClearTableTextBoxButton);
            this.Controls.Add(this.UpdateTableButton);
            this.Controls.Add(this.TableNameLabel);
            this.Controls.Add(this.TableNameTextBox);
            this.Controls.Add(this.TablesListBox);
            this.Controls.Add(this.CreateTableButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Orange;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TableManagementForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Table Management Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearTableTextBoxButton;
        private System.Windows.Forms.Button UpdateTableButton;
        private System.Windows.Forms.Label TableNameLabel;
        private System.Windows.Forms.TextBox TableNameTextBox;
        private System.Windows.Forms.ListBox TablesListBox;
        private System.Windows.Forms.Button CreateTableButton;
        private System.Windows.Forms.Button ExitButton;
    }
}