namespace NeocronWorldMap.Web.Controllers.Actions
{
    public interface IActionZoneDetailsRequests
    {
        void Execute(char xCoordinate, int yCoordinate, IRenderViews viewRenderer);
    }
}