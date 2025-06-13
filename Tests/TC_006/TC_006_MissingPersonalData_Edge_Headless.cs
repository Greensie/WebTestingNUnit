using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;
using WebTestingNUnit.Pages;
using WebTestingNUnit.Utils;

namespace WebTestingNUnit.Tests.TC_006
{
    public class TC_006_MissingPersonalData_Edge_Headless : BaseTestEdgeHeadless
    {
        [Test]
        public void TC_006_MissingPersonalData_FirstName()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            var cartPage = new CartPage();
            var checkoutPage1 = new CheckoutPage1();

            string[] itemsShort = { "backpack", "bike light", "t-shirt" };

            AssertHelper.AssertAndLog(loginPage.IsAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            AssertHelper.AssertAndLog(inventoryPage.IsAt(driver), "Entered inventory Page sucesfully");

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
            AssertHelper.AssertAndLog(cartPage.IsAt(driver), "Enteret cart Page sucesfully");

            cartPage.ProceedToPayment(driver);
            Thread.Sleep(150);

            AssertHelper.AssertAndLog(checkoutPage1.IsAt(driver), "Entered checkout proceedure");
            checkoutPage1.EnterData(driver, lastname: "Snow", zipcode: "99-999");
            checkoutPage1.ProceedFurther(driver);
            AssertHelper.AssertAndLog(checkoutPage1.IsFirstNameErrorPresent(driver), "Error is present, first name was not provided!");
        }

        [Test]
        public void TC_006_MissingPersonalData_LastName()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            var cartPage = new CartPage();
            var checkoutPage1 = new CheckoutPage1();

            string[] itemsShort = { "backpack", "bike light", "t-shirt" };

            AssertHelper.AssertAndLog(loginPage.IsAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            AssertHelper.AssertAndLog(inventoryPage.IsAt(driver), "Entered inventory Page sucesfully");

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
            AssertHelper.AssertAndLog(cartPage.IsAt(driver), "Enteret cart Page sucesfully");

            cartPage.ProceedToPayment(driver);
            Thread.Sleep(150);

            AssertHelper.AssertAndLog(checkoutPage1.IsAt(driver), "Entered checkout proceedure");
            checkoutPage1.EnterData(driver, firstname: "John", zipcode: "99-999");
            checkoutPage1.ProceedFurther(driver);
            AssertHelper.AssertAndLog(checkoutPage1.IsLastNameErrorPresent(driver), "Error is present, last name was not provided!");
        }

        [Test]
        public void TC_006_MissingPersonalData_ZipCode()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            var cartPage = new CartPage();
            var checkoutPage1 = new CheckoutPage1();

            string[] itemsShort = { "backpack", "bike light", "t-shirt" };

            AssertHelper.AssertAndLog(loginPage.IsAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            AssertHelper.AssertAndLog(inventoryPage.IsAt(driver), "Entered inventory Page sucesfully");

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
            AssertHelper.AssertAndLog(cartPage.IsAt(driver), "Enteret cart Page sucesfully");

            cartPage.ProceedToPayment(driver);
            Thread.Sleep(150);

            AssertHelper.AssertAndLog(checkoutPage1.IsAt(driver), "Entered checkout proceedure");
            checkoutPage1.EnterData(driver, firstname: "John", lastname: "Snow");
            checkoutPage1.ProceedFurther(driver);
            AssertHelper.AssertAndLog(checkoutPage1.IsZipCodeErrorPresent(driver), "Error is present, zip code was not provided!");
        }
    }
}
