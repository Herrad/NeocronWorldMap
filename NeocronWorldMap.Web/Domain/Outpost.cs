namespace NeocronWorldMap.Web.Domain
{
    public class Outpost : IHaveOutpostData
    {
        public Outpost(
            string name, 
            NeocronZone zone, 
            IOwnOutposts currentOwners)
        {
            Name = name;
            Zone = zone;
            CurrentOwners = currentOwners;
        }

        public string Name { get; private set; }
        public NeocronZone Zone { get; private set; }
        public IOwnOutposts CurrentOwners { get; private set; }
    }
}