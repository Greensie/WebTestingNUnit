using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;
using WebTestingNUnit.Components;
using WebTestingNUnit.Pages;
using WebTestingNUnit.Utils;

namespace WebTestingNUnit.Tests.TC_007
{
    public class TC_007_ItemsCart_Chrome_Headless : BaseTestHeadless
    {
        [Test]
        public void AddItemsToCartThanCheckIfAdded()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            var itemPage = new ItemPage();
            var logoutComponent = new LogoutComponent();
            string[] items = { "backpack", "bike light", "t-shirt", "jacket", "onsie", "red t-shirt" };
            int expItemsInCart = 1;
            int expItemsOutCart = 0;

            AssertHelper.AssertAndLog(loginPage.IsAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            AssertHelper.AssertAndLog(inventoryPage.IsAt(driver), "Entered inventory Page sucesfully");

            foreach (var item in items)
            {
                inventoryPage.EnterItemPage(driver, item);
                Thread.Sleep(50);
                AssertHelper.AssertAndLog(itemPage.IsAt(driver), "Entered item Page sucesfully");
                itemPage.AddItemToCart(driver);
                Thread.Sleep(50);
                AssertHelper.AssertIntEqualAndLog(expItemsInCart, itemPage.GetCartItemCount(driver), "Items count match!");
                AssertHelper.AssertAndLog(itemPage.IsItemInCart(driver), "Item confirmed in cart!");
                Thread.Sleep(50);
                itemPage.RemoveItemFromCart(driver);
                Thread.Sleep(50);
                AssertHelper.AssertIntEqualAndLog(expItemsOutCart, itemPage.GetCartItemCount(driver), "Items removed from cart properly!");
                Thread.Sleep(50);
                itemPage.BackToMainPage(driver);
                Thread.Sleep(150);
            }

            logoutComponent.Logout(driver);
        }

        [Test]
        public void AddItemToCartGoToCartRemoveItAndThenCheckOnPage()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            var itemPage = new ItemPage();
            var cartPage = new CartPage();
            var logoutComponent = new LogoutComponent();
            string[] items = { "backpack", "bike light", "t-shirt", "jacket", "onsie", "red t-shirt" };
            int expItemsInCart = 1;
            int expItemsOutCart = 0;

            AssertHelper.AssertAndLog(loginPage.IsAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            Thread.Sleep(2000); //Added for manual click
            AssertHelper.AssertAndLog(inventoryPage.IsAt(driver), "Entered inventory Page sucesfully");



            foreach (var item in items)
            {
                inventoryPage.EnterItemPage(driver, item);
                Thread.Sleep(50);
                AssertHelper.AssertAndLog(itemPage.IsAt(driver), "Entered item Page sucesfully");
                itemPage.AddItemToCart(driver);
                Thread.Sleep(50);
                AssertHelper.AssertIntEqualAndLog(expItemsInCart, itemPage.GetCartItemCount(driver), "Items count match!");
                AssertHelper.AssertAndLog(itemPage.IsItemInCart(driver), "Item confirmed in cart!");
                Thread.Sleep(50);

                itemPage.EnterCart(driver);
                Thread.Sleep(50);
                cartPage.RemoveItemFromCart(driver, item);
                AssertHelper.AssertAndLog(cartPage.IsCartEmpty(driver), "Cart is epmty!");
                cartPage.BackToShopping(driver);
                Thread.Sleep(50);
                inventoryPage.EnterItemPage(driver, item);
                Thread.Sleep(50);
                AssertHelper.AssertAndLog(itemPage.IsItemNotInCart(driver), "Item indeed removed from cart");
                TestContext.WriteLine($"Operation confirmed on {item}");
                itemPage.BackToMainPage(driver);
                Thread.Sleep(50);

            }

            logoutComponent.Logout(driver);
        }
    }
}
