using System.Collections.Generic;
using NeocronWorldMap.Web.Domain;
using Clan = NeocronWorldMap.Web.Domain.Clan;
using Outpost = NeocronWorldMap.Web.Domain.Outpost;

namespace NeocronWorldMap.Web.Services
{
    public class OutpostService : IRetrieveOutpostInformationForZones, IRetrieveOutpostsOwnedByClans, IRetrieveAllOutposts
    {
        private readonly IKnowWhereOutpostsAre _outpostLocations;
        private readonly IRetrieveOwnershipInformation _ownershipService;
        private readonly IKnowFactionRelations _factionRelationService;

        public OutpostService(IKnowWhereOutpostsAre outpostLocations, IRetrieveOwnershipInformation ownershipService, IKnowFactionRelations factionRelationService)
        {
            _outpostLocations = outpostLocations;
            _ownershipService = ownershipService;
            _factionRelationService = factionRelationService;
        }

        public IHaveOutpostData GetOutpostDataAt(Coordinates coordinates)
        {
            var neocronZone = new NeocronZone(coordinates);

            var name = _outpostLocations.GetOutpostNameAt(coordinates);

            var currentOwners = Clan.NotApplicable();

            IEnumerable<Faction> factionsAbleToGenRepToOutpost = new List<Faction>(){new Faction("Anyone")};
            if (_outpostLocations.OutpostExistsAt(coordinates))
            {
                currentOwners = _ownershipService.GetCurrentOwners(coordinates);
                factionsAbleToGenRepToOutpost = _factionRelationService.GetFactionsAbleToGenRepToOutpost(currentOwners.Faction,currentOwners.SecurityCode);
            }

            return new Outpost(name, neocronZone, currentOwners, factionsAbleToGenRepToOutpost);
        }

        public IEnumerable<IHaveOutpostData> GetOutpostsOwnedBy(IOwnOutposts clan)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IRetrieveAllOutposts
    {
    }
}

