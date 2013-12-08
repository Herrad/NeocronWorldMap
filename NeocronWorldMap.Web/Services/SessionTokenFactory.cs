using NeocronWorldMap.Web.NeocronSessionManagement;

namespace NeocronWorldMap.Web.Services
{
    public class SessionTokenFactory : ISessionTokenFactory
    {
        private readonly SessionManagementSoapClient _sessionManagementSoapClient;

        public SessionTokenFactory()
        {
            _sessionManagementSoapClient = new SessionManagementSoapClient();
        }

        public SessionDetails Login(string userName, string password)
        {
            var sessionDetails = _sessionManagementSoapClient.Login(userName, password);
            return sessionDetails;
        }
    }
}