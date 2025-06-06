using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;
using WebTestingNUnit.Components;
using WebTestingNUnit.Pages;

namespace WebTestingNUnit.Tests
{
    public class TC_003_TestLoginLogoutPrecedure : BaseTest
    {
        [Test]
        public void LogInLogOutUser()
        {
            var loginPage = new LoginPage();
            var logoutComponent = new LogoutComponent();
            Assert.That(loginPage.isAt(driver), "Login page was not loaded correctly.");
            loginPage.Login(driver, "standard_user", "secret_sauce");
            Assert.That(driver.Url.Contains("inventory"), "User was not logged in.");
            logoutComponent.Logout(driver);
            Assert.That(logoutComponent.IsLoggedOut(driver), "User was not logged out successfully.");

        }

        [Test]
        public void LogBlockedUser()
        { 
            var loginPage = new LoginPage();
            Assert.That(loginPage.isAt(driver), "Login page was not loaded correctly.");
            if(loginPage.LoginExpectingFailure(driver, "locked_out_user", "secret_sauce") == "Epic sadface: Sorry, this user has been locked out.")
            {
                Assert.Pass("User was not able to log in");
            }
        }
    }
}
