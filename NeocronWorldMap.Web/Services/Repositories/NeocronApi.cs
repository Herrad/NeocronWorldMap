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
            _sessionManagementSoapClient = new NeocronSessionManagement.SessionManagementSoapClient();
            _publicInterfaceSoapClient = new NeocronPublicInterface.PublicInterfaceSoapClient();
        }

        public ExtendedOutpost GetOutpostForSector(int sectorCode)
        {
            var outpostListResult = GetOutposts();

            var outpostWithSectorCode = outpostListResult.Outposts.First(outpost => outpost.Id == sectorCode);

            CloseSession();

            return outpostWithSectorCode;
        }

        private void CloseSession()
        {
            _sessionManagementSoapClient.Close();
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
    }
}