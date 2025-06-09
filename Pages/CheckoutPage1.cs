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

       /**************************************************************************************************************
       * Method for entering all data needed for succesful proceed.
       **************************************************************************************************************/
        public void enterAllData(IWebDriver driver, string firstname, string lastname, string zipcode) 
        {
            driver.FindElement(By.CssSelector(firstNameSelector)).SendKeys(firstname);
            driver.FindElement(By.CssSelector(lastNameSelector)).SendKeys(lastname);
            driver.FindElement(By.CssSelector(zipCodeSelector)).SendKeys(zipcode);
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
    }
}
