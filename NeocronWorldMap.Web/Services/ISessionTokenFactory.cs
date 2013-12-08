using NeocronWorldMap.Web.NeocronSessionManagement;

namespace NeocronWorldMap.Web.Services
{
    public interface ISessionTokenFactory
    {
        SessionDetails Login(string userName, string password);
    }
}