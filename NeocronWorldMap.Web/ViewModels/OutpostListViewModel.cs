using System.Collections.Generic;
using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.ViewModels
{
    public class OutpostListViewModel
    {
        public string Name { get; private set; }
        public Coordinates Coordinates { get; private set; }
        public Faction Faction { get; private set; }
        public string SecurityCode { get; private set; }
        public IEnumerable<Faction> FactionsAbleToGenRep { get; private set; }

        public OutpostListViewModel(string name, Coordinates coordinates, Faction faction, string securityCode, IEnumerable<Faction> factionsAbleToGenRep)
        {
            SecurityCode = securityCode;
            FactionsAbleToGenRep = factionsAbleToGenRep;
            Name = name;
            Coordinates = coordinates;
            Faction = faction;
        }
    }
}