using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;
using WebTestingNUnit.Pages;

namespace WebTestingNUnit.Tests.TC_002
{
    public class TC_002_Edge : BaseTestEdge
    {
        [Test]
        public void Should_Log_Page_Edge_()
        {
            var loginPage = new LoginPage();
            Assert.That(loginPage.IsAt(driver));
            loginPage.Login(driver, "standard_user", "secret_sauce");
            Assert.That(driver.Url.Contains("inventory"));

        }
    }
}
