using NeocronWorldMap.Web.Domain;
using NUnit.Framework;

namespace Test.NeocronWorldMap.Web.Domain
{
    [TestFixture]
    public class TestNeocronZone
    {
        [Test]
        public void Returns_formatted_name()
        {
            var zone = new NeocronZone(new Coordinates("09", 'z'), null);

            var actualName = zone.Name();

            Assert.That(actualName, Is.Not.Null);
            Assert.That(actualName, Is.EqualTo("Z09"));
        }

        [Test]
        public void Zones_with_different_coordinates_are_not_Equal()
        {
            var zone1 = new NeocronZone(new Coordinates("11", 'x'), null);
            var zone2 = new NeocronZone(new Coordinates("22", 'y'), null);

            Assert.That(zone1, Is.Not.EqualTo(zone2));
        }

        [Test]
        public void Zones_with_same_coordinates_are_Equal()
        {
            var coordinates = new Coordinates("11", 'x');
            var zone1 = new NeocronZone(coordinates, null);
            var zone2 = new NeocronZone(coordinates, null);

            Assert.That(zone1, Is.EqualTo(zone2));
        }
    }
}