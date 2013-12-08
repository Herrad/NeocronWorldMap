using System.Collections.Generic;

namespace NeocronWorldMap.Web.ViewModels
{
    public class GridViewModel
    {
        public GridViewModel(IEnumerable<char> yAxis)
        {
            YAxis = yAxis;
        }

        public IEnumerable<char> YAxis { get; private set; }
    }
}