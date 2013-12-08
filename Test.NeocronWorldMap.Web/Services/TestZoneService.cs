using NUnit.Framework;
using NeocronWorldMap.Web.Services;

namespace Test.NeocronWorldMap.Web.Services
{
    [TestFixture]
    public class TestZoneService
    {
        [Test]
        public void Should_return_some_basic_information_about_a_zone()
        {
            const string xCoordinate = "05";
            const char yCoordinate = 'f';

            var zoneService = new ZoneService();

            var zone = zoneService.GetZoneDetailsAt(xCoordinate, yCoordinate);

            Assert.That(zone, Is.Not.Null);
            Assert.That(zone.XCoordinate, Is.EqualTo(xCoordinate));
            Assert.That(zone.YCoordinate, Is.EqualTo(yCoordinate));
        }
    }
}