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
    public partial class AddEditStudentDialog : Form
    {

        public int StudentEditMode = 0;             // 0 - display, 1 - add, 2 - edit
        public string StudentFirstName;             // student first name
        public string StudentLastName;              // student last name
        public string StudentAcademicDept;          // student department
        public string StudentEmail;                 // student email address
        public string StudentMail;                  // student mailing address
        public string StudentGradYear;              // student graduation year
        public string StudentCourses;               // student selected courses

        private bool haveValidStudentFirstName = false;
        private bool haveValidStudentLastName = false;
        private bool haveValidStudentAcademicDept = false;
        private bool haveValidStudentEmail = false;
        private bool haveValidStudentMail = false;
        private bool haveValidStudentGradYear = false;
        private bool haveValidStudentCourses = false;


        public AddEditStudentDialog()
        {
            InitializeComponent();
        }

        // Event - Add contact information
        private void studentAddButton_Click(object sender, EventArgs e)
        {

             // validation before Adding

            if(!(haveValidStudentFirstName &&
                haveValidStudentLastName &&
                haveValidStudentAcademicDept &&
                haveValidStudentEmail &&
                haveValidStudentMail &&
                haveValidStudentGradYear &&
                haveValidStudentCourses))
            {
                MessageBox.Show("please fill in all blank fields or check invalid email address");
                return;
            }

            // check the mode, 1 - add, 2 - edit
            switch (StudentEditMode)
            {
                case 0: // display mode
                    break;
                case 1: // add mode
                    if (DialogResult.Yes != MessageBox.Show($"Are you sure to add {studentFirstNameTextBox.Text} {studentLastNameTextBox.Text} ? ",
                                                    "Confirmation",
                                                    MessageBoxButtons.YesNo))
                    {
                        return;
                    }

                    break;
                case 2: // edit mode
                    if (DialogResult.Yes != MessageBox.Show($"Are you sure to update {studentFirstNameTextBox.Text} {studentLastNameTextBox.Text} ? ",
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

        // Event - cancel button click
        private void studentCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // Event - dialog load
        private void AddEditStudentDialog_Load(object sender, EventArgs e)
        {
            // display faculty staff contact information on loading the dialog
            // according to FacultyEditMode
            // 0-dispaly, 1-edit, 2-add

            switch (StudentEditMode)
            {
                case 0: // dispaly mode

                    // show the information of seleted staff
                    studentFirstNameTextBox.Text = StudentFirstName;
                    studentLastNameTextBox.Text = StudentLastName;
                    studentAcademicDeptTextBox.Text = StudentAcademicDept;
                    studentEmailTextBox.Text = StudentEmail;
                    studentSnailMailTextBox.Text = StudentMail;
                    studentGraduationYearTextBox.Text = StudentGradYear;
                    studentCourseListTextBox.Text = StudentCourses;

                    // change title and text
                    studentAddButton.Text = "OK";
                    studentCancelButton.Visible = false;
                    this.Text = "Student Contact Information";

                    break;
                case 1: // add mode

                    // clear the information text box
                    studentFirstNameTextBox.Text = "";
                    studentLastNameTextBox.Text = "";
                    studentAcademicDeptTextBox.Text = "";
                    studentEmailTextBox.Text = "";
                    studentSnailMailTextBox.Text = "";
                    studentGraduationYearTextBox.Text = "";
                    studentCourseListTextBox.Text = "";

                    // enable edit for text box
                    studentFirstNameTextBox.ReadOnly = false;
                    studentLastNameTextBox.ReadOnly = false;
                    studentAcademicDeptTextBox.ReadOnly = false;
                    studentEmailTextBox.ReadOnly = false;
                    studentSnailMailTextBox.ReadOnly = false;
                    studentGraduationYearTextBox.ReadOnly = false;
                    studentCourseListTextBox.ReadOnly = false;
                    courseComboBox.Enabled = true;

                    // change title and text
                    studentAddButton.Text = "Add";
                    studentCancelButton.Visible = true;
                    this.Text = "Add Student Contact Information";

                    break;
                case 2: // edit mode

                    // show the information of seleted staff
                    studentFirstNameTextBox.Text = StudentFirstName;
                    studentLastNameTextBox.Text = StudentLastName;
                    studentAcademicDeptTextBox.Text = StudentAcademicDept;
                    studentEmailTextBox.Text = StudentEmail;
                    studentSnailMailTextBox.Text = StudentMail;
                    studentGraduationYearTextBox.Text = StudentGradYear;
                    studentCourseListTextBox.Text = StudentCourses;

                    // enable edit for text box
                    studentFirstNameTextBox.ReadOnly = false;
                    studentLastNameTextBox.ReadOnly = false;
                    studentAcademicDeptTextBox.ReadOnly = false;
                    studentEmailTextBox.ReadOnly = false;
                    studentSnailMailTextBox.ReadOnly = false;
                    studentGraduationYearTextBox.ReadOnly = false;
                    studentCourseListTextBox.ReadOnly = false;
                    courseComboBox.Enabled = true;

                    // change title and text
                    studentAddButton.Text = "Update";
                    studentCancelButton.Visible = true;
                    this.Text = "Edit Student Contact Information";

                    break;
                default:
                    break;

            }
        }

        // Function - validation of first name
        private void studentFirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (studentFirstNameTextBox.Text.Trim().Length == 0)
            {
                haveValidStudentFirstName = false;
            }
            else
            {
                haveValidStudentFirstName = true;
                StudentFirstName = studentFirstNameTextBox.Text.Trim();
            }
        }

        // Function - validation of last name
        private void studentLastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (studentLastNameTextBox.Text.Trim().Length == 0)
            {
                haveValidStudentLastName = false;
            }
            else
            {
                haveValidStudentLastName = true;
                StudentLastName = studentLastNameTextBox.Text.Trim();
            }
        }

        // Function - validation of department
        private void studentAcademicDeptTextBox_TextChanged(object sender, EventArgs e)
        {
            if (studentAcademicDeptTextBox.Text.Trim().Length == 0)
            {
                haveValidStudentAcademicDept = false;
            }
            else
            {
                haveValidStudentAcademicDept = true;
                StudentAcademicDept = studentAcademicDeptTextBox.Text.Trim();
            }
        }

        // Function - validation of email
        private void studentEmailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (studentEmailTextBox.Text.Trim().Length == 0)
            {
                haveValidStudentEmail = false;
            }
            else
            {
                StudentEmail = studentEmailTextBox.Text.Trim();
                if (StudentEmail.Contains("@"))
                {
                    haveValidStudentEmail = true;
                }
                else
                {
                    haveValidStudentEmail = false;
                }
            }
        }

        // Function - validation of snail mail
        private void studentSnailMailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (studentSnailMailTextBox.Text.Trim().Length == 0)
            {
                haveValidStudentMail = false;
            }
            else
            {
                haveValidStudentMail = true;
                StudentMail = studentSnailMailTextBox.Text.Trim();
            }
        }

        // Function - validation of graduation year
        private void studentGraduationYearTextBox_TextChanged(object sender, EventArgs e)
        {
            if (studentGraduationYearTextBox.Text.Trim().Length == 0)
            {
                haveValidStudentGradYear = false;
            }
            else
            {
                haveValidStudentGradYear = true;
                StudentGradYear = studentGraduationYearTextBox.Text.Trim();
            }
        }

        // Function - validation of course
        private void studentCourseListTextBox_TextChanged(object sender, EventArgs e)
        {
            if (studentCourseListTextBox.Text.Trim().Length == 0)
            {
                haveValidStudentCourses = false;
            }
            else
            {
                haveValidStudentCourses = true;
                StudentCourses = studentCourseListTextBox.Text.Trim();
            }
        }

        // Function - course selection
        private void courseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newCourse;

            switch (courseComboBox.SelectedIndex)
            {
                case 0:
                    newCourse = "CPRG100";
                    break;
                case 1:
                    newCourse = "CPRG201";
                    break;
                case 2:
                    newCourse = "CPRG214";
                    break;
                case 3:
                    newCourse = "MGMT403";
                    break;
                case 4:
                    newCourse = "MSFT113";
                    break;
                case 5:
                    newCourse = "PROG216";
                    break;
                case 6:
                    newCourse = "PROG207";
                    break;
                case 7:
                    newCourse = "SELL115";
                    break;
                default:
                    newCourse = "Invalid";
                    MessageBox.Show("Invalid course");
                    break;
            }
            // add new course to course string
            addNewCourse(newCourse);
        }

        // Function - add new course to string
        private void addNewCourse(string course)
        {
            string currentCourse;
            currentCourse = studentCourseListTextBox.Text;
            studentCourseListTextBox.Clear();
            studentCourseListTextBox.Text = currentCourse + course + "," ;
        }
    }
}
