namespace NeocronWorldMap.Web.Domain
{
    public class OutpostOwnershipProfile : IHaveInformationAboutOutpostOwnership
    {
        public OutpostOwnershipProfile(Faction factionName)
        {
            Faction = factionName;
        }

        public Faction Faction { get; private set; }
    }
}