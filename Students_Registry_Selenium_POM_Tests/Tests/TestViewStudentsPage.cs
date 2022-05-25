using NUnit.Framework;
using Students_Registry_Selenium_POM_Tests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.Tests
{
    public class TestViewStudentsPage : BaseTest 
    {
        [Test]
        public void Test_ViewStudentsPage_TitleAndHeading()
        {
            var studentPage = new ViewStudentsPage(driver);
            studentPage.Open();

            Assert.AreEqual("Students", studentPage.GetPageTitle());
            Assert.AreEqual("Registered Students", studentPage.GetPageHeading());
        }

        [Test]
        public void Test_Check_Students()
        {
            var studentPage = new ViewStudentsPage(driver);
            studentPage.Open();

            var students = studentPage.GetStudentsList();

            foreach (var student in students)
            {
                Assert.IsTrue(student.IndexOf("(") > 0);
                Assert.IsTrue(student.LastIndexOf(")") == student.Length - 1);
            }
        }

        [Test]
        public void Test_ViewStudentsPage_HomeLink()
        {
            //Arrange
            var viewPage = new ViewStudentsPage(driver);

            //Act
            viewPage.Open();

            //Assert
            viewPage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());
        }

        [Test]
        public void Test_ViewStudentsPage_ViewStudentLink()
        {
            //Arrange
            var viewPage = new ViewStudentsPage(driver);

            //Act
            viewPage.Open();

            //Assert
            viewPage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_ViewStudentsPage_AddStudentLink()
        {
            //Arrange
            var viewPage = new ViewStudentsPage(driver);

            //Act
            viewPage.Open();

            //Assert
            viewPage.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }
    }
}
