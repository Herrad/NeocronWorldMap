namespace NeocronWorldMap.Web.Controllers.Actions
{
    public interface IActionZoneDetailsRequests
    {
        void Execute(char xCoordinate, int yCoordinate, ZoneController zoneController);
    }

    public class DetailsAction : IActionZoneDetailsRequests
    {
        public void Execute(char xCoordinate, int yCoordinate, ZoneController zoneController)
        {
            throw new System.NotImplementedException();
        }
    }
}