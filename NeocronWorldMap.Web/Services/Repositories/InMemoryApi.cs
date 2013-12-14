using System.Linq;
using NeocronWorldMap.Web.NeocronPublicInterface;

namespace NeocronWorldMap.Web.Services.Repositories
{
    public class InMemoryApi : IConnectToTheNeocronApi
    {
        private readonly NeocronApi _api;
        private ExtendedOutpost[] _outposts;

        public InMemoryApi(NeocronApi api)
        {
            _api = api;
            SetupList();
        }

        private void SetupList()
        {
            _outposts = _api.GetAllOutposts().Outposts;
        }

        public ExtendedOutpost GetOutpostForSector(int sectorCode)
        {
            return _outposts.First(x => x.Id == sectorCode);
        }
    }
}