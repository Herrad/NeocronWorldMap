using NUnit.Framework;
using NeocronWorldMap.Web.Controllers;
using NeocronWorldMap.Web.Controllers.Actions;
using NeocronWorldMap.Web.ViewModels;
using Rhino.Mocks;

namespace Test.NeocronWorldMap.Web.Controllers
{
    [TestFixture]
    public class TestHomeController
    {
        [Test]
        public void Index_returns_view_with_no_name_set()
        {
            var controller = new HomeController(MockRepository.GenerateStub<IActionIndexRequests>());

            var viewResult = controller.Index();

            Assert.That(viewResult.ViewName, Is.Empty);
        }

        [Test]
        public void Index_returns_view_with_ViewModel_set()
        {
            var gridViewModel = new GridViewModel(null);
            var controller = new HomeController(MockRepository.GenerateStub<IActionIndexRequests>());

            controller.SetViewModel(gridViewModel);

            var viewResult = controller.Index();

            Assert.That(viewResult.Model, Is.Not.Null);
            Assert.That(viewResult.Model, Is.EqualTo(gridViewModel));
        }

        [Test]
        public void Index_defers_to_IndexAction()
        {
            var indexAction = MockRepository.GenerateMock<IActionIndexRequests>();

            var controller = new HomeController(indexAction);

            controller.Index();

            indexAction.AssertWasCalled(x => x.Execute(controller),
                                        c => c.Repeat.Once());
        }
    }
}
