namespace NeocronWorldMap.Web.Services.Repositories
{
    public interface IConnectToTheNeocronApi
    {
        NeocronPublicInterface.ExtendedOutpost GetOutpostForSector(int sectorCode);
    }
}