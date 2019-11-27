using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactFaculty : Contact
    {
        // public properties

        public string Building
        {
            get { return building; }
            set { building = value; }
        }
        // private properties

        private string building;            // buliding name for faculty stuff

        // constructors

        public ContactFaculty(string email, string building):base(email)
        {
            if (!validateBuilding(building))
                throw new ArgumentException("bad graduation year");

            this.building = building;
        }

        // Functinon - validation of building
        private bool validateBuilding(string name)
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
