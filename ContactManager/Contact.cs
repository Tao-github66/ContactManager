using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Contact
    {

        // public properties
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        // private properties
        private string email;               // email address of person

        // constructors

        public Contact(string email)
        {
            if (!validateContactEmail(email))
                throw new ArgumentException("bad email name");
            this.email = email;
        }

        // Functinon - validation of email
        private bool validateContactEmail(string name)
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
