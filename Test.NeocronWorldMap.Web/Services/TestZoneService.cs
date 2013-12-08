using NUnit.Framework;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services;
using Rhino.Mocks;

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

            var zoneService = new ZoneService(null);

            var zone = zoneService.GetZoneDetailsAt(xCoordinate, yCoordinate);

            Assert.That(zone, Is.Not.Null);
            Assert.That(zone.XCoordinate, Is.EqualTo(xCoordinate));
            Assert.That(zone.YCoordinate, Is.EqualTo(yCoordinate));
        }

        [Test]
        public void Sets_outpost_information_from_provided_outpost()
        {
            const string xCoordinate = "05";
            const char yCoordinate = 'f';

            var outpostRepository = MockRepository.GenerateStub<IRetrieveOutpostInformation>();
            outpostRepository
                .Stub(x => x.GetOutpostDataAt(new Coordinates(xCoordinate, yCoordinate)))
                .Return(new Outpost("foo"));

            var zoneService = new ZoneService(outpostRepository);

            var zone = zoneService.GetZoneDetailsAt(xCoordinate, yCoordinate);

            Assert.That(zone.Outpost, Is.Not.Null);
        }
    }
}