using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;
using WebTestingNUnit.Components;
using WebTestingNUnit.Pages;

namespace WebTestingNUnit.Tests.TC_005
{
    public class TC_005_WholeBuyProcedure_Chrome_Headless : BaseTestHeadless
    {
        [Test]
        public void TC_005_WholeBuyProcedure()
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

            Assert.That(loginPage.IsAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            Assert.That(inventoryPage.IsAt(driver),"Entered inventory Page sucesfully");

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
            Assert.That(cartPage.IsAt(driver),"Enteret cart Page sucesfully");

            cartPage.ProceedToPayment(driver);
            Thread.Sleep(150);

            Assert.That(checkoutPage1.IsAt(driver), "Entered checkout proceedure");
            checkoutPage1.EnterData(driver, "John", "Snow", "99-999");
            checkoutPage1.ProceedFurther(driver);
            Thread.Sleep(150);

            Assert.That(checkoutPage2.IsAt(driver), "Entered final checkout page");
            string act1 = checkoutPage2.GetPrices(driver, 0);
            string act2 = checkoutPage2.GetPrices(driver, 1);
            string act3 = checkoutPage2.GetPrices(driver, 2);
            Assert.That(act1 == exp1, "Item total prices match!");
            Assert.That(act2 == exp2, "Tax match!");
            Assert.That(act3 == exp3, "Total prices match!");

            string actShipping = checkoutPage2.GetShippingInformation(driver);
            string actPayment = checkoutPage2.GetPaymentInformation(driver);
            Assert.That(actShipping == expShipping, "Shipping info match!");
            Assert.That(actPayment == expPayment, "Payment info match!");

            checkoutPage2.FinishShopping(driver);
            Thread.Sleep(150);
            Assert.That(driver.Url.Contains("checkout-complete"), "User finished shopping!");

            logoutComponent.Logout(driver);
            Thread.Sleep(50);
            Assert.That(logoutComponent.IsLoggedOut(driver), "User logged out!");
        }
    }
}
