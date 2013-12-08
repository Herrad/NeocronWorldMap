using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class GridViewModelBuilder : IBuildGridViewModels
    {
        public GridViewModel Build()
        {
            var yAxis = new[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k'};

            return new GridViewModel(yAxis);
        }
    }
}