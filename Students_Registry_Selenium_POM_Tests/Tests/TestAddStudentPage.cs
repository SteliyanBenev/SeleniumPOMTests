using NUnit.Framework;
using Students_Registry_Selenium_POM_Tests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.Tests
{
    public class TestAddStudentPage : BaseTest
    {
        [Test]
        public void Test_AddStudent_TitleAndHeading()
        {
            //Arrange
            var addStudPage = new AddStudentPage(driver);

            //Act
            addStudPage.Open();

            //Assert
            Assert.AreEqual("Add Student", addStudPage.GetPageTitle());
            Assert.AreEqual("Register New Student", addStudPage.GetPageHeading());
        }

        [Test]
        public void Test_AddStudentPage_Fields_And_Button()
        {
            //Arrange
            var addStudPage = new AddStudentPage(driver);

            //Act
            addStudPage.Open();

            //Assert
            Assert.IsEmpty(addStudPage.NameField.Text);
            Assert.IsEmpty(addStudPage.EMailField.Text);
            Assert.AreEqual("Add", addStudPage.AddButton.Text);
        }

        [Test]
        public void Test_AddStudentPage_HomeLink()
        {
            //Arrange
            var addStudPage = new AddStudentPage(driver);

            //Act
            addStudPage.Open();

            //Assert
            addStudPage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());
        }

        [Test]
        public void Test_AddStudentPage_ViewStudentLink()
        {
            //Arrange
            var addStudPage = new AddStudentPage(driver);

            //Act
            addStudPage.Open();

            //Assert
            addStudPage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_AddStudentPage_AddStudentLink()
        {
            //Arrange
            var addStudPage = new AddStudentPage(driver);

            //Act
            addStudPage.Open();

            //Assert
            addStudPage.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }

        [Test]
        public void Test_AddSudentPage_AddValidStudent()
        {
            //Arrange
            var addStudentPage = new AddStudentPage(driver);
            string studentName = "Stella" + DateTime.Now.Ticks;
            string studentEmail = "email" + DateTime.Now.Ticks + "@abv.bg";
            string expectedStudent = studentName + " (" + studentEmail + ")";

            //Act
            addStudentPage.Open();
            addStudentPage.AddStudent(studentName, studentEmail);

            var viewStudentpage = new ViewStudentsPage(driver);
            var students = viewStudentpage.GetStudentsList();

            //Assert
            Assert.IsTrue(viewStudentpage.IsOpen());
            Assert.Contains(expectedStudent, students);
        }

        [Test]
        public void Test_AddStudentPage_AddInvalidStudent()
        {
            //Arrange
            var addStudPage = new AddStudentPage(driver);

            //Act
            addStudPage.Open();
            addStudPage.GetErrorMessage();

            //Assert
            Assert.IsTrue(addStudPage.IsOpen());
            Assert.AreEqual("Cannot add student. Name and email fields are required!", addStudPage.ErrorMessage.Text);

        }
    }
}
