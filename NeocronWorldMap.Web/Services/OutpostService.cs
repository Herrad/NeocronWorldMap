using System;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.NeocronPublicInterface;
using NeocronWorldMap.Web.Services.Repositories;
using Clan = NeocronWorldMap.Web.Domain.Clan;
using Outpost = NeocronWorldMap.Web.Domain.Outpost;

namespace NeocronWorldMap.Web.Services
{
    public class OutpostService : IRetrieveOutpostInformation
    {
        private readonly IKnowWhereOutpostsAre _outpostLocations;
        private readonly IRetrieveOwnershipInformation _ownershipService;
        private readonly IConnectToTheNeocronApi _neocronApi;

        public OutpostService(IKnowWhereOutpostsAre outpostLocations, IRetrieveOwnershipInformation ownershipService, IConnectToTheNeocronApi neocronApi)
        {
            _outpostLocations = outpostLocations;
            _ownershipService = ownershipService;
            _neocronApi = neocronApi;
        }

        public IHaveOutpostData GetOutpostDataAt(Coordinates coordinates)
        {
            var neocronZone = new NeocronZone(coordinates);

            var name = _outpostLocations.GetOutpostNameAt(coordinates);

            var currentOwners = Clan.NotApplicable();
            var outpostForSector = new ExtendedOutpost {ConquerTime = DateTime.Now};
            
            if (_outpostLocations.OutpostExistsAt(coordinates))
            {
                outpostForSector = _neocronApi.GetOutpostForSector(coordinates.ToSectorCode());
                currentOwners = _ownershipService.GetCurrentOwners(coordinates);
            }

            return new Outpost(name, neocronZone, currentOwners);
        }

        private static TimeSpan TimeSinceConquered(NeocronPublicInterface.Outpost outpostForSector)
        {
            return DateTime.Now - outpostForSector.ConquerTime;
        }
    }
}

