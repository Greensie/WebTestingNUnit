using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace WebTestingNUnit.Base
{
    /**************************************************************************************************************
     * Base for all the tests with opening browser.
     * SetUp -> Open Edge and enter testing page saucedemo.com
     * TearDown -> Dispose  web driver
     *************************************************************************************************************/
    public class BaseTestEdge
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new EdgeOptions();
            options.AddArgument("start-maximized");

            driver = new EdgeDriver(options);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
