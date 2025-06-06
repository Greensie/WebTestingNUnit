using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebTestingNUnit.Pages
{
    public class InventoryPage
    {
        readonly Dictionary<string, (string addSelector, string removeSelector)> cartItems = new()
        {
            ["backpack"] = ("#add-to-cart-sauce-labs-backpack", "#remove-sauce-labs-backpack"),
            ["bike light"] = ("#add-to-cart-sauce-labs-bike-light", "#remove-sauce-labs-bike-light"),
            ["t-shirt"] = ("#add-to-cart-sauce-labs-bolt-t-shirt", "#remove-sauce-labs-bolt-t-shirt"),
            ["jacket"] = ("#add-to-cart-sauce-labs-fleece-jacket", "#remove-sauce-labs-fleece-jacket"),
            ["onsie"] = ("#add-to-cart-sauce-labs-onesie", "#remove-sauce-labs-onesie"),
            ["red t-shirt"] = ("#add-to-cart-test\\.allthethings\\(\\)-t-shirt-\\(red\\)", "#remove-test\\.allthethings\\(\\)-t-shirt-\\(red\\)")
        };

        readonly string cartBadgeSelector = "#shopping_cart_container > a > span";

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
    }
}
