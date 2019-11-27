using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class AddEditFacultyDialog : Form
    {
        public int FacultyEditMode = 0;             // 0 - display, 1 - add, 2 - edit
        public string FacultyFirstName;             // faculty staff first name
        public string FacultyLastName;              // faculty staff last name
        public string FacultyAcademicDept;          // faculty staff departmant
        public string FacultyEmail;                 // faculty staff email address
        public string FacultyBuilding;              // faculty staff building

        private bool haveValidFacultyFirstName = false;
        private bool haveValidFacultyLastName = false;
        private bool haveValidFacultyAcademicDept = false;
        private bool haveValidFacultyEmail = false;
        private bool haveValidFacultyBuilding = false;

        public AddEditFacultyDialog()
        {
            InitializeComponent();
        }

        // Event - dialog load
        private void AddEditFacultyDialog_Load(object sender, EventArgs e)
        {
            // display faculty staff contact information on loading the dialog
            // according to FacultyEditMode
            // 0-dispaly, 1-edit, 2-add

            switch(FacultyEditMode)
            {
                case 0: // dispaly mode

                    // show the information of seleted staff
                    facultyFirstNameTextBox.Text = FacultyFirstName;
                    facultyLastNameTextBox.Text = FacultyLastName;
                    facultyAcademicDeptTextBox.Text = FacultyAcademicDept;
                    facultyEmailTextBox.Text = FacultyEmail;
                    facultyBuildingTextBox.Text = FacultyBuilding;

                    // change title and text
                    facultyAddButton.Text = "OK";
                    facultyCancelButton.Visible = false;
                    this.Text = "Faculty Staff Contact Information";

                    break;
                case 1: // add mode

                    // clear the information text box
                    facultyFirstNameTextBox.Text = "";
                    facultyLastNameTextBox.Text = "";
                    facultyAcademicDeptTextBox.Text = "";
                    facultyEmailTextBox.Text = "";
                    facultyBuildingTextBox.Text = "";

                    // enable edit for text box
                    facultyFirstNameTextBox.ReadOnly = false;
                    facultyLastNameTextBox.ReadOnly = false; ;
                    facultyAcademicDeptTextBox.ReadOnly = false; ;
                    facultyEmailTextBox.ReadOnly = false; ;
                    facultyBuildingTextBox.ReadOnly = false;

                    // change title and text
                    facultyAddButton.Text = "Add";
                    facultyCancelButton.Visible = true;
                    this.Text = "Add Faculty Staff Contact Information";

                    break;
                case 2: // edit mode

                    // show the information of seleted staff
                    facultyFirstNameTextBox.Text = FacultyFirstName;
                    facultyLastNameTextBox.Text = FacultyLastName;
                    facultyAcademicDeptTextBox.Text = FacultyAcademicDept;
                    facultyEmailTextBox.Text = FacultyEmail;
                    facultyBuildingTextBox.Text = FacultyBuilding;

                    // enable edit for text box
                    facultyFirstNameTextBox.ReadOnly = false;
                    facultyLastNameTextBox.ReadOnly = false; ;
                    facultyAcademicDeptTextBox.ReadOnly = false;
                    facultyEmailTextBox.ReadOnly = false; ;
                    facultyBuildingTextBox.ReadOnly = false;

                    // change title and text
                    facultyAddButton.Text = "Update";
                    facultyCancelButton.Visible = true;
                    this.Text = "Edit Faculty Staff Contact Information";

                    break;
                default:
                    break;

            }            

        }

        // Event - Add contact information
        private void facultyAddButton_Click(object sender, EventArgs e)
        {

            // validation before Adding

            if (!(haveValidFacultyFirstName &&
                haveValidFacultyLastName &&
                haveValidFacultyAcademicDept &&
                haveValidFacultyEmail &&
                haveValidFacultyBuilding))
            {
                MessageBox.Show("please fill in all blank fields or check invalid email address");
                return;
            }

                
            // check the mode, 1 - add, 2 - edit
            switch (FacultyEditMode)
            {
                case 0: // display mode
                    break;
                case 1: // add mode
                    if (DialogResult.Yes != MessageBox.Show($"Are you sure to add {facultyFirstNameTextBox.Text} {facultyLastNameTextBox.Text} ? ",
                                                    "Confirmation",
                                                    MessageBoxButtons.YesNo))
                    {
                        return;
                    }

                    break;
                case 2: // edit mode
                    if (DialogResult.Yes != MessageBox.Show($"Are you sure to update {facultyFirstNameTextBox.Text} {facultyLastNameTextBox.Text} ? ",
                                                    "Confirmation",
                                                    MessageBoxButtons.YesNo))
                    {
                        return;
                    }

                    break;
                default:
                    MessageBox.Show("unknown mode");
                    break;

            }

            // add mode, increase index, and add new values
            // edit mode, override the values of selected item 
            

            DialogResult = DialogResult.OK;
        }

        // Event - cancle
        private void facultyCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // Event - validation of first name
        private void facultyFirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if(facultyFirstNameTextBox.Text.Trim().Length == 0)
            {
                haveValidFacultyFirstName = false;
            }
            else
            {
                haveValidFacultyFirstName = true;
                FacultyFirstName = facultyFirstNameTextBox.Text.Trim();
            }
        }

        // Event - validation of last name
        private void facultyLastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (facultyLastNameTextBox.Text.Trim().Length == 0)
            {
                haveValidFacultyLastName = false;
            }
            else
            {
                haveValidFacultyLastName = true;
                FacultyLastName = facultyLastNameTextBox.Text.Trim();
            }
        }

        // Event - validation of department
        private void facultyAcademicDeptTextBox_TextChanged(object sender, EventArgs e)
        {
            if (facultyAcademicDeptTextBox.Text.Trim().Length == 0)
            {
                haveValidFacultyAcademicDept = false;
            }
            else
            {
                haveValidFacultyAcademicDept = true;
                FacultyAcademicDept = facultyAcademicDeptTextBox.Text.Trim();
            }
        }

        // Event - validation of email
        private void facultyEmailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (facultyEmailTextBox.Text.Trim().Length == 0)
            {
                haveValidFacultyEmail = false;
            }
            else
            {
                FacultyEmail = facultyEmailTextBox.Text.Trim();
                if (FacultyEmail.Contains("@"))
                {
                    haveValidFacultyEmail = true;
                }
                else
                {
                    haveValidFacultyEmail = false;
                }
            }
        }

        // Event - validation of building
        private void facultyBuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            if (facultyBuildingTextBox.Text.Trim().Length == 0)
            {
                haveValidFacultyBuilding = false;
            }
            else
            {
                haveValidFacultyBuilding = true;
                FacultyBuilding = facultyBuildingTextBox.Text.Trim();
            }
        }
    }
}
