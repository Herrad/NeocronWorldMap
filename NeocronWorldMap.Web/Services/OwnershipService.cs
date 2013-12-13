using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.NeocronPublicInterface;
using NeocronWorldMap.Web.Services.Repositories;
using Clan = NeocronWorldMap.Web.Domain.Clan;

namespace NeocronWorldMap.Web.Services
{
    public class OwnershipService : IRetrieveOwnershipInformation
    {
        private readonly IConnectToTheNeocronApi _neocronApi;

        public OwnershipService(IConnectToTheNeocronApi neocronApi)
        {
            _neocronApi = neocronApi;
        }

        public IHaveOwnershipInformation GetCurrentOwners(Coordinates coordinates)
        {
            var sectorCode = coordinates.ToSectorCode();
            var outpostForSector = _neocronApi.GetOutpostForSector(sectorCode);

            var name = outpostForSector.Clan.Name;
            var faction = BuildFaction(outpostForSector);

            return new Clan(name, faction);
        }

        private static Faction BuildFaction(ExtendedOutpost outpostForSector)
        {
            return new Faction(outpostForSector.Faction);
        }
    }
}