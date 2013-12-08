using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public interface IBuildOutpostViewModels
    {
        OutpostViewModel Build(IHaveOutpostData outpost);
    }
}