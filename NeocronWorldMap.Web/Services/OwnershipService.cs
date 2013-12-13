using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services.Repositories;

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
            return new Clan(name);
        }
    }
}