using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class OutpostViewModelBuilder : IBuildOutpostViewModels
    {
        public OutpostViewModel Build(IHaveOutpostData outpost)
        {
            return new OutpostViewModel(outpost.Name);
        }
    }
}