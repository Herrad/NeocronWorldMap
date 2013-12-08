using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class GridViewModelBuilder : IBuildGridViewModels
    {
        public GridViewModel Build()
        {
            var xAxis = new[] {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17"};
            var yAxis = new[] { 'k', 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a' };

            return new GridViewModel(xAxis, yAxis);
        }
    }
}