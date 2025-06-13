using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebTestingNUnit.Pages
{
    public class ItemPage
    {
        readonly string addSelector = "#add-to-cart";
        readonly string removeSelector = "#remove";
        readonly string backSelector = "#back-to-products";

       /**************************************************************************************************************
       * Method for checking if driver is on item page.
       **************************************************************************************************************/
        public bool IsAt(IWebDriver driver)
        {
            return driver.Url.Contains("inventory-item");
        }

       /**************************************************************************************************************
       * Method for adding item to cart on item page.
       **************************************************************************************************************/
        public void AddItemToCart(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(addSelector)).Click();
        }

       /**************************************************************************************************************
       * Method for removing item from cart on item page.
       **************************************************************************************************************/
        public void RemoveItemFromCart(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(removeSelector)).Click();
        }

       /**************************************************************************************************************
       * Method for entering inventory page via button from item page.
       **************************************************************************************************************/
        public void BackToMainPage(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(backSelector)).Click();
        }

       /**************************************************************************************************************
       * Method for checking if item is already in cart.
       **************************************************************************************************************/
        public bool IsItemInCart(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(removeSelector)).Displayed;
        }

    }
}
