using NeocronWorldMap.Web.NeocronPublicInterface;

namespace NeocronWorldMap.Web.Services.Repositories
{
    public interface IConnectToTheNeocronApi
    {
        NeocronPublicInterface.ExtendedOutpost GetOutpostForSector(int sectorCode);
        OutpostListResult GetOutposts();
    }
}