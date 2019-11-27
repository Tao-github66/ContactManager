/************************************************************************************/
/* Contact Manager System is a free application which manage two types of contacts: */
/* Faculty staffs and Students                                                      */
/*                                                                                  */
/* by Tao Lu                                                                        */
/* Sept.6, 2019                                                                     */
/*                                                                                  */
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class contactManagerMainForm : Form
    {
        string savePath = null;                                 // path for saving file
        List<Person> personList = new List<Person>();           // create a list for person
        int EditCount = 0;                                      // count for edit and add  
        List<int> matchList = new List<int>();                  // store match index in personList

        public SelectionMode MultiSimple { get; private set; }

        public contactManagerMainForm()
        {
            InitializeComponent();
        }


        // Event - open file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("User selected the open menu items");

            // clear listbox 
            personListListBox.Items.Clear();

            // get the file path

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Contact Information";
            ofd.Filter = "Text File|*.txt|All files|*.*";
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // open a stream reader on 'contactinformation.txt' on the desktop
            // for each line in the file call the constructor that takes single string
            // and get a object back. Add that object to my list and to the display list
            // close the file

            savePath = ofd.FileName;            // get file path ready for saving file
            Person p = null;

            try
            {
                StreamReader input = new StreamReader(ofd.FileName);
                while (!input.EndOfStream)
                {
                    string personType = input.ReadLine();
                    switch (personType)
                    {
                        case "FACULTY":
                            p = new Faculty(input.ReadLine());
                            p.Type = "Faculty";
                            break;
                        case "STUDENT":
                            p = new Student(input.ReadLine());
                            p.Type = "Student";
                            break;
                        default:
                            MessageBox.Show("unknown person in the file");
                            p = null;
                            break;
                    }

                    if (p != null)
                    {
                        personList.Add(p);
                        personListListBox.Items.Add(p.ToFormattedString());
                    }

                }
                input.Close();
            }
            catch (Exception excp)
            {
                MessageBox.Show($"File did not load. {excp.Message}");
                return;
            }
        }


        // Event - show contact information for selected person ( faculty and student)
        private void contactDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("User selected the contact detail as context menu items");

            // set show mode

            int mode = 0;  // 0 - display only

            // check to see if we have something checked first, message if not

            int index = personListListBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Must select a contact information first before displaying contact details");
                return;
            }

            // create the edit dialog, have it prepopulate the contents of the field and then
            // show the dialog

            Person p = personList[index];

            if (p is Faculty)
            {
                EditFacultyPerson(index, mode);
            }
            else if (p is Student)
            {
                EditStudentPerson(index, mode);
            }
            else
            {
                MessageBox.Show("unknown person trying to be editted");
            }
        }

        // Event - edit contact information for faculty staff
        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set display mode

            int mode = 2;  // 0 - edit mode

            // check to see if we have something checked first, message if not
            int index = personListListBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Must select a contact information first before displaying contact details");
                return;
            }

            // create the edit dialog, have it prepopulate the contents of the field and then
            // show the dialog

            Person p = personList[index];

            if (p is Faculty)
            {
                EditFacultyPerson(index, mode);
            }
            else if (p is Student)
            {
                EditStudentPerson(index, mode);
            }
            else
            {
                MessageBox.Show("unknown person trying to be editted");
            }
        }

        private void deleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Console.WriteLine("User selected the delete as menu items");

            // check to see if we have something checked first, message if not
            int index = personListListBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Must select a contact information first before displaying contact details");
                return;
            }

            // create the edit dialog, have it prepopulate the contents of the field and then
            // show the dialog

            Person p = personList[index];
            if (DialogResult.Yes != MessageBox.Show($"Are you sure you wish to delete {p.FirstName}?",
                                                    "Confirmation",
                                                    MessageBoxButtons.YesNo))
            {
                return;
            }

            // so really delete the item; take it out of the personList list
            // and the display list

            personListListBox.Items.RemoveAt(index);
            personList.RemoveAt(index);

            EditCount++;                    // EditCount add 1 after sucessful delete

        }

        // Event - Add contact inforamtion for faculty staff
        private void facultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("User selected the add contact of faculty as context menu items");
     
            // set mode
 
            int mode = 1;   //1 - add mode
            int index = -1; // add mode set index -1

            // call function for edit
       
            EditFacultyPerson(index, mode);
        }

 
        // Function - Edit faculty staff contact information
        private void EditFacultyPerson(int index, int mode)
        {
            // create a dialog and configure for edit or only display

            AddEditFacultyDialog adfd = new AddEditFacultyDialog();

            switch (mode)
            {
                case 0:     // 0 - show mode
                case 2:     // 2 - edit mode

                    Faculty f = (Faculty)personList[index];

                    // assign values in personList to public properties in AddEditFacultyDialog
                    adfd.FacultyEditMode = mode;
                    adfd.FacultyFirstName = f.FirstName;
                    adfd.FacultyLastName = f.LastName;
                    adfd.FacultyAcademicDept = f.Department;
                    adfd.FacultyEmail = f.ContactFaculty.Email;
                    adfd.FacultyBuilding = f.ContactFaculty.Building;

                    break;

                case 1:     // 1 - add mode
                    adfd.FacultyEditMode = mode;
                    break;
            }
            

            // show the dialog and wait for a ok

            DialogResult result = adfd.ShowDialog();

            // if answer was ok update the contact information with the new values and update display

            // update faculty contact information

            

            if (result == DialogResult.OK)
            {
                ContactFaculty facultyInfo;
                try
                {
                    facultyInfo = new ContactFaculty(adfd.FacultyEmail, adfd.FacultyBuilding);
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"email address error. {excp.Message}");
                    return;
                }

                Person p = new Faculty(adfd.FacultyFirstName,
                                      adfd.FacultyLastName,
                                      adfd.FacultyAcademicDept,
                                      facultyInfo);

                // set mode to public property
                p.Type = "Faculty";

                switch (mode)
                {
                    case 0: // show mode
                        break;
                    case 2: // edit mode

                        // update new values for dispaly and list
                       
                        personList[index] = p;
                        personListListBox.Items[index] = p.ToFormattedString();
                        EditCount++;                    // EditCount add 1 after sucessful edit
                        break;
                    case 1: //add mode

                        // add to list
                        personList.Add(p);

                        // add to list box for display
                        personListListBox.Items.Add(p.ToFormattedString());
                        EditCount++;                    // EditCount add 1 after sucessful add
                        break;
            
                    default:
                        break;

                }
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                MessageBox.Show("AddEditFacultyDialog not return OK ....debug");
                return;
            }
        }

        // Function - Edit student contact information
        private void EditStudentPerson(int index, int mode)
        {
            // create a dialog and configure for edit or only display

            AddEditStudentDialog adsd = new AddEditStudentDialog();

            switch (mode)
            {
                case 0:     // 0 - show mode
                case 2:     // 2 - edit mode

                    Student s = (Student)personList[index];

                    // assign values in personList to public properties in AddEditFacultyDialog
                    adsd.StudentEditMode = mode;
                    adsd.StudentFirstName = s.FirstName;
                    adsd.StudentLastName = s.LastName;
                    adsd.StudentAcademicDept = s.Department;
                    adsd.StudentEmail = s.StudentCont.Email;
                    adsd.StudentMail = s.StudentCont.SnailMail;
                    adsd.StudentGradYear = s.GraduationYear;
                    // change s.course list to adsd.course string
                    adsd.StudentCourses = stdCourseListToString(s.Course);

                    break;

                case 1:     // 1 - add mode
                    adsd.StudentEditMode = mode;
                    break;
            }


            // show the dialog and wait for a ok

            DialogResult result = adsd.ShowDialog();

            // if answer was ok update the contact information with the new values and update display

            // update student contact information
            


            if (result == DialogResult.OK)
            {
                ContactStudent studentInfo;
                try
                {
                    studentInfo = new ContactStudent(adsd.StudentEmail, adsd.StudentMail);
                }
                    catch (Exception excp)
                {
                    MessageBox.Show($"email address error. {excp.Message}");
                    return;
                }

                Person p = new Student(adsd.StudentFirstName,
                                      adsd.StudentLastName,
                                      adsd.StudentAcademicDept,
                                      studentInfo,
                                      adsd.StudentGradYear,
                                      // change adsd.StudentCourses string to p.Course list
                                      stdCourseStringToList(adsd.StudentCourses)
                                      );

                // set mode to public property
                p.Type = "Student";

                switch (mode)
                {
                    case 0: // show mode
                        break;
                    case 2: // edit mode

                        // update new values for dispaly and list

                        personList[index] = p;
                        personListListBox.Items[index] = p.ToFormattedString();
                        EditCount++;                    // EditCount add 1 after sucessful edit
                        break;
                    case 1: //add mode

                        // add to list
                        personList.Add(p);

                        // add to list box for display
                        personListListBox.Items.Add(p.ToFormattedString());
                        EditCount++;                    // EditCount add 1 after sucessful add
                        break;

                    default:
                        break;

                }

            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                MessageBox.Show("AddEditFacultyDialog not return OK ....debug");
                return;
            }

        }

        // Function - student course list to course string
        private string stdCourseListToString(List<string> courseList)
        {
            string strCourse = null;
            foreach (string c in courseList)
            {
                strCourse = strCourse + c + ",";
            }
            return strCourse;
        }

        // Function - student course string to course list
        private List<string> stdCourseStringToList(string courseString)
        {
            List<string> listCourse = new List<string>();

            char[] delimiters = { '|', ',' };

            string[] tokens = courseString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                listCourse.Add(tokens[i]);
            }
            return listCourse;
        }

        private void firstNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear all selected items and clear searchResultListBox 
            personListListBox.ClearSelected();
            searchResultListBox.Items.Clear();

            // create a dialog
            SearchDialog schd = new SearchDialog();

            // set search mode
            schd.SearchType = 0;

            DialogResult result = schd.ShowDialog();

            // clear list of store index of matched person
            matchList.Clear();

            // index number
            int cnt = 0;

            if (result == DialogResult.OK)
            {
                foreach (Person p in personList)
                {
                    if (string.Equals(p.FirstName.ToLower(), schd.SearchFn.ToLower()))
                    {
                        personListListBox.SetSelected(cnt, true);
                        matchList.Add(cnt);
                        searchResultListBox.Items.Add(p.ToFormattedString());
                    }
                    cnt++;
                }
                searchResultListBox.Items.Add("");
                searchResultListBox.Items.Add($"           Found {matchList.Count} items");
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                MessageBox.Show("AddEditFacultyDialog not return OK ....debug");
                return;
            }
        }

        private void lastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear all selected items and clear searchResultListBox
            personListListBox.ClearSelected();
            searchResultListBox.Items.Clear();

            // create a dialog
            SearchDialog schd = new SearchDialog();

            // set search mode
            schd.SearchType = 1;

            DialogResult result = schd.ShowDialog();

            // clear list of store index of matched person
            matchList.Clear();

            // index number
            int cnt = 0;

            if (result == DialogResult.OK)
            {
                foreach (Person p in personList)
                {
                    if (string.Equals(p.LastName.ToLower(), schd.SearchLn.ToLower()))
                    {
                        personListListBox.SetSelected(cnt, true);
                        matchList.Add(cnt);
                        searchResultListBox.Items.Add(p.ToFormattedString());
                    }
                    cnt++;
                }
                searchResultListBox.Items.Add("");
                searchResultListBox.Items.Add($"           Found {matchList.Count} items");
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                MessageBox.Show("AddEditFacultyDialog not return OK ....debug");
                return;
            }
        }

        private void firstAndLastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear all selected items and clear searchResultListBox
            personListListBox.ClearSelected();
            searchResultListBox.Items.Clear();

            // create a dialog
            SearchDialog schd = new SearchDialog();

            // set search mode
            schd.SearchType = 2;

            DialogResult result = schd.ShowDialog();

            // clear list of store index of matched person
            matchList.Clear();

            // index number
            int cnt = 0;

            if (result == DialogResult.OK)
            {
                foreach (Person p in personList)
                {
                    if ((string.Equals(p.FirstName.ToLower(), schd.SearchFn.ToLower())) && (string.Equals(p.LastName.ToLower(), schd.SearchLn.ToLower())))
                    {
                        personListListBox.SetSelected(cnt, true);
                        matchList.Add(cnt);
                        searchResultListBox.Items.Add(p.ToFormattedString());
                    }
                    cnt++;
                }
                searchResultListBox.Items.Add("");
                searchResultListBox.Items.Add($"           Found {matchList.Count} items");
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                MessageBox.Show("AddEditFacultyDialog not return OK ....debug");
                return;
            }
        }

        // Event - save file
        private void saveContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = savePath;
                StreamWriter output = new StreamWriter(filepath);
                foreach (Person p in personList)
                {
                    output.WriteLine(personTypeString(p));
                    output.WriteLine(p.toFileString());

                }
                output.Close();
                EditCount = 0;                    // EditCount reset to 0 after sucessful save
            }
            catch (Exception excp)
            {
                MessageBox.Show($"File did not write. {excp.Message}");
                return;
            }

            MessageBox.Show($"Contact information have been saved in contactinformation.txt");
        }

        // Function - write person type to file
        private string personTypeString(Person p)
        {
            if (p is Faculty)
                return "FACULTY";
            else if (p is Student)
                return "STUDENT";
            else
                return "UNKNOWN";
        }

        // Event - Save as files
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("User selected the save as menu items");

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Select File to Save Contact Information List";

            sfd.Filter = "Text File| *.txt | All files | *.* ";
            sfd.FilterIndex = 1;

            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            DialogResult result = sfd.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            // all inside a try/catch
            //
            // open a stream writer on 'contactinformation.txt' on the desktop
            // foreach person in my inventory, ,run the ToFileString() method
            // and write that to  file
            // close the file
            try
            {
                StreamWriter output = new StreamWriter(sfd.FileName);
                foreach (Person p in personList)
                {
                    output.WriteLine(personTypeString(p));
                    output.WriteLine(p.toFileString());
                }

                output.Close();
                EditCount = 0;                    // EditCount reset to 0 after sucessful save
            }
            catch (Exception excp)
            {
                MessageBox.Show($"File did not write. {excp.Message}");
                return;
            }

            MessageBox.Show($"Contact Information have been save in {sfd.FileName}");
        }

        // Event - Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("User selected the exit as menu items");

            if (EditCount > 0)
            {
                // make sure the user has saved all the changes
                if (DialogResult.Yes != MessageBox.Show($"Are you sure to Exit? Yes - exit without save",
                                                        "Confirmation",
                                                        MessageBoxButtons.YesNo))
                {
                    return;
                }
            }
            Application.Exit();
        }

        // Event - Edit Student contact Information
        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("User selected the add contact of student as context menu items");

            // set mode

            int mode = 1;   //1 - add mode
            int index = -1; // add mode set index -1

            // call function for edit

            EditStudentPerson(index, mode);
        }

        private void contactManagerMainForm_Load(object sender, EventArgs e)
        {

            // delete at the end

            /*// no smaller than design time size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            //this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, (int)System.Windows.SystemParameters.PrimaryScreenHeight);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;*/

        }

        // Event - Help (About)
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create a dialog and configure for edit or only display

            AboutDialog ad = new AboutDialog();

            // show the dialog and wait for a ok

            DialogResult result = ad.ShowDialog();

            // if answer was ok update the contact information with the new values and update display

            if (result == DialogResult.OK)
            {
                return;
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                MessageBox.Show("AboutDialog not return OK ....debug");
                return;
            }
        }

        // Event - Clear searchResultBox
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchResultListBox.Items.Clear();
        }

        // Event - Double click on the item in searchResultBox to connect to personListBox
        private void searchResultListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = searchResultListBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Must select a search result for furthur manipulation");
                return;
            }

            // clear all selected items
            personListListBox.ClearSelected();

            searchResultListBox.SetSelected(index, true);
            personListListBox.SetSelected(matchList[index], true);
        }
    }
}
