﻿namespace NeocronWorldMap.Web.Domain
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

        public Clan(string name, Faction faction)
        {
            Name = name;
            Faction = faction;
        }

        public string Name { get; private set; }
        public Faction Faction { get; private set; }

        public static IHaveOwnershipInformation NotApplicable()
        {
            const string notApplicable = "Not applicable";
            return new Clan(notApplicable, new Faction(notApplicable));
        }

        public override bool Equals(object obj)
        {
            var other = (Clan) obj;
            
            return Equals(other);
        }
    }
}