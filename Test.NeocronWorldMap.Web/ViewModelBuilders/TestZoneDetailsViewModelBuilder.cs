using NUnit.Framework;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModelBuilders;

namespace Test.NeocronWorldMap.Web.ViewModelBuilders
{
    [TestFixture]
    public class TestZoneDetailsViewModelBuilder
    {
        [Test]
        public void Sets_basic_information_on_ZoneDetailsViewModel()
        {
            const string xCoordinate = "08";
            const char yCoordinate = 'd';

            var zoneDetailsViewModelBuilder = new ZoneDetailsViewModelBuilder();

            var coordinates = new Coordinates(xCoordinate, yCoordinate);

            var neocronZone = new NeocronZone(coordinates, null);

            var zoneDetailsViewModel = zoneDetailsViewModelBuilder.Build(neocronZone);

            Assert.That(zoneDetailsViewModel, Is.Not.Null);
            Assert.That(zoneDetailsViewModel.XCoordinate, Is.EqualTo(xCoordinate));
            Assert.That(zoneDetailsViewModel.YCoordinate, Is.EqualTo(yCoordinate));
        }
    }
}