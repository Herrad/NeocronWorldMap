namespace NeocronWorldMap.Web.ViewModels
{
    public class ZoneDetailsViewModel
    {
        public ZoneDetailsViewModel(string xCoordinate, char yCoordinate, string zoneName, OutpostViewModel outpostViewModel)
        {
            ZoneName = zoneName;
            OutpostViewModel = outpostViewModel;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public string XCoordinate { get; private set; }
        public char YCoordinate { get; private set; }

        public OutpostViewModel OutpostViewModel { get; private set; }

        public string ZoneName { get; private set; }
    }
}