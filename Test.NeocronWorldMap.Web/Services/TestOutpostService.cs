using NUnit.Framework;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.Services.Repositories;
using Rhino.Mocks;

namespace Test.NeocronWorldMap.Web.Services
{
    [TestFixture]
    public class TestOutpostService
    {

        [Test]
        public void Returns_Empty_outpost_when_no_name_is_found()
        {
            var outpostService = new OutpostService(new OutpostLocations(), MockRepository.GenerateStub<IRetrieveOwnershipInformation>());

            var coordinates = new Coordinates("99", 'x');

            var outpost = outpostService.GetOutpostDataAt(coordinates);

            Assert.That(outpost, Is.Not.Null);
            Assert.That(outpost.Name, Is.EqualTo("No outpost found"));
        }

        [TestCase("99", 'x')]
        [TestCase("05", 'f')]
        public void Builds_a_NeocronZone_from_coordinates(string xCoordinate, char yCoordinate)
        {
            var outpostService = new OutpostService(new OutpostLocations(), MockRepository.GenerateStub<IRetrieveOwnershipInformation>());

            var coordinates = new Coordinates(xCoordinate, yCoordinate);

            var outpost = outpostService.GetOutpostDataAt(coordinates);

            Assert.That(outpost.Zone, Is.Not.Null);
            Assert.That(outpost.Zone, Is.EqualTo(new NeocronZone(coordinates)));
        }

        [Test]
        public void Sets_CurrentOwner_on_outpost_when_an_outpost_exists_at_coordinates()
        {
            var coordinates = new Coordinates("99", 'x');
            var expectedClan = new Clan("foo name");

            var ownershipService = MockRepository.GenerateStub<IRetrieveOwnershipInformation>();
            ownershipService
                .Stub(x => x.GetCurrentOwners(coordinates))
                .Return(expectedClan);

            var outpostLocations = MockRepository.GenerateStub<IKnowWhereOutpostsAre>();
            outpostLocations
                .Stub(x => x.OutpostExistsAt(coordinates))
                .Return(true);

            var outpostService = new OutpostService(outpostLocations, ownershipService);

            var outpostData = outpostService.GetOutpostDataAt(coordinates);

            Assert.That(outpostData.CurrentOwners, Is.EqualTo(expectedClan));
        }

        [Test]
        public void Sets_empty_CurrentOwner_on_outpost_when_an_outpost_does_not_exist_at_coordinates()
        {
            var coordinates = new Coordinates("99", 'x');
            var expectedClan = Clan.NotApplicable();

            var ownershipService = MockRepository.GenerateStub<IRetrieveOwnershipInformation>();
            ownershipService
                .Stub(x => x.GetCurrentOwners(coordinates))
                .Return(expectedClan);

            var outpostLocations = MockRepository.GenerateStub<IKnowWhereOutpostsAre>();
            outpostLocations
                .Stub(x => x.OutpostExistsAt(coordinates))
                .Return(false);

            var outpostService = new OutpostService(outpostLocations, ownershipService);

            var outpostData = outpostService.GetOutpostDataAt(coordinates);

            Assert.That(outpostData.CurrentOwners, Is.EqualTo(expectedClan));
        }
    }
}