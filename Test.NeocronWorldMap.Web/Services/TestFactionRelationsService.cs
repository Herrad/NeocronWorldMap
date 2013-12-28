using System.Linq;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services;
using NUnit.Framework;

namespace Test.NeocronWorldMap.Web.Services
{
    [TestFixture]
    public class TestFactionRelationsService
    {
        [Test]
        public void When_code_is_zero_returns_List_with_one_faction_called_anyone()
        {
            var factionRelationsService = new FactionRelationsService();

            var result = factionRelationsService.GetFactionsAbleToGenRepToOutpost(new Faction("asdasd"), 0);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.ToList()[0], Is.EqualTo(new Faction("Anyone")));
        }

        [Test]
        public void When_code_is_10_then_result_is_the_faction_passed_in()
        {
            var owningFaction = new Faction("BioTech");
            var factionRelationsService = new FactionRelationsService();

            var result = factionRelationsService.GetFactionsAbleToGenRepToOutpost(owningFaction, 10);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.ToList()[0], Is.EqualTo(owningFaction), "expected: " + owningFaction.Name + "\n\tgot: " +result.ToList()[0].Name);
        }

        [Test]
        public void When_code_is_15_then_result_is_Owning_Clan()
        {
            var factionRelationsService = new FactionRelationsService();

            var result = factionRelationsService.GetFactionsAbleToGenRepToOutpost(new Faction("BioTech"), 15);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.ToList()[0], Is.EqualTo(new Faction("Owning Clan")), "expected: Owning Clan\n\tgot: " + result.ToList()[0].Name);
        }

        [Test]
        public void When_code_is_5_result_is_passed_in_factions_allies()
        {
            var factionRelationsService = new FactionRelationsService();

            var result = factionRelationsService.GetFactionsAbleToGenRepToOutpost(new Faction("BioTech"), 5);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.ToList()[0], Is.EqualTo(new Faction("CityAdmin")), "expected: CityAdmin\n\tgot: " + result.ToList()[0].Name);
            Assert.That(result.ToList()[1], Is.EqualTo(new Faction("BioTech")), "expected: BioTech\n\tgot: " + result.ToList()[1].Name);
            Assert.That(result.ToList()[2], Is.EqualTo(new Faction("ProtoPharm")), "expected: ProtoPharm\n\tgot: " + result.ToList()[2].Name);
        }
    }
}