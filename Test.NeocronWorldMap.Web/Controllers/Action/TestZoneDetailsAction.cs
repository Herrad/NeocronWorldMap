using NUnit.Framework;
using NeocronWorldMap.Web.Controllers;
using NeocronWorldMap.Web.Controllers.Actions;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.ViewModelBuilders;
using NeocronWorldMap.Web.ViewModels;
using Rhino.Mocks;

namespace Test.NeocronWorldMap.Web.Controllers.Action
{
    [TestFixture]
    public class TestZoneDetailsAction : IRenderViews
    {
        private ZoneDetailsViewModel _viewModelThatWasSet;

        [Test]
        public void Sets_ZoneDetailsViewModel_on_controller()
        {
            _viewModelThatWasSet = null;

            var zoneDetailsViewModel = new ZoneDetailsViewModel();

            var viewModelBuilder = MockRepository.GenerateStub<IBuildZoneDetailsViewModels>();
            viewModelBuilder
                .Stub(x => x.Build(null))
                .Return(zoneDetailsViewModel);

            var detailsAction = new ZoneDetailsAction(viewModelBuilder);

            detailsAction.Execute('x', 99, this);

            Assert.That(_viewModelThatWasSet, Is.EqualTo(zoneDetailsViewModel));
        }

        public void SetViewModel(object viewModel)
        {
            Assert.That(viewModel, Is.TypeOf<ZoneDetailsViewModel>());
            _viewModelThatWasSet = (ZoneDetailsViewModel) viewModel;
        }
    }
}