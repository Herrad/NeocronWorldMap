using NUnit.Framework;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModelBuilders;

namespace Test.NeocronWorldMap.Web.ViewModelBuilders
{
    [TestFixture]
    public class TestOutpostOwnershipViewModelBuilder
    {
        [Test]
        public void Sets_current_owning_faction_name()
        {
            var outpostOwnershipViewModelBuilder = new OutpostOwnershipViewModelBuilder();

            var outpostOwnershipProfile = new OutpostOwnershipProfile(FactionFactory.BuildNext());

            var outpostOwnershipViewModel = outpostOwnershipViewModelBuilder.Build(outpostOwnershipProfile);

            Assert.That(outpostOwnershipViewModel, Is.Not.Null);
            Assert.That(outpostOwnershipViewModel.FactionName, Is.EqualTo("NeXT"));
        }
    }
}