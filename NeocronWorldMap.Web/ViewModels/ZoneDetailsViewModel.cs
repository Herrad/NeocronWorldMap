namespace NeocronWorldMap.Web.ViewModels
{
    public class ZoneDetailsViewModel
    {
        public ZoneDetailsViewModel(string xCoordinate, char yCoordinate, OutpostViewModel outpostViewModel)
        {
            OutpostViewModel = outpostViewModel;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public string XCoordinate { get; private set; }
        public char YCoordinate { get; private set; }

        public OutpostViewModel OutpostViewModel { get; private set; }
    }
}