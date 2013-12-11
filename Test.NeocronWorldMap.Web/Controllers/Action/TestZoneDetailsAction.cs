using NUnit.Framework;
using NeocronWorldMap.Web.Controllers;
using NeocronWorldMap.Web.Controllers.Actions;
using NeocronWorldMap.Web.Domain;
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

            var zoneDetailsViewModel = new ZoneDetailsViewModel("99", 'x', null, null);

            var viewModelBuilder = MockRepository.GenerateStub<IBuildZoneDetailsViewModels>();
            viewModelBuilder
                .Stub(x => x.Build(null))
                .Return(zoneDetailsViewModel);

            var outpostService = MockRepository.GenerateStub<IRetrieveOutpostInformation>();
            
            var detailsAction = new ZoneDetailsAction(outpostService, viewModelBuilder);

            detailsAction.Execute("99", 'x', this);

            Assert.That(_viewModelThatWasSet, Is.EqualTo(zoneDetailsViewModel));
        }

        [Test]
        public void Gives_Outpost_from_service_to_ViewModelBuilder()
        {
            var outpostData = MockRepository.GenerateStub<IHaveOutpostData>();

            var service = MockRepository.GenerateStub<IRetrieveOutpostInformation>();
            service
                .Stub(x => x.GetOutpostDataAt(new Coordinates("99", 'x')))
                .Return(outpostData);

            var viewModelBuilder = MockRepository.GenerateMock<IBuildZoneDetailsViewModels>();

            var detailsAction = new ZoneDetailsAction(service, viewModelBuilder);

            detailsAction.Execute("99", 'x', this);

            viewModelBuilder.AssertWasCalled(x => x.Build(outpostData), c => c.Repeat.Once());
        }

        public void SetViewModel(object viewModel)
        {
            _viewModelThatWasSet = (ZoneDetailsViewModel) viewModel;
        }
    }
}