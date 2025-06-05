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
    public class LogoutComponent
    {
        readonly string menuSelector = "#react-burger-menu-btn";
        readonly string logoutSelector = "#logout_sidebar_link";
        public void Logout(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(menuSelector)).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(logoutSelector)));
            driver.FindElement(By.CssSelector(logoutSelector)).Click();
        }

        public bool IsLoggedOut(IWebDriver driver)
        {
            return driver.Title == "Swag Labs";
        }
    }
}
