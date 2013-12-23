using System;

namespace NeocronWorldMap.Web.Domain
{
    public interface IOwnOutposts
    {
        string Name { get; }
        Faction Faction { get; }
        TimeSpan TimeOwnedFor { get; }
    }
}