﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebTestingNUnit.Utils;

namespace WebTestingNUnit.Pages
{
    /**************************************************************************************************************
     * Componet responisble for logging in the page.
     **************************************************************************************************************/
    public class LoginPage
    {
        readonly string loginSelector = "#user-name";
        readonly string passwordSelector = "#password";
        readonly string loginButtonSelector = "#login-button";
        readonly string errorSelector = "#login_button_container > div > form > div.error-message-container.error > h3";

       /**************************************************************************************************************
       * Default login method.
       **************************************************************************************************************/
        public void Login(IWebDriver driver, string username, string password)
        {
            IWebElement login = driver.FindElement(By.CssSelector(loginSelector));
            IWebElement pass = driver.FindElement(By.CssSelector(passwordSelector));
            login.SendKeys(username);
            pass.SendKeys(password);
            driver.FindElement(By.CssSelector(loginButtonSelector)).Click();
        }

       /**************************************************************************************************************
       * Method for checking if driver is on login page.
       **************************************************************************************************************/
        public bool IsAt(IWebDriver driver)
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

       /**************************************************************************************************************
       * Method of logging failure user.
       **************************************************************************************************************/
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

       /**************************************************************************************************************
       * Method for loging standard user.
       **************************************************************************************************************/
        public void LoginAsStandardUser(IWebDriver driver)
        {
            Login(driver, "standard_user", "secret_sauce");
        }

       /**************************************************************************************************************
       * Method for loging problem user.
       **************************************************************************************************************/
        public void LoginAsProblemUser(IWebDriver driver)
        {
            Login(driver, "problem_user", "secret_sauce");
        }

       /**************************************************************************************************************
       * Method for loging visual user.
       **************************************************************************************************************/
        public void LoginAsVisualUser(IWebDriver driver)
        {
            Login(driver, "visual_user", "secret_sauce");
        }
    }
}
