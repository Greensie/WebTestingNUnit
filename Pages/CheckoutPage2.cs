using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebTestingNUnit.Pages
{
    public class CheckoutPage2
    {
        readonly string cancelSelector = "#cancel";
        readonly string finishSelector = "#finish";
        readonly string itemTotalSelector = "#checkout_summary_container > div > div.summary_info > div.summary_subtotal_label";
        readonly string taxSelector = "#checkout_summary_container > div > div.summary_info > div.summary_tax_label";
        readonly string totalSelector = "#checkout_summary_container > div > div.summary_info > div.summary_total_label";
        readonly string shippingSelector = "#checkout_summary_container > div > div.summary_info > div:nth-child(4)";
        readonly string paymentSelector = "#checkout_summary_container > div > div.summary_info > div:nth-child(2)";

       /**************************************************************************************************************
       * Method for proceeding to finish shopping.
       **************************************************************************************************************/
        public void FinishShopping(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(finishSelector)).Click();
        }

       /**************************************************************************************************************
       * Method for leaving recipt page.
       **************************************************************************************************************/
        public void CancelShopping(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(cancelSelector)).Click();
        }

       /**************************************************************************************************************
       * Method for checking item final prices. If option is invalid or not specified it returns prices with tax included.
       * If option is specified it returns:
       * 0 - item total without taxes
       * 1 - tax value
       * 2 - items with tax included
       **************************************************************************************************************/
        public string GetPrices(IWebDriver driver, int option)
        {
            string[] webdata = {driver.FindElement(By.CssSelector(itemTotalSelector)).Text,
                driver.FindElement(By.CssSelector(taxSelector)).Text,
                driver.FindElement(By.CssSelector(totalSelector)).Text };

            if (option == 0)
            {
                return webdata[0];
            }

            if (option == 1)
            {
                return webdata[1];
            }

            return webdata[2];
        }

       /**************************************************************************************************************
       * Method for getting a shipping information.
       **************************************************************************************************************/
        public string GetShippingInformation(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(shippingSelector)).Text;
        }

       /**************************************************************************************************************
       * Method for getting a payment information.
       **************************************************************************************************************/
        public string GetPaymentInformation(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(paymentSelector)).Text;
        }

       /**************************************************************************************************************
       * Method for checking if driver is on checkout page one.
       **************************************************************************************************************/
        public bool IsAt(IWebDriver driver)
        {
            return driver.Url.Contains("checkout-step-two");
        }
    }
}
