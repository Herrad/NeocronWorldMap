namespace NeocronWorldMap.Web.Domain
{
    public class Coordinates
    {
        protected bool Equals(Coordinates other)
        {
            return string.Equals(XCoordinate, other.XCoordinate) && YCoordinate == other.YCoordinate;
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
    }
}