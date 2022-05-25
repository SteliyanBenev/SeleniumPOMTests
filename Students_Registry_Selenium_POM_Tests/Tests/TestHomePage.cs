using NUnit.Framework;
using Students_Registry_Selenium_POM_Tests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.Tests
{
    public class TestHomePage : BaseTest
    {
        [Test]
        public void Test_HomePage_TitleAndHeading()
        {
            //Arrange
            var homePage = new HomePage(driver);

            //Act
            homePage.Open();

            //Assert
            Assert.AreEqual("MVC Example", homePage.GetPageTitle());
            Assert.AreEqual("Students Registry", homePage.GetPageHeading());
        }

        [Test]
        public void Test_HomePage_StudensCount()
        {
            //Arrange
            var homePage = new HomePage(driver);

            //Act
            homePage.Open();

            //Assert
            Assert.GreaterOrEqual(homePage.GetStudentsCount(), 0);
        }

        [Test]
        public void Test_HomePage_HomeLink()
        {
            //Arrange
            var homePage = new HomePage(driver);

            //Act
            homePage.Open();

            //Assert
            homePage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());
        }

        [Test]
        public void Test_HomePage_ViewStudentLink()
        {
            //Arrange
            var homePage = new HomePage(driver);

            //Act
            homePage.Open();

            //Assert
            homePage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_HomePage_AddStudentLink()
        {
            //Arrange
            var homePage = new HomePage(driver);

            //Act
            homePage.Open();

            //Assert
            homePage.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }

    }
}
