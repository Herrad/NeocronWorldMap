using System.Collections.Generic;
using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public class FactionRelationsService : IKnowFactionRelations
    {
        public IEnumerable<Faction> GetFactionsAbleToGenRepToOutpost(Faction faction, int securityCode)
        {
            return null;
        }
    }
}