using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public class ZoneService : ICreateZonesFromCoordinates
    {
        public IHaveZoneDetails GetZoneDetailsAt(int xCoordinate, char yCoordinate)
        {
            return new NeocronZone(xCoordinate, yCoordinate);
        }
    }
}