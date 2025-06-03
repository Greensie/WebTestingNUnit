using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebTestingNUnit.Base;

namespace WebTestingNUnit.Tests
{
    public class TC_001 : BaseTest
    {
        [Test]
        public void Should_Open_Page()
        {
            Assert.That(driver.Title, Does.Contain("Swag Labs"));
        }
    }
}
