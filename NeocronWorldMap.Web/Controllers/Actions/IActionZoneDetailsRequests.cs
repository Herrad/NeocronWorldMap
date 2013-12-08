namespace NeocronWorldMap.Web.Controllers.Actions
{
    public interface IActionZoneDetailsRequests
    {
        void Execute(string xCoordinate, char yCoordinate, IRenderViews viewRenderer);
    }
}