using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class ZoneDetailsViewModelBuilder : IBuildZoneDetailsViewModels
    {
        private readonly IBuildOutpostViewModels _outpostViewModelBuilder;

        public ZoneDetailsViewModelBuilder(IBuildOutpostViewModels outpostViewModelBuilder)
        {
            _outpostViewModelBuilder = outpostViewModelBuilder;
        }

        public ZoneDetailsViewModel Build(IHaveZoneDetails zone)
        {
            var outpostViewModel = _outpostViewModelBuilder.Build(zone.Outpost);

            return new ZoneDetailsViewModel(zone.Coordinates.XCoordinate, zone.Coordinates.YCoordinate, outpostViewModel);
        }
    }
}