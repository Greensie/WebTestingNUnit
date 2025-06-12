using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;
using WebTestingNUnit.Components;
using WebTestingNUnit.Pages;
using WebTestingNUnit.Utils;

namespace WebTestingNUnit.Tests.TC_005
{
    public class TC_005_WholeBuyProcedure_Edge_Headless : BaseTestEdgeHeadless
    {
        [Test]
        public void TC_005_WholeBuyProcedureEdge()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            var cartPage = new CartPage();
            var checkoutPage1 = new CheckoutPage1();
            var checkoutPage2 = new CheckoutPage2();
            var logoutComponent = new LogoutComponent();
            string exp1 = "Item total: $55.97";
            string exp2 = "Tax: $4.48";
            string exp3 = "Total: $60.45";
            string expShipping = "Free Pony Express Delivery!";
            string expPayment = "SauceCard #31337";

            string[] itemsShort = { "backpack", "bike light", "t-shirt" };

            AssertHelper.AssertAndLog(loginPage.isAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            AssertHelper.AssertAndLog(inventoryPage.isAt(driver), "Entered inventory Page sucesfully");

            foreach (var item in itemsShort)
            {
                inventoryPage.AddItemToCart(driver, item);
                Thread.Sleep(50);
            }
            int itemsInCartAfterAdding = inventoryPage.GetCartItemCount(driver);
            Assert.That(itemsInCartAfterAdding, Is.EqualTo(3), "All items added to the cart!");

            Thread.Sleep(150);

            inventoryPage.EnterCart(driver);
            Thread.Sleep(150);
            AssertHelper.AssertAndLog(cartPage.isAt(driver), "Enteret cart Page sucesfully");

            cartPage.proceedToPayment(driver);
            Thread.Sleep(150);

            AssertHelper.AssertAndLog(checkoutPage1.isAt(driver), "Entered checkout proceedure");
            checkoutPage1.enterData(driver, "John", "Snow", "99-999");
            checkoutPage1.proceedFurther(driver);
            Thread.Sleep(150);

            AssertHelper.AssertAndLog(checkoutPage2.isAt(driver), "Entered final checkout page");
            string act1 = checkoutPage2.GetPrices(driver, 0);
            string act2 = checkoutPage2.GetPrices(driver, 1);
            string act3 = checkoutPage2.GetPrices(driver, 2);
            AssertHelper.AssertEqualAndLog(exp1, act1, "Item total prices match!");
            AssertHelper.AssertEqualAndLog(exp2, act2, "Tax match!");
            AssertHelper.AssertEqualAndLog(exp3, act3, "Total prices match!");

            string actShipping = checkoutPage2.GetShippingInformation(driver);
            string actPayment = checkoutPage2.GetPaymentInformation(driver);
            AssertHelper.AssertEqualAndLog(expShipping, actShipping, "Shipping info match!");
            AssertHelper.AssertEqualAndLog(expPayment, actPayment, "Payment info match!");

            checkoutPage2.FinishShopping(driver);
            Thread.Sleep(150);
            AssertHelper.AssertAndLog(driver.Url.Contains("checkout-complete"), "User finished shopping!");

            logoutComponent.Logout(driver);
            Thread.Sleep(50);
            AssertHelper.AssertAndLog(logoutComponent.IsLoggedOut(driver), "User logged out!");
        }
    }
}