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
        #region selectors
        readonly string addSelector = "#add-to-cart";
        readonly string removeSelector = "#remove";
        readonly string backSelector = "#back-to-products";
        readonly string cartBadgeSelector = "#shopping_cart_container > a > span";
        readonly string cartSelector = "#shopping_cart_container > a";
        readonly string nameSelector = "#inventory_item_container > div > div > div.inventory_details_desc_container > div.inventory_details_name.large_size";
        readonly string textSelector = "#inventory_item_container > div > div > div.inventory_details_desc_container > div.inventory_details_desc.large_size";
        readonly string priceSelector = "#inventory_item_container > div > div > div.inventory_details_desc_container > div.inventory_details_price";
        #endregion

        #region  bool methods
        /**************************************************************************************************************
        * Method for checking if driver is on item page.
        **************************************************************************************************************/
        public bool IsAt(IWebDriver driver)
        {
            return driver.Url.Contains("inventory-item");
        }

        /**************************************************************************************************************
       * Method for checking if item is already in cart.
       **************************************************************************************************************/
        public bool IsItemInCart(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(removeSelector)).Displayed;
        }

        /**************************************************************************************************************
        * Method for checking if item is already in cart.
        **************************************************************************************************************/
        public bool IsItemNotInCart(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(addSelector)).Displayed;
        }
        #endregion

        #region variable_methods

        /**************************************************************************************************************
        * Method getting item name.
        **************************************************************************************************************/
        public string GetItemName(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(nameSelector)).Text;
        }

        /**************************************************************************************************************
        * Method getting item price as '$price'.
        **************************************************************************************************************/
        public string GetItemPriceString(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(priceSelector)).Text;
        }

        /**************************************************************************************************************
        * Method getting item price as float value.
        **************************************************************************************************************/
        public float GetItemPriceFloat(IWebDriver driver)
        {
            string str = driver.FindElement(By.CssSelector(priceSelector)).Text;
            string strmod = str.Substring(1);
            float ret;
            try
            {
                ret = float.Parse(strmod);
            }
            catch (InvalidCastException)
            {
                ret = 0;
            }
            return ret;
        }

        /**************************************************************************************************************
        * Method getting item description.
        **************************************************************************************************************/
        public string GetItemDescription(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(textSelector)).Text;
        }

        /**************************************************************************************************************
        * Method for getting number of items in cart from item page perspective.
        **************************************************************************************************************/
        public int GetCartItemCount(IWebDriver driver)
        {
            try
            {
                var badge = driver.FindElement(By.CssSelector(cartBadgeSelector));
                return int.Parse(badge.Text);
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }

        #endregion

        #region void_methods
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
       * Method for entering cart from item page perspective.
       **************************************************************************************************************/
        public void EnterCart(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(cartSelector)).Click();
        }

        #endregion
    }
}
