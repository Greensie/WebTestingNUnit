using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;
using WebTestingNUnit.Pages;

namespace WebTestingNUnit.Tests
{
    public class TC_002 : BaseTest
    {
        [Test]
        public void Should_Open_Page()
        {
            var loginPage = new LoginPage();
            Assert.That(loginPage.isAt(driver));
            loginPage.Login(driver, "standard_user", "secret_sauce");
            Assert.That(driver.Url.Contains("inventory"));

        }
    }
}
