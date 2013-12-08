namespace NeocronWorldMap.Web.Domain
{
    public class Outpost : IHaveOutpostData
    {
        public Outpost(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}