using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class ZoneDetailsViewModelBuilder : IBuildZoneDetailsViewModels
    {
        public ZoneDetailsViewModel Build(IHaveZoneDetails zone)
        {
            return new ZoneDetailsViewModel(zone.XCoordinate, zone.YCoordinate);
        }
    }
}