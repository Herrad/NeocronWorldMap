namespace NeocronWorldMap.Web.Domain
{
    public class Faction
    {
        protected bool Equals(Faction other)
        {
            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public Faction(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override bool Equals(object obj)
        {
            var other = (Faction) obj;
            
            return Equals(other);
        }
    }
}