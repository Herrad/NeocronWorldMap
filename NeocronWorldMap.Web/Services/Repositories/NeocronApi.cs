using System;
using System.Linq;
using NeocronWorldMap.Web.NeocronPublicInterface;
using NeocronWorldMap.Web.NeocronSessionManagement;

namespace NeocronWorldMap.Web.Services.Repositories
{
    public class NeocronApi : IConnectToTheNeocronApi
    {
        private readonly SessionManagementSoapClient _sessionManagementSoapClient;
        private readonly PublicInterfaceSoapClient _publicInterfaceSoapClient;

        public NeocronApi()
        {
            _sessionManagementSoapClient = new SessionManagementSoapClient();
            _publicInterfaceSoapClient = new PublicInterfaceSoapClient();
        }

        public ExtendedOutpost GetOutpostForSector(int sectorCode)
        {
            var outpostListResult = GetOutposts();

            var outpostWithSectorCode = outpostListResult.Outposts.First(outpost => outpost.Id == sectorCode);

            return outpostWithSectorCode;
        }

        private OutpostListResult GetOutposts()
        {
            var token = GetSessionToken();

            var outpostListResult = _publicInterfaceSoapClient.GetOutposts(token, "Titan");
            return outpostListResult;
        }

        private Guid GetSessionToken()
        {
            return _sessionManagementSoapClient.Login("pilotz", "bnooey12").Token;
        }

        public OutpostListResult GetAllOutposts()
        {
            return GetOutposts();
        }
    }
}