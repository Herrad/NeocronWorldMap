using System;

namespace NeocronWorldMap.Web.Domain
{
    public class Coordinates
    {
        protected bool Equals(Coordinates other)
        {
            return String.Equals(XCoordinate, other.XCoordinate) && YCoordinate == other.YCoordinate;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((XCoordinate != null ? XCoordinate.GetHashCode() : 0)*397) ^ YCoordinate.GetHashCode();
            }
        }

        public Coordinates(string xCoordinate, char yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public string XCoordinate { get; private set; }
        public char YCoordinate { get; private set; }

        public override bool Equals(object obj)
        {
            var other = (Coordinates) obj;
            return Equals(other);
        }

        public int ToSectorCode()
        {
            const int baseNumber = 2000;
            var parsedXCoordinate = Int32.Parse(XCoordinate);

            var parsedYCoordinate = ParseYCoordinate();

            return baseNumber + parsedYCoordinate+ parsedXCoordinate;
        }

        private int ParseYCoordinate()
        {
            var parsedYCoordinate = 0;
            for (var c = 'a'; c < YCoordinate; c++)
            {
                parsedYCoordinate += 20;
            }
            return parsedYCoordinate;
        }
    }
}