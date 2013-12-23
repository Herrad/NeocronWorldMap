namespace NeocronWorldMap.Web.Domain
{
    public interface IBuildCoordinatesFromSectorIds
    {
        Coordinates BuildCoordinates(int sectorId);
    }
}