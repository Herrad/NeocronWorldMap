namespace NeocronWorldMap.Web.Domain
{
    public class Clan : IHaveOwnershipInformation
    {
        protected bool Equals(Clan other)
        {
            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public Clan(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public static IHaveOwnershipInformation NotApplicable()
        {
            return new Clan("Not applicable");
        }

        public override bool Equals(object obj)
        {
            var other = (Clan) obj;
            
            return Equals(other);
        }
    }
}