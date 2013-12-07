using NUnit.Framework;
using NeocronWorldMap.Web.Controllers;

namespace Test.NeocronWorldMap.Web.Controllers
{
    [TestFixture]
    public class TestHomeController
    {
        [Test]
        public void Index_returns_view_with_no_name_set()
        {
            var controller = new HomeController();

            var viewResult = controller.Index();

            Assert.That(viewResult.ViewName, Is.Empty);
        }
    }
}
