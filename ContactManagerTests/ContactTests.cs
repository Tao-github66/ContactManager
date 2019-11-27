using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Tests
{
    [TestClass()]
    public class ContactTests
    {
        [TestMethod()]
        public void ContactConstractorValidTest()
        {
            // arrange

            string email = "aa@hotmail.com";

            // act

            Contact c = new Contact(email);

            // assert

            Assert.IsNotNull(c);
            Assert.AreEqual(email, c.Email);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ContactConstractorEmailEmptyTest()
        {
            // arrange

            string email = "";

            // act

            Contact c = new Contact(email);

            // assert

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ContactConstractorEmailNullTest()
        {
            // arrange

            string email = null;

            // act

            Contact c = new Contact(email);

            // assert

            Assert.Fail();
        }

        [TestMethod()]
        public void ContactFacultyConstractorValidTest()
        {
            // arrange

            string email = "aa@hotmail.com";
            string building = "East";

            // act

            ContactFaculty cf = new ContactFaculty(email, building);

            // assert

            Assert.IsNotNull(cf);
            Assert.AreEqual(email, cf.Email);
            Assert.AreEqual(building, cf.Building);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ContactFacultyConstractorBuildingEmptyTest()
        {
            // arrange

            string email = "aa@hotmail.com";
            string building = "";

            // act

            ContactFaculty cf = new ContactFaculty(email, building);

            // assert

            Assert.Fail();

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ContactFacultyConstractorBuildingNullTest()
        {
            // arrange

            string email = "aa@hotmail.com";
            string building = null;

            // act

            ContactFaculty cf = new ContactFaculty(email, building);

            // assert

            Assert.Fail();

        }

        [TestMethod()]
        public void ContactStudentConstractorValidTest()
        {
            // arrange

            string email = "aa@hotmail.com";
            string mail = "335 8th Ave Calgary";

            // act

            ContactStudent cs = new ContactStudent(email, mail);

            // assert

            Assert.IsNotNull(cs);
            Assert.AreEqual(email, cs.Email);
            Assert.AreEqual(mail, cs.SnailMail);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ContactStudentConstractorBuildingEmptyTest()
        {
            // arrange

            string email = "aa@hotmail.com";
            string mail = "";

            // act

            ContactStudent cs = new ContactStudent(email, mail);

            // assert

            Assert.Fail();

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ContactStudentConstractorBuildingNullTest()
        {
            // arrange

            string email = "aa@hotmail.com";
            string mail = null;

            // act

            ContactStudent cs = new ContactStudent(email, mail);

            // assert

            Assert.Fail();

        }
    }
}