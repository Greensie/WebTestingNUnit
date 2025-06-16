using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebTestingNUnit.Utils
{
    public class ResetWebsiteState
    {
        readonly static string menuSelector = "#react-burger-menu-btn";
        readonly static string resetSelector = "#reset_sidebar_link";
        readonly static string abosluteMenuSelector = "#inventory_sidebar_link";

        /**************************************************************************************************************
        * Method for ensuring clear web state before testing.
        **************************************************************************************************************/
        public void ResetAppState(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(menuSelector)).Click();
            driver.FindElement(By.CssSelector(resetSelector)).Click();
        }

        /**************************************************************************************************************
        * Method for coming back to main page from any perspective.
        **************************************************************************************************************/
        public void AbsoluteBackToMainPage(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(menuSelector)).Click();
            driver.FindElement(By.CssSelector(abosluteMenuSelector)).Click();
        }
    }
}
