using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;
using WebTestingNUnit.Pages;

namespace WebTestingNUnit.Tests.TC_004
{
    public class TC_004_BaseCartTests_Edge_Headless : BaseTestEdgeHeadless
    {

        [Test]
        public void addAllItemsToCartThenRemoveIt_Edge_Headless()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            string[] items = { "backpack", "bike light", "t-shirt", "jacket", "onsie", "red t-shirt" };

            Assert.That(loginPage.isAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            Assert.That(inventoryPage.isAt(driver));

            foreach (var item in items)
            {
                inventoryPage.AddItemToCart(driver, item);
                Thread.Sleep(100);
            }
            int itemsInCartAfterAdding = inventoryPage.GetCartItemCount(driver);
            Assert.That(itemsInCartAfterAdding, Is.EqualTo(6), "All items added to the cart!");

            Thread.Sleep(250);

            foreach (var item in items)
            {
                inventoryPage.RemoveItemFromCart(driver, item);
                Thread.Sleep(100);
            }
            int itemsInCartAfterRemoving = inventoryPage.GetCartItemCount(driver);

            Assert.That(itemsInCartAfterRemoving, Is.EqualTo(0), "All items removed from the cart!");
        }

        [Test]
        public void addAllItemsToCartThenProceedToCartAndCheck_Edge_Headless()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            var cartPage = new CartPage();
            string[] itemsShort = { "backpack", "bike light", "t-shirt" };


            Assert.That(loginPage.isAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            Assert.That(inventoryPage.isAt(driver), Is.True, "Entered inventory Page sucesfully");

            foreach (var item in itemsShort)
            {
                inventoryPage.AddItemToCart(driver, item);
                Thread.Sleep(50);
            }
            int itemsInCartAfterAdding = inventoryPage.GetCartItemCount(driver);
            Assert.That(itemsInCartAfterAdding, Is.EqualTo(3), "All items added to the cart!");

            Thread.Sleep(250);

            inventoryPage.EnterCart(driver);
            Assert.That(cartPage.isAt(driver), Is.True, "Enteret cart Page sucesfully");
            foreach (var item in itemsShort)
            {
                int itemCount = cartPage.getItemCountInCart(driver, item);
                Assert.That(itemCount == 1);
                Thread.Sleep(50);
            }

        }
    }
}
