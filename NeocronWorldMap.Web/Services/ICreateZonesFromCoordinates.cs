using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface ICreateZonesFromCoordinates
    {
        IHaveZoneDetails GetZoneDetailsAt(Coordinates coordinates);
    }
}