using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebTestingNUnit.Base;
using WebTestingNUnit.Pages;

namespace WebTestingNUnit.Tests
{
    public class TC_004_BaseCartTests : BaseTestHeadless
    {
        [Test]
        public void addAllItemsToCartThenRemoveIt()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            string[] items = {"backpack", "bike light", "t-shirt", "jacket", "onsie", "red t-shirt" };

            Assert.That(loginPage.isAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            Assert.That(driver.Url.Contains("inventory"));
            
            foreach (var item in items)
            {
                inventoryPage.AddItemToCart(driver, item);
                Thread.Sleep(50);
            }
            int itemsInCartAfterAdding = inventoryPage.GetCartItemCount(driver);
            Assert.That(itemsInCartAfterAdding, Is.EqualTo(6), "All items added to the cart!");

            Thread.Sleep(250);
            
            foreach (var item in items)
            {
                inventoryPage.RemoveItemFromCart(driver, item);
                Thread.Sleep(50);
            }
            int itemsInCartAfterRemoving = inventoryPage.GetCartItemCount(driver);

            Assert.That(itemsInCartAfterRemoving, Is.EqualTo(0), "All items removed from the cart!");
        }
    }
}
