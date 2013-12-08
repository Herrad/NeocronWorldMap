namespace NeocronWorldMap.Web.Domain
{
    public class NeocronZone : IHaveZoneDetails
    {
        public NeocronZone(string xCoordinate, char yCoordinate, IHaveOutpostData outpost)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Outpost = outpost;
        }

        public string XCoordinate { get; private set; }
        public char YCoordinate { get; private set; }
        public IHaveOutpostData Outpost { get; private set; }
    }
}