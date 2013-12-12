using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services.Repositories;

namespace NeocronWorldMap.Web.Services
{
    public class OutpostService : IRetrieveOutpostInformation
    {
        private readonly IHaveLocationsOfOutpostNames _outpostLocations;
        private readonly IRetrieveOwnershipInformation _ownershipService;

        public OutpostService(IHaveLocationsOfOutpostNames outpostLocations, IRetrieveOwnershipInformation ownershipService)
        {
            _outpostLocations = outpostLocations;
            _ownershipService = ownershipService;
        }

        public IHaveOutpostData GetOutpostDataAt(Coordinates coordinates)
        {
            var neocronZone = new NeocronZone(coordinates);

            var name = _outpostLocations.GetOutpostNameAt(coordinates);

            var currentOwners = _ownershipService.GetCurrentOwners(coordinates);

            return new Outpost(name, neocronZone, currentOwners);
        }
    }
}

