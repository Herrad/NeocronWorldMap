namespace NeocronWorldMap.Web.Domain
{
    public interface IHaveOutpostData
    {
        string Name { get; }
        NeocronZone Zone { get; }
        IOwnOutposts CurrentOwners { get; }
    }
}