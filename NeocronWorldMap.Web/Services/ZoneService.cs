using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public class ZoneService : ICreateZonesFromCoordinates
    {
        private readonly IRetrieveOutpostInformation _outpostService;

        public ZoneService(IRetrieveOutpostInformation outpostService)
        {
            _outpostService = outpostService;
        }

        public IHaveZoneDetails GetZoneDetailsAt(Coordinates coordinates)
        {
            var outpostData = _outpostService.GetOutpostDataAt(coordinates);
            return new NeocronZone(coordinates, outpostData);
        }
    }
}