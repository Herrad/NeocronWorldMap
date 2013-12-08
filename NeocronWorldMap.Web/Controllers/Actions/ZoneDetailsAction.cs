using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.ViewModelBuilders;

namespace NeocronWorldMap.Web.Controllers.Actions
{
    public class ZoneDetailsAction : IActionZoneDetailsRequests
    {
        private readonly ICreateZonesFromCoordinates _zoneService;
        private readonly IBuildZoneDetailsViewModels _zoneDetailsViewModelBuilder;

        public ZoneDetailsAction(ICreateZonesFromCoordinates zoneService, IBuildZoneDetailsViewModels zoneDetailsViewModelBuilder)
        {
            _zoneService = zoneService;
            _zoneDetailsViewModelBuilder = zoneDetailsViewModelBuilder;
        }

        public void Execute(string xCoordinate, char yCoordinate, IRenderViews viewRenderer)
        {
            var zoneDetails = _zoneService.GetZoneDetailsAt(xCoordinate, yCoordinate);

            var zoneDetailsViewModel = _zoneDetailsViewModelBuilder.Build(zoneDetails);

            viewRenderer.SetViewModel(zoneDetailsViewModel);
        }
    }
}