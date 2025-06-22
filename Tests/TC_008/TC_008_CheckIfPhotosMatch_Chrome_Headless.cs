using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;
using WebTestingNUnit.Components;
using WebTestingNUnit.Pages;
using WebTestingNUnit.Utils;

namespace WebTestingNUnit.Tests.TC_008
{
    public class TC_008_CheckIfPhotosMatch_Chrome_Headless : BaseTestHeadless
    {
        string[] expectedPhotosSRC = { "https://www.saucedemo.com/static/media/sauce-backpack-1200x1500.0a0b85a3.jpg",
            "https://www.saucedemo.com/static/media/bolt-shirt-1200x1500.c2599ac5.jpg",
            "https://www.saucedemo.com/static/media/bolt-shirt-1200x1500.c2599ac5.jpg",
            "https://www.saucedemo.com/static/media/red-onesie-1200x1500.2ec615b2.jpg",
            "https://www.saucedemo.com/static/media/red-onesie-1200x1500.2ec615b2.jpg",
            "https://www.saucedemo.com/static/media/red-tatt-1200x1500.30dadef4.jpg"};

        [Test]
        public void CheckPhotosStandardUser()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            var logoutComponent = new LogoutComponent();
            string[] items = { "backpack", "bike light", "t-shirt", "jacket", "onsie", "red t-shirt" };
            List<string> actualSrc = new List<string>();


            AssertHelper.AssertAndLog(loginPage.IsAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsStandardUser(driver);
            AssertHelper.AssertAndLog(inventoryPage.IsAt(driver), "Entered inventory Page sucesfully");

            foreach (var item in items)
            {
                string actual = inventoryPage.GetItemPhotoSrc(driver, item);
                actualSrc.Add(actual);
                Thread.Sleep(50);
            }

            foreach (string expectedSrc in expectedPhotosSRC)
            {
                AssertHelper.AssertAndLog(actualSrc.Contains(expectedSrc), $"Expected image src found: {expectedSrc}");
            }

            logoutComponent.Logout(driver);
        }

        [Test]
        public void CheckPhotosProblemUser()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            var logoutComponent = new LogoutComponent();
            string[] items = { "backpack", "bike light", "t-shirt", "jacket", "onsie", "red t-shirt" };
            List<string> actualSrc = new List<string>();


            AssertHelper.AssertAndLog(loginPage.IsAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsProblemUser(driver);
            AssertHelper.AssertAndLog(inventoryPage.IsAt(driver), "Entered inventory Page sucesfully");

            foreach (var item in items)
            {
                string actual = inventoryPage.GetItemPhotoSrc(driver, item);
                actualSrc.Add(actual);
                Thread.Sleep(50);
            }

            foreach (string expectedSrc in expectedPhotosSRC)
            {
                AssertHelper.AssertAndLog(!actualSrc.Contains(expectedSrc), $"Expected image src found and not in base: {expectedSrc}");
            }
        }

        [Test]
        public void CheckPhotosVisualUser()
        {
            var loginPage = new LoginPage();
            var inventoryPage = new InventoryPage();
            var logoutComponent = new LogoutComponent();
            string[] items = { "backpack", "bike light", "t-shirt", "jacket", "onsie", "red t-shirt" };
            List<string> actualSrc = new List<string>();


            AssertHelper.AssertAndLog(loginPage.IsAt(driver), "Login page was not loaded correctly.");
            loginPage.LoginAsVisualUser(driver);
            AssertHelper.AssertAndLog(inventoryPage.IsAt(driver), "Entered inventory Page sucesfully");

            foreach (var item in items)
            {
                string actual = inventoryPage.GetItemPhotoSrc(driver, item);
                actualSrc.Add(actual);
                Thread.Sleep(50);
            }

            foreach (string expectedSrc in expectedPhotosSRC)
            {
                if (actualSrc.Contains(expectedSrc))
                {
                    AssertHelper.AssertAndLog(actualSrc.Contains(expectedSrc), $"Expected image src found in base: {expectedSrc}");
                }
                else
                {
                    AssertHelper.AssertAndLog(!actualSrc.Contains(expectedSrc), $"Not expected image: {actualSrc}");
                }
            }
        }
    }
}
