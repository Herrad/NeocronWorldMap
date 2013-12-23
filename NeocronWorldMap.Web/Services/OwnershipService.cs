using System;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services.Repositories;
using Clan = NeocronWorldMap.Web.Domain.Clan;
using Outpost = NeocronWorldMap.Web.NeocronPublicInterface.Outpost;

namespace NeocronWorldMap.Web.Services
{
    public class OwnershipService : IRetrieveOwnershipInformation
    {
        private readonly IConnectToTheNeocronApi _neocronApi;
        private readonly IBuildFactions _factionFactory;

        public OwnershipService(IConnectToTheNeocronApi neocronApi, IBuildFactions factionFactory)
        {
            _neocronApi = neocronApi;
            _factionFactory = factionFactory;
        }

        public IOwnOutposts GetCurrentOwners(Coordinates coordinates)
        {
            var sectorCode = coordinates.ToSectorCode();
            var outpostForSector = _neocronApi.GetOutpostForSector(sectorCode);
            
            var name = outpostForSector.Clan.Name;
            var faction = _factionFactory.Build(outpostForSector);
            var timeOwnedFor = GetTimeOwnedFor(outpostForSector);

            return new Clan(name, faction, timeOwnedFor);
        }

        private static TimeSpan GetTimeOwnedFor(Outpost outpostForSector)
        {
            return DateTime.Now - outpostForSector.ConquerTime;
        }
    }
}