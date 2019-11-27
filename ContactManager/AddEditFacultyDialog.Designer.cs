namespace ContactManager
{
    partial class AddEditFacultyDialog
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
            this.facultyAddButton = new System.Windows.Forms.Button();
            this.facultyFirstNameLabel = new System.Windows.Forms.Label();
            this.facultyFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.facultyLastNameLabel = new System.Windows.Forms.Label();
            this.facultyLastNameTextBox = new System.Windows.Forms.TextBox();
            this.facultyAcademicDeptLabel = new System.Windows.Forms.Label();
            this.facultyAcademicDeptTextBox = new System.Windows.Forms.TextBox();
            this.facultyEmailLabel = new System.Windows.Forms.Label();
            this.facultyEmailTextBox = new System.Windows.Forms.TextBox();
            this.facultyBuildingLabel = new System.Windows.Forms.Label();
            this.facultyBuildingTextBox = new System.Windows.Forms.TextBox();
            this.facultyCancelButton = new System.Windows.Forms.Button();
            this.facultyGroupBox = new System.Windows.Forms.GroupBox();
            this.facultyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // facultyAddButton
            // 
            this.facultyAddButton.Location = new System.Drawing.Point(106, 236);
            this.facultyAddButton.Name = "facultyAddButton";
            this.facultyAddButton.Size = new System.Drawing.Size(75, 23);
            this.facultyAddButton.TabIndex = 0;
            this.facultyAddButton.Text = "Add";
            this.facultyAddButton.UseVisualStyleBackColor = true;
            this.facultyAddButton.Click += new System.EventHandler(this.facultyAddButton_Click);
            // 
            // facultyFirstNameLabel
            // 
            this.facultyFirstNameLabel.AutoSize = true;
            this.facultyFirstNameLabel.Location = new System.Drawing.Point(81, 38);
            this.facultyFirstNameLabel.Name = "facultyFirstNameLabel";
            this.facultyFirstNameLabel.Size = new System.Drawing.Size(57, 13);
            this.facultyFirstNameLabel.TabIndex = 1;
            this.facultyFirstNameLabel.Text = "First Name";
            // 
            // facultyFirstNameTextBox
            // 
            this.facultyFirstNameTextBox.Location = new System.Drawing.Point(240, 35);
            this.facultyFirstNameTextBox.Name = "facultyFirstNameTextBox";
            this.facultyFirstNameTextBox.ReadOnly = true;
            this.facultyFirstNameTextBox.Size = new System.Drawing.Size(92, 20);
            this.facultyFirstNameTextBox.TabIndex = 2;
            this.facultyFirstNameTextBox.TextChanged += new System.EventHandler(this.facultyFirstNameTextBox_TextChanged);
            // 
            // facultyLastNameLabel
            // 
            this.facultyLastNameLabel.AutoSize = true;
            this.facultyLastNameLabel.Location = new System.Drawing.Point(80, 64);
            this.facultyLastNameLabel.Name = "facultyLastNameLabel";
            this.facultyLastNameLabel.Size = new System.Drawing.Size(58, 13);
            this.facultyLastNameLabel.TabIndex = 1;
            this.facultyLastNameLabel.Text = "Last Name";
            // 
            // facultyLastNameTextBox
            // 
            this.facultyLastNameTextBox.Location = new System.Drawing.Point(240, 61);
            this.facultyLastNameTextBox.Name = "facultyLastNameTextBox";
            this.facultyLastNameTextBox.ReadOnly = true;
            this.facultyLastNameTextBox.Size = new System.Drawing.Size(92, 20);
            this.facultyLastNameTextBox.TabIndex = 2;
            this.facultyLastNameTextBox.TextChanged += new System.EventHandler(this.facultyLastNameTextBox_TextChanged);
            // 
            // facultyAcademicDeptLabel
            // 
            this.facultyAcademicDeptLabel.AutoSize = true;
            this.facultyAcademicDeptLabel.Location = new System.Drawing.Point(28, 90);
            this.facultyAcademicDeptLabel.Name = "facultyAcademicDeptLabel";
            this.facultyAcademicDeptLabel.Size = new System.Drawing.Size(112, 13);
            this.facultyAcademicDeptLabel.TabIndex = 1;
            this.facultyAcademicDeptLabel.Text = "Academic Department";
            // 
            // facultyAcademicDeptTextBox
            // 
            this.facultyAcademicDeptTextBox.Location = new System.Drawing.Point(240, 87);
            this.facultyAcademicDeptTextBox.Name = "facultyAcademicDeptTextBox";
            this.facultyAcademicDeptTextBox.ReadOnly = true;
            this.facultyAcademicDeptTextBox.Size = new System.Drawing.Size(92, 20);
            this.facultyAcademicDeptTextBox.TabIndex = 2;
            this.facultyAcademicDeptTextBox.TextChanged += new System.EventHandler(this.facultyAcademicDeptTextBox_TextChanged);
            // 
            // facultyEmailLabel
            // 
            this.facultyEmailLabel.AutoSize = true;
            this.facultyEmailLabel.Location = new System.Drawing.Point(34, 41);
            this.facultyEmailLabel.Name = "facultyEmailLabel";
            this.facultyEmailLabel.Size = new System.Drawing.Size(73, 13);
            this.facultyEmailLabel.TabIndex = 1;
            this.facultyEmailLabel.Text = "Email Address";
            // 
            // facultyEmailTextBox
            // 
            this.facultyEmailTextBox.Location = new System.Drawing.Point(145, 34);
            this.facultyEmailTextBox.Name = "facultyEmailTextBox";
            this.facultyEmailTextBox.ReadOnly = true;
            this.facultyEmailTextBox.Size = new System.Drawing.Size(156, 20);
            this.facultyEmailTextBox.TabIndex = 2;
            this.facultyEmailTextBox.TextChanged += new System.EventHandler(this.facultyEmailTextBox_TextChanged);
            // 
            // facultyBuildingLabel
            // 
            this.facultyBuildingLabel.AutoSize = true;
            this.facultyBuildingLabel.Location = new System.Drawing.Point(6, 70);
            this.facultyBuildingLabel.Name = "facultyBuildingLabel";
            this.facultyBuildingLabel.Size = new System.Drawing.Size(119, 13);
            this.facultyBuildingLabel.TabIndex = 1;
            this.facultyBuildingLabel.Text = "Office Location Building";
            // 
            // facultyBuildingTextBox
            // 
            this.facultyBuildingTextBox.Location = new System.Drawing.Point(145, 63);
            this.facultyBuildingTextBox.Name = "facultyBuildingTextBox";
            this.facultyBuildingTextBox.ReadOnly = true;
            this.facultyBuildingTextBox.Size = new System.Drawing.Size(156, 20);
            this.facultyBuildingTextBox.TabIndex = 2;
            this.facultyBuildingTextBox.TextChanged += new System.EventHandler(this.facultyBuildingTextBox_TextChanged);
            // 
            // facultyCancelButton
            // 
            this.facultyCancelButton.Location = new System.Drawing.Point(226, 236);
            this.facultyCancelButton.Name = "facultyCancelButton";
            this.facultyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.facultyCancelButton.TabIndex = 4;
            this.facultyCancelButton.Text = "Cancel";
            this.facultyCancelButton.UseVisualStyleBackColor = true;
            this.facultyCancelButton.Click += new System.EventHandler(this.facultyCancelButton_Click);
            // 
            // facultyGroupBox
            // 
            this.facultyGroupBox.Controls.Add(this.facultyEmailTextBox);
            this.facultyGroupBox.Controls.Add(this.facultyEmailLabel);
            this.facultyGroupBox.Controls.Add(this.facultyBuildingLabel);
            this.facultyGroupBox.Controls.Add(this.facultyBuildingTextBox);
            this.facultyGroupBox.Location = new System.Drawing.Point(34, 115);
            this.facultyGroupBox.Name = "facultyGroupBox";
            this.facultyGroupBox.Size = new System.Drawing.Size(318, 100);
            this.facultyGroupBox.TabIndex = 5;
            this.facultyGroupBox.TabStop = false;
            this.facultyGroupBox.Text = "Contact Information";
            // 
            // AddEditFacultyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 299);
            this.Controls.Add(this.facultyGroupBox);
            this.Controls.Add(this.facultyCancelButton);
            this.Controls.Add(this.facultyAcademicDeptTextBox);
            this.Controls.Add(this.facultyAcademicDeptLabel);
            this.Controls.Add(this.facultyLastNameTextBox);
            this.Controls.Add(this.facultyLastNameLabel);
            this.Controls.Add(this.facultyFirstNameTextBox);
            this.Controls.Add(this.facultyFirstNameLabel);
            this.Controls.Add(this.facultyAddButton);
            this.Name = "AddEditFacultyDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit/Display Faculty Staff Contact Information";
            this.Load += new System.EventHandler(this.AddEditFacultyDialog_Load);
            this.facultyGroupBox.ResumeLayout(false);
            this.facultyGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button facultyAddButton;
        private System.Windows.Forms.Label facultyFirstNameLabel;
        private System.Windows.Forms.TextBox facultyFirstNameTextBox;
        private System.Windows.Forms.Label facultyLastNameLabel;
        private System.Windows.Forms.TextBox facultyLastNameTextBox;
        private System.Windows.Forms.Label facultyAcademicDeptLabel;
        private System.Windows.Forms.TextBox facultyAcademicDeptTextBox;
        private System.Windows.Forms.Label facultyEmailLabel;
        private System.Windows.Forms.TextBox facultyEmailTextBox;
        private System.Windows.Forms.Label facultyBuildingLabel;
        private System.Windows.Forms.TextBox facultyBuildingTextBox;
        private System.Windows.Forms.Button facultyCancelButton;
        private System.Windows.Forms.GroupBox facultyGroupBox;
    }
}