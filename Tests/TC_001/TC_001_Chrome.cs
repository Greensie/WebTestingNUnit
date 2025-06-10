using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Attributes;
using NUnit.Framework;
using WebTestingNUnit.Base;
using WebTestingNUnit.Pages;

namespace WebTestingNUnit.Tests.TC_001
{
    public class TC_001_Chrome : BaseTest
    {
        [Test]
        public void Should_Open_Page_Chrome()
        {
            Assert.That(driver.Title, Does.Contain("Swag Labs"));
        }
    }

}
