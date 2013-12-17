namespace NeocronWorldMap.Web.Controllers.Actions
{
    public class OutpostOwnedByFactionAction
    {
        public void Execute(string xCoordinate, char yCoordinate, IRenderJsonViews jsonViewRenderer)
        {
            jsonViewRenderer.SetJsonObject(new { xCoordinates = new[] { "01", "02", "03" }, yCoordinates = new[] { 'a', 'b', 'c' } });
        }
    }
}