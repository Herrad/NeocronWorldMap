using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public interface IBuildClanViewModels
    {
        ClanViewModel Build(IHaveInformationAboutOutpostOwnership currentOwner);
    }
}