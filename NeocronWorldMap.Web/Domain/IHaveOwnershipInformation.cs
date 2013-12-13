namespace NeocronWorldMap.Web.Domain
{
    public interface IHaveOwnershipInformation
    {
        string Name { get; }
        Faction Faction { get; }
    }
}