namespace NeocronWorldMap.Web.Domain
{
    public class SectorCodeMapper : IConvertCoordinatesToSectorCodes
    {
        public int Map(Coordinates coordinates)
        {
            const int baseNumber = 2000;
            var parsedXCoordinate = int.Parse(coordinates.XCoordinate);

            var parsedYCoordinate = ParseYCoordinate(coordinates.YCoordinate);

            return baseNumber + parsedYCoordinate+ parsedXCoordinate;
        }

        private static int ParseYCoordinate(char yCoordinate)
        {
            var parsedCoordinate = 0;
            for (var c = 'a'; c < yCoordinate; c++)
            {
                parsedCoordinate += 20;
            }

            return parsedCoordinate;
        }
    }
}