using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactManager
{
    public class Person
    {
        // public properties

        public string FirstName        // first name in contact inforamtion
        {
            get { return firstName; }
            set { }
        }
        public string LastName         // last name in contact inforamtion
        {
            get { return lastName; }
            set { }
        }
        public string Department           // academic department associated with
        {
            get { return department; }
            set { }
        }


        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        // private properties

        private string firstName;           // first name in contact inforamtion
        private string lastName;            // last name in contact inforamtion
        private string department;          // academic department associated with
        private string type;                // person type (faculty or student)

        // constructors

        public Person(string firstName, string lastName, string department)
        {
            if (!validateFirstName(firstName))
                throw new ArgumentException("bad first name");

            if (!validateFirstName(lastName))
                throw new ArgumentException("bad last name");

            if (!validateDepartment(department))
            {
                throw new ArgumentException("bad department name");
            }

            this.firstName = firstName;
            this.lastName = lastName;
            this.department = department;
        }

        // load file
        public Person(string fromFile)
        {
            char[] delimiters = { '|', ',' };
            string[] tokens = fromFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            firstName = tokens[0];
            lastName = tokens[1];
            department = tokens[2];
        }

        // screen display
        public virtual string ToFormattedString()
        {
            string theString = "           ";

            theString += $"{firstName,-15}";
            theString += $"{lastName,-15}";
            theString += $"{type,20}";
            theString += $"{department,25}";
            
            return theString;
        }

        // save file
        public virtual string toFileString()
        {
            string theString = "";
            theString += $"{firstName}|";
            theString += $"{lastName}|";
            theString += $"{department}|";

            return theString;
        }

        // Function - validation of department
        private bool validateDepartment(string name)
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

        // Function - validation of lastName
        private bool validateLastName(string name)
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

        // Function - validation of FirstName
        private bool validateFirstName(string name)
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
    }
}
