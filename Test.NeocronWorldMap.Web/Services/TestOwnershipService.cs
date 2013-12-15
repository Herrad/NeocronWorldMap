using System;
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

            var clanRepository = new OwnershipService(neocronApi, new FactionFactory());

            var currentOwners = clanRepository.GetCurrentOwners(outpost.Zone.Coordinates);

            Assert.That(currentOwners, Is.Not.Null);
            Assert.That(currentOwners.Name, Is.EqualTo("foo clan"));
        }

        [Test]
        public void GetCurrentOwners_sets_Faction_data_on_clan()
        {
            const string factionName = "Diamond Real Estate";
            var expectedFaction = new Faction(factionName);

            var coordinates = new Coordinates("05", 'f');

            var outpost = MockRepository.GenerateStub<IHaveOutpostData>();
            outpost
                .Stub(x => x.Zone)
                .Return(new NeocronZone(coordinates));

            var extendedOutpost = new ExtendedOutpost
            {
                Clan = new Clan(),
                Faction = factionName
            };

            var neocronApi = MockRepository.GenerateStub<IConnectToTheNeocronApi>();
            neocronApi
                .Stub(x => x.GetOutpostForSector(coordinates.ToSectorCode()))
                .Return(extendedOutpost);

            var clanRepository = new OwnershipService(neocronApi, new FactionFactory());

            var currentOwners = clanRepository.GetCurrentOwners(outpost.Zone.Coordinates);

            Assert.That(currentOwners.Faction, Is.Not.Null);
            Assert.That(currentOwners.Faction, Is.EqualTo(expectedFaction));
        }
        [Test]
        public void Sets_TimeOwnedFor_from_difference_between_now_and_ConquerTime()
        {
            var coordinates = new Coordinates("99", 'x');
            
            var conquerTime = DateTime.Now.AddHours(-1);
            var neocronApi = MockRepository.GenerateStub<IConnectToTheNeocronApi>();
            neocronApi
                .Stub(x => x.GetOutpostForSector(coordinates.ToSectorCode()))
                .Return(new ExtendedOutpost { Clan = new Clan(), ConquerTime = conquerTime });

            var ownershipService = new OwnershipService(neocronApi, new FactionFactory());

            var clan = ownershipService.GetCurrentOwners(coordinates);

            Assert.That(clan.TimeOwnedFor, Is.GreaterThanOrEqualTo(new TimeSpan(1, 0, 0)));
            Assert.That(clan.TimeOwnedFor, Is.LessThan(new TimeSpan(1, 0, 5)));
        }
    }
}