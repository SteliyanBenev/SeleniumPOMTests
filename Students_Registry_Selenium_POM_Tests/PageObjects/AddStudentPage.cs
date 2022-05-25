using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.PageObjects
{
    internal class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";
        public IWebElement NameField => this.driver.FindElement(By.Id("name"));
        public IWebElement EMailField => this.driver.FindElement(By.Id("email"));
        public IWebElement AddButton => this.driver.FindElement(By.CssSelector("body > form > button"));
        public IWebElement ErrorMessage => this.driver.FindElement(By.CssSelector("body > div"));

        public void AddStudent(string name, string email)
        {
            this.NameField.SendKeys(name);
            this.EMailField.SendKeys(email);
            this.AddButton.Click();
        }

        public string GetErrorMessage()
        {
            this.NameField.Clear();
            this.EMailField.Clear();
            this.AddButton.Click();
            return this.ErrorMessage.Text;
        }
    }
}
