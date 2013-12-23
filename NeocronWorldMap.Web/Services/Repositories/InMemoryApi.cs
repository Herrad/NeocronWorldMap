using System;
using System.Linq;
using NeocronWorldMap.Web.NeocronPublicInterface;

namespace NeocronWorldMap.Web.Services.Repositories
{
    public class InMemoryApi : IConnectToTheNeocronApi
    {
        private readonly NeocronApi _api;
        private OutpostListResult _outposts;
        private DateTime _lastRefreshed;

        public InMemoryApi(NeocronApi api)
        {
            _api = api;
            SetupList();
        }

        private void SetupList()
        {
            _outposts = _api.GetAllOutposts();
            _lastRefreshed = DateTime.Now;
        }

        public ExtendedOutpost GetOutpostForSector(int sectorCode)
        {
            BustCache();
            return _outposts.Outposts.First(x => x.Id == sectorCode);
        }

        public OutpostListResult GetOutposts()
        {
            BustCache();
            return _outposts;
        }

        private void BustCache()
        {
            if (_lastRefreshed < DateTime.Now.AddHours(-1))
            {
                SetupList();
            }
        }
    }
}