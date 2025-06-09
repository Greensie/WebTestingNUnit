using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebTestingNUnit.Components
{
     /**************************************************************************************************************
     * Componet responisble for logging off the page.
     **************************************************************************************************************/
    public class LogoutComponent
    {
        readonly string menuSelector = "#react-burger-menu-btn";
        readonly string logoutSelector = "#logout_sidebar_link";

         /**************************************************************************************************************
         * Method for actuall loging off.
         **************************************************************************************************************/
        public void Logout(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(menuSelector)).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(logoutSelector)));
            driver.FindElement(By.CssSelector(logoutSelector)).Click();
        }

        /**************************************************************************************************************
        * Method for checking if operation of logging off was succesful and main page is visible.
        **************************************************************************************************************/
        public bool IsLoggedOut(IWebDriver driver)
        {
            return driver.Title == "Swag Labs";
        }
    }
}
