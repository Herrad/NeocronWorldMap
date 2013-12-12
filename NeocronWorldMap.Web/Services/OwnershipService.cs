using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services.Repositories;

namespace NeocronWorldMap.Web.Services
{
    public class OwnershipService : IRetrieveOwnershipInformation
    {
        private readonly IConnectToTheNeocronApi _neocronApi;
        private readonly IConvertCoordinatesToSectorCodes _sectorCodeMapper;

        public OwnershipService(IConnectToTheNeocronApi neocronApi, IConvertCoordinatesToSectorCodes sectorCodeMapper)
        {
            _neocronApi = neocronApi;
            _sectorCodeMapper = sectorCodeMapper;
        }

        public IHaveOwnershipInformation GetCurrentOwners(Coordinates coordinates)
        {
            var sectorCode = _sectorCodeMapper.Map(coordinates);
            var outpostForSector = _neocronApi.GetOutpostForSector(sectorCode);

            var name = outpostForSector.Clan.Name;
            return new Clan(name);
        }
    }
}