using System.Globalization;

namespace NeocronWorldMap.Web.Domain
{
    public class NeocronZone : IHaveZoneDetails
    {
        protected bool Equals(NeocronZone other)
        {
            return Equals(Coordinates, other.Coordinates);
        }

        public override int GetHashCode()
        {
            return (Coordinates != null ? Coordinates.GetHashCode() : 0);
        }

        public NeocronZone(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public Coordinates Coordinates { get; private set; }

        public string Name()
        {
            var formattedYCoordinate = Coordinates.YCoordinate.ToString(CultureInfo.InvariantCulture).ToUpper();
            return formattedYCoordinate + Coordinates.XCoordinate;
        }

        public override bool Equals(object obj)
        {
            var other = (NeocronZone) obj;
            return Equals(other);
        }
    }
}