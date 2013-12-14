using System;

namespace NeocronWorldMap.Web.Domain
{
    public interface ICanOwnOutposts
    {
        string Name { get; }
        Faction Faction { get; }
        TimeSpan TimeOwnedFor { get; }
    }
}