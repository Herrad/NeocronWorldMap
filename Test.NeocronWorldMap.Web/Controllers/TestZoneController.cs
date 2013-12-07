using NUnit.Framework;
using NeocronWorldMap.Web.Controllers;
using NeocronWorldMap.Web.Controllers.Actions;
using Rhino.Mocks;

namespace Test.NeocronWorldMap.Web.Controllers
{
    [TestFixture]
    public class TestZoneController
    {
        [Test]
        public void Details_returns_view_with_no_name_set()
        {
            var detailsAction = MockRepository.GenerateStub<IActionZoneDetailsRequests>();

            var controller = new ZoneController(detailsAction);

            var viewResult = controller.Details('x', 99);

            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult.ViewName, Is.Empty);
        }

        [Test]
        public void Details_defers_to_DetailsAction_class()
        {
            var detailsAction = MockRepository.GenerateStub<IActionZoneDetailsRequests>();

            var zoneController = new ZoneController(detailsAction);

            zoneController.Details('x', 99);

            detailsAction
                .AssertWasCalled(x => x.Execute('x', 99, zoneController));
        }
    }
}