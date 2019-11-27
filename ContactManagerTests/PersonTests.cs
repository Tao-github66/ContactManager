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
    public class PersonTests
    {
        [TestMethod()]
        public void PersonConstructorValidTest()
        {

            // arrange

            string fn = "Good";
            string ln = "Morning";
            string dp = "Everyone";

            // act

            Person p = new Person(fn, ln, dp);

            // assert

            Assert.IsNotNull(p);
            Assert.AreEqual(fn, p.FirstName);
            Assert.AreEqual(ln, p.LastName);
            Assert.AreEqual(dp, p.Department);
 
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonConstructorEmptyNameTest()
        {

            // arrange

            string fn = "";
            string ln = "Morning";
            string dp = "Everyone";

            // act
            Person p = new Person(fn, ln, dp);

            // assert
 
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonConstructorNullNameTest()
        {

            // arrange

            string fn = null;
            string ln = "Morning";
            string dp = "Everyone";

            // act
            Person p = new Person(fn, ln, dp);

            // assert

            Assert.Fail();
        }

        [TestMethod()]
        public void FacultyConstructorValidTest()
        {

            // arrange

            string fn = "Good";
            string ln = "Morning";
            string dp = "Everyone";
            string email = "aa@hotmail.com";
            string building = "East";
            ContactFaculty cf = new ContactFaculty(email, building);


            // act

            Faculty f = new Faculty(fn, ln, dp, cf);

            // assert

            Assert.IsNotNull(f);
            Assert.AreEqual(fn, f.FirstName);
            Assert.AreEqual(ln, f.LastName);
            Assert.AreEqual(dp, f.Department);
            Assert.AreEqual(cf, f.ContactFaculty);

        }

        [TestMethod()]
        public void StudentConstructorValidTest()
        {

            // arrange

            string fn = "Good";
            string ln = "Morning";
            string dp = "Everyone";
            string gd = "2010";
            string email = "aa@hotmail.com";
            string mail = "335 8th Ave Calgary";
            ContactStudent cs = new ContactStudent(email, mail);
            List<String> co = new List<string>() { "CPRG200", "CPRG210" };


            // act

            Student s = new Student(fn, ln, dp, cs, gd, co);

            // assert

            Assert.IsNotNull(s);
            Assert.AreEqual(fn, s.FirstName);
            Assert.AreEqual(ln, s.LastName);
            Assert.AreEqual(dp, s.Department);
            Assert.AreEqual(cs, s.StudentCont);
            Assert.AreEqual(gd, s.GraduationYear);
            Assert.AreEqual(co, s.Course);


        }
    }
}