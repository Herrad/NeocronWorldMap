namespace NeocronWorldMap.Web.ViewModels
{
    public class ZoneDetailsViewModel
    {
        public ZoneDetailsViewModel(int xCoordinate, char yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; private set; }
        public char YCoordinate { get; private set; }
    }
}