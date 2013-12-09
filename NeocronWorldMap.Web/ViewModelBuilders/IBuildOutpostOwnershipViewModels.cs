using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public interface IBuildOutpostOwnershipViewModels
    {
        OutpostOwnershipViewModel Build(IHaveInformationAboutOutpostOwnership outpostOwnershipProfile);
    }
}