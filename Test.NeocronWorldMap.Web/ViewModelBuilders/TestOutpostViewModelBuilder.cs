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

            var outpostViewModelBuilder = new OutpostViewModelBuilder();

            var outpost = new Outpost(expectedName, null, new Clan(null, new Faction(null)));

            var outpostViewModel = outpostViewModelBuilder.Build(outpost);

            Assert.That(outpostViewModel, Is.Not.Null);
            Assert.That(outpostViewModel.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void Sets_OwnerViewModel()
        {
            const string expectedClanName = "foo clan";
            const string expectedFactionName = "foo faction";
            var outpostViewModelBuilder = new OutpostViewModelBuilder();

            var faction = new Faction(expectedFactionName);
            var currentOwners = new Clan(expectedClanName, faction);

            var outpost = new Outpost(null, null, currentOwners);

            var outpostViewModel = outpostViewModelBuilder.Build(outpost);

            var outpostOwnershipViewModel = outpostViewModel.OutpostOwnershipViewModel;

            Assert.That(outpostOwnershipViewModel, Is.Not.Null);
            Assert.That(outpostOwnershipViewModel.ClanName, Is.EqualTo(expectedClanName));
            Assert.That(outpostOwnershipViewModel.FactionName, Is.EqualTo(expectedFactionName));
        }
    }
}