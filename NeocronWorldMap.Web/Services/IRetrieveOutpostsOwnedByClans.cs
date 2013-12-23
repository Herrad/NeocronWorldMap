using System.Collections.Generic;
using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface IRetrieveOutpostsOwnedByClans
    {
        IEnumerable<IHaveOutpostData> GetOutpostsOwnedBy(IOwnOutposts clan);
    }
}