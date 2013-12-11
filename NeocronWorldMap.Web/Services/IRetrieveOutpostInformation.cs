using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface IRetrieveOutpostInformation
    {
        IHaveOutpostData GetOutpostDataAt(Coordinates coordinates);
    }
}