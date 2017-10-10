using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmwayDotCom.Framework.PageObjects
{
    public class LoginPage
    {

        private readonly IWebDriver driver;
        private readonly string url = @"http://www.amway.com/Shop/Access/Login.aspx?ReturnURL=https://www.amway.com/";

        public LoginPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }


        [FindsBy(How = How.Id, Using = "txtUserName")]
        public IWebElement UserNameBox { get; set; }

        [FindsBy(How = How.Id, Using = "txtPassword")]
        public IWebElement PasswordBox { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void login(string passedUserName, string passedPassword)
        {
            this.UserNameBox.SendKeys(passedUserName);
            this.PasswordBox.SendKeys(passedPassword);
            this.PasswordBox.SendKeys(Keys.Enter);
            
        }

        public void ValidateLoggedInUserName(string expectedUserName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl09___lnkLogout")));

            Assert.IsTrue(driver.PageSource.Contains(expectedUserName));
        }



    }
}
