using System;
using NUnit.Framework;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModelBuilders;

namespace Test.NeocronWorldMap.Web.ViewModelBuilders
{
    [TestFixture]
    public class TestOutpostViewModelBuilder
    {
        [Test]
        public void Sets_name_on_OutpostViewModel()
        {
            const string expectedName = "foo";

            var outpostViewModelBuilder = new OutpostViewModelBuilder(new TimeFormatter());

            var currentOwners = new Clan(null, new Faction("foo faction"), new TimeSpan(), 0);

            var outpost = new Outpost(expectedName, null, currentOwners, null);

            var outpostViewModel = outpostViewModelBuilder.Build(outpost);

            Assert.That(outpostViewModel, Is.Not.Null);
            Assert.That(outpostViewModel.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void Sets_OwnerViewModel()
        {
            const string expectedClanName = "foo clan";
            const string expectedFactionName = "foo faction.dot";
            var timeOwnedFor = new TimeSpan(1, 2, 3, 4);

            var outpostViewModelBuilder = new OutpostViewModelBuilder(new TimeFormatter());

            var faction = new Faction(expectedFactionName);
            var currentOwners = new Clan(expectedClanName, faction, timeOwnedFor, 0);

            var outpost = new Outpost(null, null, currentOwners, null);

            var outpostViewModel = outpostViewModelBuilder.Build(outpost);

            var outpostOwnershipViewModel = outpostViewModel.OutpostOwnershipViewModel;

            Assert.That(outpostOwnershipViewModel, Is.Not.Null);
            Assert.That(outpostOwnershipViewModel.ClanName, Is.EqualTo(expectedClanName));
            Assert.That(outpostOwnershipViewModel.FactionName, Is.EqualTo(expectedFactionName));
            Assert.That(outpostViewModel.OutpostOwnershipViewModel.FactionClass, Is.EqualTo("foo-factiondot"));
        }

        [TestCase(1, "1 day 02:03:04")]
        [TestCase(5, "5 days 02:03:04")]
        [TestCase(45, "45 days 02:03:04")]
        public void Formats_TimeOwnedFor_correctly(int days, string expectedFormattedTime)
        {
            var timeOwnedFor = new TimeSpan(days, 2, 3, 4);
            
            var outpostViewModelBuilder = new OutpostViewModelBuilder(new TimeFormatter());

            var faction = new Faction("faction");
            var currentOwners = new Clan("clan", faction, timeOwnedFor, 0);

            var outpost = new Outpost(null, null, currentOwners, null);

            var outpostViewModel = outpostViewModelBuilder.Build(outpost);

            var outpostOwnershipViewModel = outpostViewModel.OutpostOwnershipViewModel;

            Assert.That(outpostOwnershipViewModel.TimeOwnedFor, Is.EqualTo(expectedFormattedTime));
        }
    }
}