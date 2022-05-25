using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.PageObjects
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        public virtual string PageUrl { get; }
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public IWebElement LinkHomePage => this.driver.FindElement(By.LinkText("Home"));
        public IWebElement LinkViewStudentsPage => 
            this.driver.FindElement(By.LinkText("View Students"));
        public IWebElement LinkAddStudentsPage => 
            this.driver.FindElement(By.LinkText("Add Student"));
        public IWebElement ElementTextHeading => 
            this.driver.FindElement(By.CssSelector("body > h1"));

        public void Open()
        {
            this.driver.Navigate().GoToUrl(this.PageUrl);
        }

        public bool IsOpen()
        {
            return this.driver.Url == this.PageUrl;
        }

        public string GetPageTitle()
        {
            return this.driver.Title;
        }

        public string GetPageHeading()
        {
            return this.ElementTextHeading.Text;
        }
    }
}
