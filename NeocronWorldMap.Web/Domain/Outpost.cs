namespace NeocronWorldMap.Web.Domain
{
    public class Outpost : IHaveOutpostData
    {
        public Outpost(
            string name, 
            NeocronZone zone, 
            ICanOwnOutposts currentOwners)
        {
            Name = name;
            Zone = zone;
            CurrentOwners = currentOwners;
        }

        public string Name { get; private set; }
        public NeocronZone Zone { get; private set; }
        public ICanOwnOutposts CurrentOwners { get; private set; }
    }
}