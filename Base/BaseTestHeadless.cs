using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace WebTestingNUnit.Base
{
    /**************************************************************************************************************
     * Base for all the tests with headless browser operations.
     * SetUp -> Open Chrome and enter testing page saucedemo.com
     * TearDown -> Dispose  web driver
     *************************************************************************************************************/
    public class BaseTestHeadless
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");
            options.AddArgument("--disable-gpu");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
