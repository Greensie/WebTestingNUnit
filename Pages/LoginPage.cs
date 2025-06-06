using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebTestingNUnit.Pages
{
    public class LoginPage
    {
        readonly string loginSelector = "#user-name";
        readonly string passwordSelector = "#password";
        readonly string loginButtonSelector = "#login-button";
        readonly string errorSelector = "#login_button_container > div > form > div.error-message-container.error > h3";

        public void Login(IWebDriver driver, string username, string password)
        {
            IWebElement login = driver.FindElement(By.CssSelector(loginSelector));
            IWebElement pass = driver.FindElement(By.CssSelector(passwordSelector));
            login.SendKeys(username);
            pass.SendKeys(password);
            driver.FindElement(By.CssSelector(loginButtonSelector)).Click();
        }

        public bool isAt(IWebDriver driver)
        {
            bool exists = driver.FindElement(By.CssSelector(loginButtonSelector)).Displayed;
            if (exists)
            {
                TestContext.WriteLine("Login Page Loaded Succesfully");
            }
            else
            {
                TestContext.WriteLine("Login Page Not Loaded");
            }
            return exists;
        }

        public string LoginExpectingFailure(IWebDriver driver, string username, string password)
        {
            IWebElement login = driver.FindElement(By.CssSelector(loginSelector));
            IWebElement pass = driver.FindElement(By.CssSelector(passwordSelector));
            login.SendKeys(username);
            pass.SendKeys(password);
            driver.FindElement(By.CssSelector(loginButtonSelector)).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(errorSelector)));
            string retText = driver.FindElement(By.CssSelector(errorSelector)).Text.ToString();
            return retText;
        }

        public void LoginAsStandardUser(IWebDriver driver)
        {
            Login(driver, "standard_user", "secret_sauce");
        }
    }
}
