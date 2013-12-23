using System.Linq;
using NeocronWorldMap.Web.NeocronPublicInterface;

namespace NeocronWorldMap.Web.Services.Repositories
{
    public class InMemoryApi : IConnectToTheNeocronApi
    {
        private readonly NeocronApi _api;
        private OutpostListResult _outposts;

        public InMemoryApi(NeocronApi api)
        {
            _api = api;
            SetupList();
        }

        private void SetupList()
        {
            _outposts = _api.GetAllOutposts();
        }

        public ExtendedOutpost GetOutpostForSector(int sectorCode)
        {
            return _outposts.Outposts.First(x => x.Id == sectorCode);
        }

        public OutpostListResult GetOutposts()
        {
            return _outposts;
        }
    }
}