using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface IRetrieveOutpostInformation
    {
        Outpost GetOutpostDataAt(Coordinates coordinates);
    }
}