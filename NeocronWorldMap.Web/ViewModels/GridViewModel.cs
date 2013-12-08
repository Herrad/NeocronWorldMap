using System.Collections.Generic;

namespace NeocronWorldMap.Web.ViewModels
{
    public class GridViewModel
    {
        public GridViewModel(IEnumerable<string> xAxis, IEnumerable<char> yAxis)
        {
            XAxis = xAxis;
            YAxis = yAxis;
        }

        public IEnumerable<char> YAxis { get; private set; }

        public IEnumerable<string> XAxis { get; private set; }
    }
}