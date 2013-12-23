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

        public OutpostListResult GetOutposts()
        {
            OutpostListResult outpostListResult;
            using (_sessionManagementSoapClient)
            {
                var sessionDetails = _sessionManagementSoapClient.Login("pilotz", "bnooey12");
                var token = sessionDetails.Token;

                outpostListResult = _publicInterfaceSoapClient.GetOutposts(token, "Titan");
            }
            return outpostListResult;
        }

        public OutpostListResult GetAllOutposts()
        {
            return GetOutposts();
        }
    }
}