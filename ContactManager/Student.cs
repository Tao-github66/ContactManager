using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Student : Person
    {

        // public properties

        public ContactStudent StudentCont               // mailing address
        {
            get { return studentCont; }
            set { studentCont = value; }
        }
        public string GraduationYear                    // expected graduation year
        {
            get { return graduationYear; }
            set { }
        }

        public List<string> Course                      // list of courses are taking
        {
            get { return course; }
            set { }
        }

        // private properties

        private ContactStudent studentCont;                         // mailing address
        private string graduationYear;                              // expected graduation year
        private List<string> course = new List<string>();           // list of courses are taking

        // constructor

        public Student(string firstName,
                        string lastName,
                        string department,
                        ContactStudent studentCont,
                        string graduationYear,
                        List<string> course):base(firstName, lastName, department)
        {

            if (!validateGraduationYear(graduationYear))
                throw new ArgumentException("bad graduation year");

            if (!validateCourses(course))
                throw new ArgumentException("bad course name");

            this.studentCont = studentCont;
            this.graduationYear = graduationYear;
            this.course = course;
        }

        // load file
        public Student(string fromFile):base(fromFile)
        {
            char[] delimiters = { '|', ',' };

            string[] tokens = fromFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // call constructor to set contact information of faculty staff
            studentCont = new ContactStudent(tokens[3], tokens[4]);

            graduationYear = tokens[5];

            // read course list until end
            int len = tokens.Length;
            for (int i = 6; i < len; i++)
            {
                course.Add(tokens[i]);
            }
        }

        // screen display
        public override string ToFormattedString()
        {
            return base.ToFormattedString();
        }

        // save file
        public override string toFileString()
        {
            string stdCourse = null;

            foreach ( string c in course)
            {
                stdCourse = stdCourse + c + "|";
            }

            return base.toFileString() + $"{studentCont.Email}|{studentCont.SnailMail}|{graduationYear}|{stdCourse}";
        }

        // Function - validation of graduation year
        private bool validateGraduationYear(string name)
        {
            if (!((name != null) && (name.Length > 0)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Function - validation of course
        private bool validateCourses(List<string> name)
        {
            if (!((name != null) && (name.Count > 0)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
