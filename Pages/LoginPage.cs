using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebTestingNUnit.Pages
{
    public class LoginPage
    {
        readonly string loginSelector = "#user-name";
        readonly string passwordSelector = "#password";
        readonly string loginButtonSelector = "#login-button";

        public void Login(IWebDriver driver,string username, string password)
        {
            IWebElement login = driver.FindElement(By.CssSelector(loginSelector));
            IWebElement pass = driver.FindElement(By.CssSelector(passwordSelector));
            IWebElement loginButton = driver.FindElement(By.CssSelector(loginButtonSelector));
            login.SendKeys(username);
            pass.SendKeys(password);
            loginButton.Click();
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
    }
}
