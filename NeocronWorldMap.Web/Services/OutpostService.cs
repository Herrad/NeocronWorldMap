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

        public OutpostService(IKnowWhereOutpostsAre outpostLocations, IRetrieveOwnershipInformation ownershipService)
        {
            _outpostLocations = outpostLocations;
            _ownershipService = ownershipService;
        }

        public IHaveOutpostData GetOutpostDataAt(Coordinates coordinates)
        {
            var neocronZone = new NeocronZone(coordinates);

            var name = _outpostLocations.GetOutpostNameAt(coordinates);

            var currentOwners = Clan.NotApplicable();
            
            if (_outpostLocations.OutpostExistsAt(coordinates))
            {
                currentOwners = _ownershipService.GetCurrentOwners(coordinates);
            }

            return new Outpost(name, neocronZone, currentOwners);
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

