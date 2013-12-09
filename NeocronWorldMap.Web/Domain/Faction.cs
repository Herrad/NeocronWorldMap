namespace NeocronWorldMap.Web.Domain
{
    public class Faction
    {
        public Faction(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}