using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebTestingNUnit.Pages
{
    /**************************************************************************************************************
     * Componet responisble for handling operations on inventory page.
     **************************************************************************************************************/
    public class InventoryPage
    {
        readonly Dictionary<string, (string addSelector, string removeSelector, string pageSelector, string textSelector, string priceSelector)> cartItems = new()
        {
            ["backpack"] = 
            ("#add-to-cart-sauce-labs-backpack",
            "#remove-sauce-labs-backpack",
            "#item_4_title_link > div",
            "#inventory_container > div > div:nth-child(1) > div.inventory_item_description > div.inventory_item_label > div",
            ,"#inventory_container > div > div:nth-child(1) > div.inventory_item_description > div.pricebar > div"),
            ["bike light"] = 
            ("#add-to-cart-sauce-labs-bike-light",
            "#remove-sauce-labs-bike-light",
            "#item_0_title_link > div",
            "#inventory_container > div > div:nth-child(2) > div.inventory_item_description > div.inventory_item_label > div",
            "#inventory_container > div > div:nth-child(2) > div.inventory_item_description > div.pricebar > div"),
            ["t-shirt"] = 
            ("#add-to-cart-sauce-labs-bolt-t-shirt",
            "#remove-sauce-labs-bolt-t-shirt",
            "#item_1_title_link > div",
            "#inventory_container > div > div:nth-child(3) > div.inventory_item_description > div.inventory_item_label > div",
            "#inventory_container > div > div:nth-child(3) > div.inventory_item_description > div.pricebar > div"),
            ["jacket"] = 
            ("#add-to-cart-sauce-labs-fleece-jacket",
            "#remove-sauce-labs-fleece-jacket",
            "#item_5_title_link > div",
            "#inventory_container > div > div:nth-child(4) > div.inventory_item_description > div.inventory_item_label > div",
            "#inventory_container > div > div:nth-child(3) > div.inventory_item_description > div.pricebar > div"),
            ["onsie"] = 
            ("#add-to-cart-sauce-labs-onesie",
            "#remove-sauce-labs-onesie",
            "#item_2_title_link > div",
            "#inventory_container > div > div:nth-child(5) > div.inventory_item_description > div.inventory_item_label > div",
            "#inventory_container > div > div:nth-child(5) > div.inventory_item_description > div.pricebar > div"),
            ["red t-shirt"] = 
            ("#add-to-cart-test\\.allthethings\\(\\)-t-shirt-\\(red\\)",
            "#remove-test\\.allthethings\\(\\)-t-shirt-\\(red\\)",
            "#item_3_title_link > div",
            "#inventory_container > div > div:nth-child(6) > div.inventory_item_description > div.inventory_item_label > div",
            "#inventory_container > div > div:nth-child(6) > div.inventory_item_description > div.pricebar > div")
        };

        readonly string cartBadgeSelector = "#shopping_cart_container > a > span";
        readonly string cartSelector = "#shopping_cart_container > a";

        /**************************************************************************************************************
        * Method for adding items to cart.
        **************************************************************************************************************/
        public void AddItemToCart(IWebDriver driver, string item)
        {
            item = item.ToLower();
            if (cartItems.TryGetValue(item, out var selectors))
            {
                driver.FindElement(By.CssSelector(selectors.addSelector)).Click();
            }
            else
            {
                throw new Exception($"Item '{item}' does not exist on the page");
            }
        }

        /**************************************************************************************************************
        * Method for removing items from cart.
        **************************************************************************************************************/
        public void RemoveItemFromCart(IWebDriver driver, string item)
        {
            item = item.ToLower();
            if (cartItems.TryGetValue(item, out var selectors))
            {
                driver.FindElement(By.CssSelector(selectors.removeSelector)).Click();
            }
            else
            {
                throw new Exception($"Item '{item}' does not exist on the page");
            }
        }

       /**************************************************************************************************************
       * Method for getting number of items in cart from inventory page perspective.
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

       /**************************************************************************************************************
       * Method for proceeding into cart.
       **************************************************************************************************************/
        public void EnterCart(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(cartSelector)).Click();
        }

       /**************************************************************************************************************
       * Method for checking if driver is currently on inventory page.
       **************************************************************************************************************/
        public bool IsAt(IWebDriver driver)
        {
            return driver.Url.Contains("inventory");
        }

       /**************************************************************************************************************
       * Method for entering item page from inventory page perspective.
       **************************************************************************************************************/
        public void EnterItemPage(IWebDriver driver, string item)
        {
            item = item.ToLower();
            if (cartItems.TryGetValue(item, out var selectors))
            {
                driver.FindElement(By.CssSelector(selectors.pageSelector)).Click();
            }
            else
            {
                throw new Exception($"Item '{item}' does not exist on the page");
            }
        }

       /**************************************************************************************************************
       * Method for getting item name from inventory page perspective.
       **************************************************************************************************************/
        public string GetItemName(IWebDriver driver, string item)
        {
            item = item.ToLower();
            if (cartItems.TryGetValue(item, out var selectors))
            {
                return driver.FindElement(By.CssSelector(selectors.pageSelector)).Text;
            }
            else
            {
                throw new Exception($"Item '{item}' does not exist on the page");
            }
        }

       /**************************************************************************************************************
       * Method for getting item price as string = '$price', from inventory page perspective.
       **************************************************************************************************************/
        public string GetItemPriceString(IWebDriver driver, string item)
        {
            item = item.ToLower();
            if (cartItems.TryGetValue(item, out var selectors))
            {
                return driver.FindElement(By.CssSelector(selectors.priceSelector)).Text;
            }
            else
            {
                throw new Exception($"Item '{item}' does not exist on the page");
            }
        }

       /**************************************************************************************************************
       * Method for getting item price as float from inventory page perspective.
       **************************************************************************************************************/
        public float GetItemPriceFloat(IWebDriver driver, string item)
        {
            item = item.ToLower();
            if (cartItems.TryGetValue(item, out var selectors))
            {
                string str = driver.FindElement(By.CssSelector(selectors.priceSelector)).Text;
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
            else
            {
                throw new Exception($"Item '{item}' does not exist on the page");
            }
        }
    }
}
