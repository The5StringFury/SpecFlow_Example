using AmwayDotCom.Framework.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace AmwayDotCom
{
    [Binding]
    public class SearchAsAVisitorSteps
    {
        private IWebDriver _driver;
        readonly CustomDriver _csDriver;

        public SearchAsAVisitorSteps()
        {
            _csDriver = (CustomDriver)ScenarioContext.Current["Driver"];
            
        }

        [Given]
        public void Given_A_user_is_on_amway_com()
        {
            _driver = _csDriver.Init();
            _driver.Navigate().GoToUrl("http://www.amway.com");
            
        }
        

        
        [When]
        public void When_the_user_searches_for_P0(string p0)
        {
            var searchbox = _driver.FindElement(By.Id("ctl00_ctl09___ctl00___tbxSearchInterface"));
            searchbox.SendKeys(p0);
            searchbox.SendKeys(Keys.Enter);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("*")));
        }       

        
        [Then]
        public void Then_the_result_screen_should_be_displayed()
        {
            NUnit.Framework.Assert.IsTrue(_driver.Url.Contains("SearchResults.aspx"), "Results Page was not displayed as expected");
        }
        
        [Then]
        public void Then_the_product_page_should_be_displayed()
        {
            NUnit.Framework.Assert.IsTrue(_driver.Url.Contains("Product.aspx"), "Product Page not displayed as expected");
        }       
   
        
        [Then]
        public void Then_the_screen_should_display_text_indicating_these_are_correctd()
        {
            NUnit.Framework.Assert.IsTrue(_driver.PageSource.Contains("yielded no results, but we did find"), "Corrected Results Page was not displayed as expected");
        }


        [Then]
        public void Then_the_result_should_be_no_results_found()
        {
            NUnit.Framework.Assert.IsTrue(_driver.PageSource.Contains("yielded no results. Please enter another product name or keyword in the search box."));
        }


    }
}
