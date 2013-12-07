namespace NeocronWorldMap.Web.Domain
{
    public class NeocronZone : IHaveZoneDetails
    {
        public NeocronZone(int xCoordinate, char yCoordinate)
        {
            YCoordinate = yCoordinate;
            XCoordinate = xCoordinate;
        }

        public int XCoordinate { get; private set; }
        public char YCoordinate { get; private set; }
    }
}