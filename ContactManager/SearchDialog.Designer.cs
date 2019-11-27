namespace ContactManager
{
    partial class SearchDialog
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
            this.searchFirstNameLabel1 = new System.Windows.Forms.Label();
            this.searchFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.searchLastNameLabel = new System.Windows.Forms.Label();
            this.searchLastNameTextBox = new System.Windows.Forms.TextBox();
            this.searchSearchButton = new System.Windows.Forms.Button();
            this.searchCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchFirstNameLabel1
            // 
            this.searchFirstNameLabel1.AutoSize = true;
            this.searchFirstNameLabel1.Location = new System.Drawing.Point(31, 32);
            this.searchFirstNameLabel1.Name = "searchFirstNameLabel1";
            this.searchFirstNameLabel1.Size = new System.Drawing.Size(57, 13);
            this.searchFirstNameLabel1.TabIndex = 0;
            this.searchFirstNameLabel1.Text = "First Name";
            // 
            // searchFirstNameTextBox
            // 
            this.searchFirstNameTextBox.Location = new System.Drawing.Point(124, 24);
            this.searchFirstNameTextBox.Name = "searchFirstNameTextBox";
            this.searchFirstNameTextBox.Size = new System.Drawing.Size(152, 20);
            this.searchFirstNameTextBox.TabIndex = 1;
            // 
            // searchLastNameLabel
            // 
            this.searchLastNameLabel.AutoSize = true;
            this.searchLastNameLabel.Location = new System.Drawing.Point(31, 58);
            this.searchLastNameLabel.Name = "searchLastNameLabel";
            this.searchLastNameLabel.Size = new System.Drawing.Size(58, 13);
            this.searchLastNameLabel.TabIndex = 0;
            this.searchLastNameLabel.Text = "Last Name";
            // 
            // searchLastNameTextBox
            // 
            this.searchLastNameTextBox.Location = new System.Drawing.Point(124, 50);
            this.searchLastNameTextBox.Name = "searchLastNameTextBox";
            this.searchLastNameTextBox.Size = new System.Drawing.Size(152, 20);
            this.searchLastNameTextBox.TabIndex = 1;
            // 
            // searchSearchButton
            // 
            this.searchSearchButton.Location = new System.Drawing.Point(64, 105);
            this.searchSearchButton.Name = "searchSearchButton";
            this.searchSearchButton.Size = new System.Drawing.Size(75, 23);
            this.searchSearchButton.TabIndex = 2;
            this.searchSearchButton.Text = "Search";
            this.searchSearchButton.UseVisualStyleBackColor = true;
            this.searchSearchButton.Click += new System.EventHandler(this.searchSearchButton_Click);
            // 
            // searchCancelButton
            // 
            this.searchCancelButton.Location = new System.Drawing.Point(167, 105);
            this.searchCancelButton.Name = "searchCancelButton";
            this.searchCancelButton.Size = new System.Drawing.Size(75, 23);
            this.searchCancelButton.TabIndex = 3;
            this.searchCancelButton.Text = "Cancel";
            this.searchCancelButton.UseVisualStyleBackColor = true;
            this.searchCancelButton.Click += new System.EventHandler(this.searchCancelButton_Click);
            // 
            // SearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 161);
            this.Controls.Add(this.searchCancelButton);
            this.Controls.Add(this.searchSearchButton);
            this.Controls.Add(this.searchLastNameTextBox);
            this.Controls.Add(this.searchLastNameLabel);
            this.Controls.Add(this.searchFirstNameTextBox);
            this.Controls.Add(this.searchFirstNameLabel1);
            this.Name = "SearchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Dialog";
            this.Load += new System.EventHandler(this.SearchDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label searchFirstNameLabel1;
        private System.Windows.Forms.TextBox searchFirstNameTextBox;
        private System.Windows.Forms.Label searchLastNameLabel;
        private System.Windows.Forms.TextBox searchLastNameTextBox;
        private System.Windows.Forms.Button searchSearchButton;
        private System.Windows.Forms.Button searchCancelButton;
    }
}