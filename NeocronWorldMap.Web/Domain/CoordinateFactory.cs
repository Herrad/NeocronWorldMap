namespace NeocronWorldMap.Web.Domain
{
    public class CoordinateFactory : IBuildCoordinatesFromSectorIds
    {
        public Coordinates BuildCoordinates(int sectorId)
        {
            var baseId = sectorId - 2000;
            var yCoordinate = (char) (baseId/20 + 97);

            var xCoordinate = BuildXCoordinate(baseId);

            var coordinates = new Coordinates(xCoordinate, yCoordinate);
            return coordinates;
        }

        private static string BuildXCoordinate(int baseId)
        {
            var baseXCoordinate = (baseId % 20);
            var xCoordinate = "";
            if (baseXCoordinate < 10)
            {
                xCoordinate = "0";
            }
            xCoordinate = xCoordinate + baseXCoordinate;
            return xCoordinate;
        }
    }
}