using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services.Repositories
{
    public interface IRetrieveOwnershipInformation
    {
        IHaveOwnershipInformation GetCurrentOwners(IHaveOutpostData outpost);
    }
}