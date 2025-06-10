using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;
using WebTestingNUnit.Pages;

namespace WebTestingNUnit.Tests.TC_002
{
    public class TC_002_Chrome : BaseTest
    {
        [Test]
        public void Should_Log_Page_Chrome()
        {
            var loginPage = new LoginPage();
            Assert.That(loginPage.isAt(driver));
            loginPage.Login(driver, "standard_user", "secret_sauce");
            Assert.That(driver.Url.Contains("inventory"));

        }
    }

}
