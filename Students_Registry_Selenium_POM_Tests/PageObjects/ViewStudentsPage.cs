using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.PageObjects
{
    internal class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";
        public ReadOnlyCollection<IWebElement> StudentsList =>
            this.driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetStudentsList()
        {
            string[] students = this.StudentsList.Select(student => student.Text).ToArray();
            return students;
        }
    }
}
