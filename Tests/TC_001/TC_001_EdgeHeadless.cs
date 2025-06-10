using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;

namespace WebTestingNUnit.Tests.TC_001
{
    public class TC_001_EdgeHeadless : BaseTestEdgeHeadless
    {
        [Test]
        public void Should_Open_Page_Edge_Headless()
        {
            Assert.That(driver.Title, Does.Contain("Swag Labs"));
        }
    }
}
