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

            var zoneService = new ZoneService(MockRepository.GenerateStub<IRetrieveOutpostInformation>());

            var coordinates = new Coordinates(xCoordinate, yCoordinate);

            var zone = zoneService.GetZoneDetailsAt(coordinates);

            Assert.That(zone, Is.Not.Null);
            Assert.That(zone.Coordinates, Is.EqualTo(coordinates));
        }

        [Test]
        public void Sets_outpost_information_from_provided_outpost()
        {
            var expectedOutpost = new Outpost("foo", null);
            
            const string xCoordinate = "05";
            const char yCoordinate = 'f';

            var outpostRepository = MockRepository.GenerateStub<IRetrieveOutpostInformation>();
            outpostRepository
                .Stub(x => x.GetOutpostDataAt(new Coordinates(xCoordinate, yCoordinate)))
                .Return(expectedOutpost);

            var zoneService = new ZoneService(outpostRepository);

            var zone = zoneService.GetZoneDetailsAt(new Coordinates(xCoordinate, yCoordinate));

            Assert.That(zone.Outpost, Is.EqualTo(expectedOutpost));
        }
    }
}