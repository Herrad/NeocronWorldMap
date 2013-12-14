using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface IRetrieveOwnershipInformation
    {
        ICanOwnOutposts GetCurrentOwners(Coordinates coordinates);
    }
}