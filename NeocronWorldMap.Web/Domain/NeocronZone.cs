namespace NeocronWorldMap.Web.Domain
{
    public class NeocronZone : IHaveZoneDetails
    {
        public NeocronZone(string xCoordinate, char yCoordinate)
        {
            YCoordinate = yCoordinate;
            XCoordinate = xCoordinate;
        }

        public string XCoordinate { get; private set; }
        public char YCoordinate { get; private set; }
    }
}