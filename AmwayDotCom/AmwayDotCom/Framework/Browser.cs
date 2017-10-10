using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Specialized;

using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AmwayDotCom.Framework.Browser
{
    [Binding]
    public sealed class BrowserSetup
    {
        private CustomDriver Driver;
      

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver = new CustomDriver(ScenarioContext.Current);
            ScenarioContext.Current["Driver"] = Driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Cleanup();
        }
    }


    public class CustomDriver
    {
        private IWebDriver driver;
     
        private ScenarioContext context;

        public CustomDriver(ScenarioContext context)
        {
            this.context = context;
        }

        public IWebDriver Init()
        {
            

            ChromeOptions options = new ChromeOptions();

            driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);

            this.context.Add("CurrentBrowser", driver);
            return driver;
        }

        public IWebDriver GetCurrent()
        {
            return driver;
        }

        public void Cleanup()
        {
            driver.Quit();

        }


    }
}