namespace NeocronWorldMap.Web.Domain
{
    public interface IConvertCoordinatesToSectorCodes
    {
        int Map(Coordinates coordinates);
    }
}