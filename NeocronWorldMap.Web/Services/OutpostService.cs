using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public class OutpostService : IRetrieveOutpostInformation
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

            IHaveOwnershipInformation currentOwners = Clan.NotApplicable();
            if (_outpostLocations.OutpostExistsAt(coordinates))
            {
                currentOwners = _ownershipService.GetCurrentOwners(coordinates);
            }

            return new Outpost(name, neocronZone, currentOwners);
        }
    }
}

