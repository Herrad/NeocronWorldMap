namespace NeocronWorldMap.Web.Domain
{
    public class Outpost : IHaveOutpostData
    {
        public Outpost(string name, NeocronZone zone)
        {
            Name = name;
            Zone = zone;
        }

        public string Name { get; private set; }
        public NeocronZone Zone { get; private set; }
    }
}