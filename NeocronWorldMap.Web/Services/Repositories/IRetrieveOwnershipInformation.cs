using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services.Repositories
{
    public interface IRetrieveOwnershipInformation
    {
        IHaveOwnershipInformation GetCurrentOwners(Coordinates coordinates);
    }
}