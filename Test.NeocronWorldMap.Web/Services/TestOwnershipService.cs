using NUnit.Framework;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.NeocronPublicInterface;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.Services.Repositories;
using Rhino.Mocks;
using Clan = NeocronWorldMap.Web.NeocronPublicInterface.Clan;

namespace Test.NeocronWorldMap.Web.Services
{
    [TestFixture]
    public class TestOwnershipService
    {
        [Test]
        public void GetCurrentOwners_returns_current_owners_of_outpost()
        {
            var coordinates = new Coordinates("05", 'f');

            var outpost = MockRepository.GenerateStub<IHaveOutpostData>();
            outpost
                .Stub(x => x.Zone)
                .Return(new NeocronZone(coordinates));

            var owningClan = new Clan {Name = "foo clan"};
            var extendedOutpost = new ExtendedOutpost {Clan = owningClan};
            var neocronApi = MockRepository.GenerateStub<IConnectToTheNeocronApi>();
            neocronApi
                .Stub(x => x.GetOutpostForSector(coordinates.ToSectorCode()))
                .Return(extendedOutpost);

            var clanRepository = new OwnershipService(neocronApi);

            var currentOwners = clanRepository.GetCurrentOwners(outpost.Zone.Coordinates);

            Assert.That(currentOwners, Is.Not.Null);
            Assert.That(currentOwners.Name, Is.EqualTo("foo clan"));
        }
    }
}