using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.NeocronPublicInterface;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.Services.Repositories;
using Rhino.Mocks;
using Clan = NeocronWorldMap.Web.Domain.Clan;

namespace Test.NeocronWorldMap.Web.Services
{
    [TestFixture]
    public class TestOutpostService
    {

        [Test]
        public void Returns_Empty_outpost_when_no_name_is_found()
        {
            var coordinates = new Coordinates("99", 'x');
            
            var neocronApi = MockRepository.GenerateStub<IConnectToTheNeocronApi>();
            neocronApi
                .Stub(x => x.GetOutpostForSector(coordinates.ToSectorCode()))
                .Return(new ExtendedOutpost());

            var outpostService = new OutpostService(
                new OutpostLocations(), 
                MockRepository.GenerateStub<IRetrieveOwnershipInformation>(), 
                MockRepository.GenerateStub<IKnowFactionRelations>());


            var outpost = outpostService.GetOutpostDataAt(coordinates);

            Assert.That(outpost, Is.Not.Null);
            Assert.That(outpost.Name, Is.EqualTo("No outpost found"));
        }

        [TestCase("99", 'x')]
        [TestCase("05", 'f')]
        public void Builds_a_NeocronZone_from_coordinates(string xCoordinate, char yCoordinate)
        {
            var coordinates = new Coordinates(xCoordinate, yCoordinate);

            var neocronApi = MockRepository.GenerateStub<IConnectToTheNeocronApi>();
            neocronApi
                .Stub(x => x.GetOutpostForSector(coordinates.ToSectorCode()))
                .Return(new ExtendedOutpost());

            var ownershipService = MockRepository.GenerateStub<IRetrieveOwnershipInformation>();
            ownershipService
                .Stub(x => x.GetCurrentOwners(coordinates))
                .Return(new Clan("foo", null, new TimeSpan(), 1234));

            var outpostService = new OutpostService(
                new OutpostLocations(), 
                ownershipService, MockRepository.GenerateStub<IKnowFactionRelations>());


            var outpost = outpostService.GetOutpostDataAt(coordinates);

            Assert.That(outpost.Zone, Is.Not.Null);
            Assert.That(outpost.Zone, Is.EqualTo(new NeocronZone(coordinates)));
        }

        [Test]
        public void Sets_CurrentOwner_on_outpost_when_an_outpost_exists_at_coordinates()
        {
            var coordinates = new Coordinates("99", 'x');
            var expectedClan = new Clan("foo name", null, new TimeSpan(), 0);

            var ownershipService = MockRepository.GenerateStub<IRetrieveOwnershipInformation>();
            ownershipService
                .Stub(x => x.GetCurrentOwners(coordinates))
                .Return(expectedClan);

            var outpostLocations = MockRepository.GenerateStub<IKnowWhereOutpostsAre>();
            outpostLocations
                .Stub(x => x.OutpostExistsAt(coordinates))
                .Return(true);

            var neocronApi = MockRepository.GenerateStub<IConnectToTheNeocronApi>();
            neocronApi
                .Stub(x => x.GetOutpostForSector(coordinates.ToSectorCode()))
                .Return(new ExtendedOutpost());

            var outpostService = new OutpostService(outpostLocations, ownershipService, MockRepository.GenerateStub<IKnowFactionRelations>());

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

            var neocronApi = MockRepository.GenerateStub<IConnectToTheNeocronApi>();
            neocronApi
                .Stub(x => x.GetOutpostForSector(coordinates.ToSectorCode()))
                .Return(new ExtendedOutpost());

            var outpostService = new OutpostService(outpostLocations, ownershipService, MockRepository.GenerateStub<IKnowFactionRelations>());

            var outpostData = outpostService.GetOutpostDataAt(coordinates);

            Assert.That(outpostData.CurrentOwners, Is.EqualTo(expectedClan));
        }

        [Test]
        public void Does_not_call_NeocronApi_when_no_outpost_exists_at_coordinates()
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

            var neocronApi = MockRepository.GenerateMock<IConnectToTheNeocronApi>();

            var outpostService = new OutpostService(outpostLocations, ownershipService, MockRepository.GenerateStub<IKnowFactionRelations>());

            outpostService.GetOutpostDataAt(coordinates);

            neocronApi
                .AssertWasNotCalled(x => x.GetOutpostForSector(coordinates.ToSectorCode()));
        }

        [Test]
        public void Sets_Factions_able_to_GR_to_outpost_from_current_faction_and_security_code()
        {
            const int securityCode = 1234;
            var faction = new Faction("faction");

            var coordinates = new Coordinates("99", 'x');

            var ownershipService = MockRepository.GenerateStub<IRetrieveOwnershipInformation>();
            ownershipService
                .Stub(x => x.GetCurrentOwners(coordinates))
                .Return(new Clan("foo", faction, new TimeSpan(), securityCode));

            var outpostLocations = MockRepository.GenerateStub<IKnowWhereOutpostsAre>();
            outpostLocations
                .Stub(x => x.OutpostExistsAt(coordinates))
                .Return(true);

            var factionRelationService = MockRepository.GenerateStub<IKnowFactionRelations>();
            var factionsAbleToGenRepToOutpost = new List<Faction>
                              {
                                  new Faction("Diamond Real Estate"),
                                  new Faction("N.E.X.T"),
                                  new Faction("Black Dragon")
                              };
            factionRelationService
                .Stub(x => x.GetFactionsAbleToGenRepToOutpost(faction, securityCode))
                .Return(factionsAbleToGenRepToOutpost);

            var outpostService = new OutpostService(outpostLocations, ownershipService, factionRelationService);

            var outpost = outpostService.GetOutpostDataAt(coordinates);

            Assert.That(outpost.FactionsAbleToGenRep, Is.Not.Null);
            Assert.That(outpost.FactionsAbleToGenRep, Is.Not.Empty);
            Assert.That(outpost.FactionsAbleToGenRep.ToList()[0], Is.EqualTo(new Faction("Diamond Real Estate")));
            Assert.That(outpost.FactionsAbleToGenRep.ToList()[1], Is.EqualTo(new Faction("N.E.X.T")));
            Assert.That(outpost.FactionsAbleToGenRep.ToList()[2], Is.EqualTo(new Faction("Black Dragon")));
        }
    }
}