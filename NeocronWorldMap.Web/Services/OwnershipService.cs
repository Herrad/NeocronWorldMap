using System;
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

        public ICanOwnOutposts GetCurrentOwners(Coordinates coordinates)
        {
            var sectorCode = coordinates.ToSectorCode();
            var outpostForSector = _neocronApi.GetOutpostForSector(sectorCode);
            
            var name = outpostForSector.Clan.Name;
            var faction = BuildFaction(outpostForSector);
            var timeOwnedFor = GetTimeOwnedFor(outpostForSector);

            return new Clan(name, faction, timeOwnedFor);
        }

        private static TimeSpan GetTimeOwnedFor(ExtendedOutpost outpostForSector)
        {
            return DateTime.Now - outpostForSector.ConquerTime;
        }

        private static Faction BuildFaction(ExtendedOutpost outpostForSector)
        {
            return new Faction(outpostForSector.Faction);
        }
    }
}