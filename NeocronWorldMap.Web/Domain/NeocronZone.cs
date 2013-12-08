namespace NeocronWorldMap.Web.Domain
{
    public class NeocronZone : IHaveZoneDetails
    {
        public NeocronZone(Coordinates coordinates, IHaveOutpostData outpost)
        {
            Coordinates = coordinates;
            Outpost = outpost;
        }

        public Coordinates Coordinates { get; private set; }
        public IHaveOutpostData Outpost { get; private set; }
    }
}