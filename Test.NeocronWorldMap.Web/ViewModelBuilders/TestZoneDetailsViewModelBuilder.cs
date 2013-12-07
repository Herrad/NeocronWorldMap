using NUnit.Framework;
using NeocronWorldMap.Web.ViewModelBuilders;

namespace Test.NeocronWorldMap.Web.ViewModelBuilders
{
    [TestFixture]
    public class TestZoneDetailsViewModelBuilder
    {
        [Test]
        public void Builds_a_ZoneDetailsViewModel()
        {
            var zoneDetailsViewModelBuilder = new ZoneDetailsViewModelBuilder();

            var zoneDetailsViewModel = zoneDetailsViewModelBuilder.Build(null);

            Assert.That(zoneDetailsViewModel, Is.Not.Null);
        }
    }
}