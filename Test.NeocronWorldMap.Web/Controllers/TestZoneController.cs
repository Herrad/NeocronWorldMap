using System.Web.Mvc;
using NUnit.Framework;
using NeocronWorldMap.Web.Controllers;
using NeocronWorldMap.Web.Controllers.Actions;
using NeocronWorldMap.Web.ViewModels;
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

            var viewResult = controller.Details("99", 'x');

            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult.ViewName, Is.Empty);
        }

        [Test]
        public void Details_gives_set_ViewModel_to_View()
        {
            var viewModel = new ZoneDetailsViewModel(null, null);

            var detailsAction = MockRepository.GenerateStub<IActionZoneDetailsRequests>();

            var controller = new ZoneController(detailsAction);

            controller.SetViewModel(viewModel);

            var viewResult = controller.Details("99", 'x');

            Assert.That(viewResult.Model, Is.Not.Null);
            Assert.That(viewResult.Model, Is.EqualTo(viewModel));
        }

        [Test]
        public void Details_defers_to_DetailsAction_class()
        {
            var detailsAction = MockRepository.GenerateStub<IActionZoneDetailsRequests>();

            var zoneController = new ZoneController(detailsAction);

            zoneController.Details("99", 'x');

            detailsAction
                .AssertWasCalled(x => x.Execute("99", 'x', zoneController));
        }

        [Test]
        public void PartialDetails_returns_View_with_name_set_to_PartialDetails()
        {
            var detailsAction = MockRepository.GenerateStub<IActionZoneDetailsRequests>();

            var controller = new ZoneController(detailsAction);

            var viewResult = controller.PartialDetails("99", 'x');

            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult.ViewName, Is.EqualTo("_PartialDetails"));
        }

        [Test]
        public void PartialDetails_gives_set_ViewModel_to_View()
        {
            var viewModel = new ZoneDetailsViewModel(null, null);

            var detailsAction = MockRepository.GenerateStub<IActionZoneDetailsRequests>();

            var controller = new ZoneController(detailsAction);

            controller.SetViewModel(viewModel);

            var viewResult = controller.PartialDetails("99", 'x');

            Assert.That(viewResult.Model, Is.Not.Null);
            Assert.That(viewResult.Model, Is.EqualTo(viewModel));
        }

        [Test]
        public void PartialDetails_defers_to_DetailsAction_class()
        {
            var detailsAction = MockRepository.GenerateStub<IActionZoneDetailsRequests>();

            var zoneController = new ZoneController(detailsAction);

            zoneController.PartialDetails("99", 'x');

            detailsAction
                .AssertWasCalled(x => x.Execute("99", 'x', zoneController));
        }

        [Test]
        public void OutpostsOwnedByFaction_returns_JsonResult()
        {
            var zoneController = new ZoneController(null);

            var result = zoneController.OutpostsOwnedByFaction();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<JsonResult>());
        }

        [Test]
        public void Json_from_returns_jsonified_object_set_OutpostsOwnedByFaction()
        {
            var objectToJsonify = new {name = "foo"};

            var zoneController = new ZoneController(null);

            zoneController.SetJsonObject(objectToJsonify);

            var result = zoneController.OutpostsOwnedByFaction();

            Assert.That(result.Data, Is.EqualTo(objectToJsonify));
        }
    }
}