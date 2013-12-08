using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public class ZoneService : ICreateZonesFromCoordinates
    {
        public ZoneService(IRetrieveOutpostInformation outpostRepository)
        {
            
        }

        public IHaveZoneDetails GetZoneDetailsAt(string xCoordinate, char yCoordinate)
        {
            return new NeocronZone(xCoordinate, yCoordinate, new Outpost("foo"));
        }
    }
}