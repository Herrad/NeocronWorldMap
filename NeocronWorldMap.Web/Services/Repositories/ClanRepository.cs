using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services.Repositories
{
    public class ClanRepository : IRetrieveOwnershipInformation
    {
        private readonly IConnectToTheNeocronApi _neocronApi;
        private readonly IConvertCoordinatesToSectorCodes _sectorCodeMapper;

        public ClanRepository(IConnectToTheNeocronApi neocronApi, IConvertCoordinatesToSectorCodes sectorCodeMapper)
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