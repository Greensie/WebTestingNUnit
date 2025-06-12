using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebTestingNUnit.Pages
{
    /**************************************************************************************************************
    * Componet responisble for handling checkout page one - providing customer data.
    **************************************************************************************************************/
    public class CheckoutPage1
    {
        readonly string cancelSelector = "#cancel";
        readonly string continueSelector = "#continue";
        readonly string firstNameSelector = "#first-name";
        readonly string lastNameSelector = "#last-name";
        readonly string zipCodeSelector = "#postal-code";
        readonly string errorSelector = "#checkout_info_container > div > form > div.checkout_info > div.error-message-container.error > h3";

        /**************************************************************************************************************
        * Method for entering all data needed for succesful proceed.
        **************************************************************************************************************/
        public void enterData(IWebDriver driver, string? firstname = null, string? lastname = null, string? zipcode = null) 
        {
            if (firstname != null)
            {
                driver.FindElement(By.CssSelector(firstNameSelector)).SendKeys(firstname);
            }
            if (lastname != null)
            {
                driver.FindElement(By.CssSelector(lastNameSelector)).SendKeys(lastname);
            }
            if (zipcode != null)
            {
                driver.FindElement(By.CssSelector(zipCodeSelector)).SendKeys(zipcode);
            }
        }

       /**************************************************************************************************************
       * Method for going back to cart.
       **************************************************************************************************************/
        public void goBackToCart(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(cancelSelector)).Click();
        }

       /**************************************************************************************************************
       * Method for proceeding to checkout page 2.
       **************************************************************************************************************/
        public void proceedFurther(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(continueSelector)).Click();
        }

       /**************************************************************************************************************
       * Method for checking if driver is on checkout page one.
       **************************************************************************************************************/
        public bool isAt(IWebDriver driver)
        {
            return driver.Url.Contains("checkout-step-one");
        }

       /**************************************************************************************************************
       * Method for checking if error describing missing first name is present.
       **************************************************************************************************************/
        public bool isFirstNameErrorPresent(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(errorSelector)).Text == "Error: First Name is required";
        }

       /**************************************************************************************************************
       * Method for checking if error describing missing last name is present.
       **************************************************************************************************************/
        public bool isLastNameErrorPresent(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(errorSelector)).Text == "Error: Last Name is required";
        }

       /**************************************************************************************************************
       * Method for checking if error describing missing zip code is present.
       **************************************************************************************************************/
        public bool isZipCodeErrorPresent(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(errorSelector)).Text == "Error: Postal Code is required";
        }
    }
}
