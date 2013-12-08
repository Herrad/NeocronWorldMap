namespace NeocronWorldMap.Web.Domain
{
    public interface IHaveZoneDetails
    {
        Coordinates Coordinates { get; }
        IHaveOutpostData Outpost { get; }
    }
}