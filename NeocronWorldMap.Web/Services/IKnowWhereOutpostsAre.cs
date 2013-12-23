using System.Collections;
using System.Collections.Generic;
using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface IKnowWhereOutpostsAre
    {
        string GetOutpostNameAt(Coordinates coordinates);
        bool OutpostExistsAt(Coordinates coordinates);
        IEnumerable<Coordinates> GetCoordinatesOfAllOutposts();
    }
}