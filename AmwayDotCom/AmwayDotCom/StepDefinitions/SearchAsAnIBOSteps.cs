using AmwayDotCom.Framework.Browser;
using AmwayDotCom.Framework.PageObjects;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AmwayDotCom.StepDefinitions
{
    [Binding]
    public class SearchAsAnIBOSteps
    {
        private IWebDriver _driver;
        readonly CustomDriver _csDriver;


        public SearchAsAnIBOSteps()
        {
            _csDriver = (CustomDriver)ScenarioContext.Current["Driver"];

            _driver = _csDriver.GetCurrent();
        }
        

        [Given]
        public void Given_A_user_is_logged_in_as_P0(string p0)
        {
            LoginPage login = new LoginPage(_driver);
            login.Navigate();
            login.login(p0, "qxtr11900");
            login.ValidateLoggedInUserName("JESSIE BROOKS");
            
            
        }

     

        
        [Then]
        public void Then_PVBV_infomation_should_be_available()
        {
            NUnit.Framework.Assert.IsTrue(_driver.PageSource.Contains("PV/BV"),"We did not find the term PV/BV in the page source");
        }
        

    }
}
