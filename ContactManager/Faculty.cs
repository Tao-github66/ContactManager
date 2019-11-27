using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Faculty : Person
    {
        // public properties

        public ContactFaculty ContactFaculty
        {
            get { return contactFaculty; }

            set { contactFaculty = value; }
        }
        
        // private properties

        private ContactFaculty contactFaculty;

        // constructor

        public Faculty(string firstName,
                        string lastName,
                        string department,
                        ContactFaculty contactFaculty):base(firstName, lastName, department)
        {
            this.contactFaculty = contactFaculty;
        }

        // load file
        public Faculty(string fromFile):base(fromFile)
        {

            char[] delimiters = { '|', ',' };

            string[] tokens = fromFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // call constructor to set contact information of faculty staff
            contactFaculty = new ContactFaculty(tokens[3], tokens[4]);
        }

        // screen display
        public override string ToFormattedString()
        { 
            return base.ToFormattedString();
        }

        // save file
        public override string toFileString()
        {
            return base.toFileString() + $"{contactFaculty.Email}|{contactFaculty.Building}";
        }
    }
}
