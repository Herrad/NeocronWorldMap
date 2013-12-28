using System.Collections.Generic;
using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface IKnowFactionRelations
    {
        IEnumerable<Faction> GetFactionsAbleToGenRepToOutpost(Faction faction, int securityCode);
    }
}