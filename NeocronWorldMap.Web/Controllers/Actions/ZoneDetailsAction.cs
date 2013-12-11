using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.ViewModelBuilders;

namespace NeocronWorldMap.Web.Controllers.Actions
{
    public class ZoneDetailsAction : IActionZoneDetailsRequests
    {
        private readonly IRetrieveOutpostInformation _outpostService;
        private readonly IBuildZoneDetailsViewModels _zoneDetailsViewModelBuilder;

        public ZoneDetailsAction(IRetrieveOutpostInformation outpostService, IBuildZoneDetailsViewModels zoneDetailsViewModelBuilder)
        {
            _outpostService = outpostService;
            _zoneDetailsViewModelBuilder = zoneDetailsViewModelBuilder;
        }

        public void Execute(string xCoordinate, char yCoordinate, IRenderViews viewRenderer)
        {
            var coordinates = new Coordinates(xCoordinate, yCoordinate);

            var outpostData = _outpostService.GetOutpostDataAt(coordinates);

            var zoneDetailsViewModel = _zoneDetailsViewModelBuilder.Build(outpostData);

            viewRenderer.SetViewModel(zoneDetailsViewModel);
        }
    }
}