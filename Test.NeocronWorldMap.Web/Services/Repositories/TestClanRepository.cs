using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.NeocronPublicInterface;
using NeocronWorldMap.Web.Services.Repositories;
using NUnit.Framework;
using Rhino.Mocks;
using Clan = NeocronWorldMap.Web.NeocronPublicInterface.Clan;

namespace Test.NeocronWorldMap.Web.Services.Repositories
{
    [TestFixture]
    public class TestClanRepository
    {
        [Test]
        public void GetCurrentOwners_returns_current_owners_of_outpost()
        {
            const int sectorCode = 1234;
            var coordinates = new Coordinates("05", 'f');

            var outpost = MockRepository.GenerateStub<IHaveOutpostData>();
            outpost
                .Stub(x => x.Zone)
                .Return(new NeocronZone(coordinates));

            var sectorCodeMapper = MockRepository.GenerateStub<IConvertCoordinatesToSectorCodes>();
            sectorCodeMapper
                .Stub(x => x.Map(coordinates))
                .Return(sectorCode);

            var owningClan = new Clan {Name = "foo clan"};
            var extendedOutpost = new ExtendedOutpost {Clan = owningClan};
            var neocronApi = MockRepository.GenerateStub<IConnectToTheNeocronApi>();
            neocronApi
                .Stub(x => x.GetOutpostForSector(sectorCode))
                .Return(extendedOutpost);

            var clanRepository = new ClanRepository(neocronApi, sectorCodeMapper);

            var currentOwners = clanRepository.GetCurrentOwners(outpost);

            Assert.That(currentOwners, Is.Not.Null);
            Assert.That(currentOwners.Name, Is.EqualTo("foo clan"));
        }
    }
}