using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestingNUnit.Base;

namespace WebTestingNUnit.Tests.TC_001
{
    public class TC_001_Edge : BaseTestEdge
    {
        [Test]
        public void Should_Open_Page_Edge()
        {
            Assert.That(driver.Title, Does.Contain("Swag Labs"));
        }
    }
}
