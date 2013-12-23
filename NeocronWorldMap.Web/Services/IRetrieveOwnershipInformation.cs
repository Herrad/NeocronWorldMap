using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface IRetrieveOwnershipInformation
    {
        IOwnOutposts GetCurrentOwners(Coordinates coordinates);
    }
}