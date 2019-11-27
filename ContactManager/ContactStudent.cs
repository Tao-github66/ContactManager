using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactStudent : Contact
    {

        // public properties
        public string SnailMail
        {
            get { return snailMail; }
            set { snailMail = value; }
        }
        // private properties

        private string snailMail;              // mail address for student

        // constructors

        public ContactStudent(string email, string snailMail):base(email)
        {
            if (!validateSnailMail(snailMail))
                throw new ArgumentException("bad snail mail address");

            this.snailMail = snailMail;

        }

        // Functinon - validation of snailMail
        private bool validateSnailMail(string name)
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
