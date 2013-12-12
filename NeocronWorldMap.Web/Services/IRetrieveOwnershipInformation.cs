using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface IRetrieveOwnershipInformation
    {
        IHaveOwnershipInformation GetCurrentOwners(Coordinates coordinates);
    }
}