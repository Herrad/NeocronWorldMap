﻿using System;

namespace NeocronWorldMap.Web.Domain
{
    public class Clan : IOwnOutposts
    {
        protected bool Equals(Clan other)
        {
            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public Clan(string name, Faction faction, TimeSpan timeOwnedFor, int securityCode)
        {
            SecurityCode = securityCode;
            TimeOwnedFor = timeOwnedFor;
            Name = name;
            Faction = faction;
        }

        public string Name { get; private set; }
        public Faction Faction { get; private set; }
        public TimeSpan TimeOwnedFor { get; private set; }
        public int SecurityCode { get; private set; }

        public static IOwnOutposts NotApplicable()
        {
            const string notApplicable = "Not applicable";
            return new Clan(notApplicable, new Faction(notApplicable), new TimeSpan(), 0);
        }

        public override bool Equals(object obj)
        {
            var other = (Clan) obj;
            
            return Equals(other);
        }
    }
}