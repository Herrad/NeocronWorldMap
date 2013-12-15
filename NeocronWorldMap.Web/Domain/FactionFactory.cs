using NeocronWorldMap.Web.NeocronPublicInterface;

namespace NeocronWorldMap.Web.Domain
{
    public interface IBuildFactions
    {
        Faction Build(ExtendedOutpost outpostForSector);
    }

    public class FactionFactory : IBuildFactions
    {
        public Faction Build(ExtendedOutpost outpostForSector)
        {
            return new Faction(outpostForSector.Faction);
        }
    }
}