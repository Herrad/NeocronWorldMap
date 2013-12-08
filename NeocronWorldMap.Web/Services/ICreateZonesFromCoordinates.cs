using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface ICreateZonesFromCoordinates
    {
        IHaveZoneDetails GetZoneDetailsAt(string xCoordinate, char yCoordinate);
    }
}