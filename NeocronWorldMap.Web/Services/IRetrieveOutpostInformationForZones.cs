using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public interface IRetrieveOutpostInformationForZones
    {
        IHaveOutpostData GetOutpostDataAt(Coordinates coordinates);
    }
}