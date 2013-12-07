namespace NeocronWorldMap.Web.Controllers.Actions
{
    public interface IActionZoneDetailsRequests
    {
        void Execute(int xCoordinate, char yCoordinate, IRenderViews viewRenderer);
    }
}