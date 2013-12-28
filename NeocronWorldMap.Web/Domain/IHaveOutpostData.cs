using System.Collections.Generic;

namespace NeocronWorldMap.Web.Domain
{
    public interface IHaveOutpostData
    {
        string Name { get; }
        NeocronZone Zone { get; }
        IOwnOutposts CurrentOwners { get; }
        IEnumerable<Faction> FactionsAbleToGenRep { get; }
    }
}