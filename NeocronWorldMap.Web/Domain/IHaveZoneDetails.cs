namespace NeocronWorldMap.Web.Domain
{
    public interface IHaveZoneDetails
    {
        string XCoordinate { get; }
        char YCoordinate { get; }
        IHaveOutpostData Outpost { get; }
    }
}