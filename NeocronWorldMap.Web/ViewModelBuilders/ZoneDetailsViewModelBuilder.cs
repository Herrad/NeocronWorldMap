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

        public ZoneDetailsViewModel Build(IHaveOutpostData outpost)
        {
            var zone = outpost.Zone;

            var outpostViewModel = _outpostViewModelBuilder.Build(outpost);

            return new ZoneDetailsViewModel(GetZoneName(zone), outpostViewModel);
        }

        private static string GetZoneName(IHaveZoneDetails zone)
        {
            return char.ToUpper(zone.Coordinates.YCoordinate) + zone.Coordinates.XCoordinate;
        }
    }
}