using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Css.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static NUnit.Framework.Constraints.Tolerance;

namespace WebTestingNUnit.Pages
{
    public class CartPage
    {
        readonly string continueShoppingSelector = "#continue-shopping";
        readonly string checkoutSelector = "#checkout";

        readonly Dictionary<string, (string quantitySelector, string removeSelector)> cartItems = new()
        {
            ["backpack"] = ("#cart_contents_container > div > div.cart_list > div:nth-child(3) > div.cart_quantity", "#remove-sauce-labs-backpack"),
            ["bike light"] = ("#cart_contents_container > div > div.cart_list > div:nth-child(4) > div.cart_quantity", "#remove-sauce-labs-bike-light"),
            ["t-shirt"] = ("#cart_contents_container > div > div.cart_list > div:nth-child(5) > div.cart_quantity", "#remove-sauce-labs-bolt-t-shirt"),
            ["jacket"] = ("#cart_contents_container > div > div.cart_list > div:nth-child(6) > div.cart_quantity", "#remove-sauce-labs-fleece-jacket"),
            ["onsie"] = ("#cart_contents_container > div > div.cart_list > div:nth-child(7) > div.cart_quantity > div.cart_quantity", "#remove-sauce-labs-onesie"),
            ["red t-shirt"] = ("#cart_contents_container > div > div.cart_list > div:nth-child(8) > div.cart_quantity", "#remove-test\\.allthethings\\(\\)-t-shirt-\\(red\\)")
        };

        public bool isAt(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(checkoutSelector)));
            bool exists = driver.FindElement(By.CssSelector(checkoutSelector)).Displayed;
            if (exists)
            {
                TestContext.WriteLine("Cart Page Loaded Succesfully");
            }
            else
            {
                TestContext.WriteLine("Cart Page Not Loaded");
            }
            return exists;
        }

        public int getItemCountInCart(IWebDriver driver, string name)
        {
            name = name.ToLower();
            if (cartItems.TryGetValue(name, out var selectors))
            {
                try
                {
                    var num = driver.FindElement(By.CssSelector(selectors.quantitySelector));
                    return int.Parse(num.Text);
                }
                catch(NoSuchElementException)
                {
                    TestContext.WriteLine($"{name} not found on the page!!!!");
                    return 0;
                }
                
            }
            else
            {
                return 0;
            }
        }

        public void removeItemForomCart(IWebDriver driver, string name)
        {
            name = name.ToLower();
            if (cartItems.TryGetValue(name, out var selectors))
            {
                driver.FindElement(By.CssSelector(selectors.removeSelector)).Click();
            }
        }

        public bool isCartEmpty(IWebDriver driver)
        {
            var items = driver.FindElements(By.ClassName("cart_item"));
            return items.Count == 0;
        }

        public void proceedToPayment(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(checkoutSelector)).Click();
        }
    }
}
