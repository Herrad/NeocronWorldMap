using NUnit.Framework;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModelBuilders;
using NeocronWorldMap.Web.ViewModels;
using Rhino.Mocks;

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
            var expectedZoneName = char.ToUpper(yCoordinate) + xCoordinate;

            var outpostViewModelBuilder = MockRepository.GenerateStub<IBuildOutpostViewModels>();

            var zoneDetailsViewModelBuilder = new ZoneDetailsViewModelBuilder(outpostViewModelBuilder);

            var coordinates = new Coordinates(xCoordinate, yCoordinate);

            var outpost = new Outpost("foo name", new NeocronZone(coordinates));

            var zoneDetailsViewModel = zoneDetailsViewModelBuilder.Build(outpost);

            Assert.That(zoneDetailsViewModel, Is.Not.Null);
            Assert.That(zoneDetailsViewModel.XCoordinate, Is.EqualTo(xCoordinate));
            Assert.That(zoneDetailsViewModel.YCoordinate, Is.EqualTo(yCoordinate));
            Assert.That(zoneDetailsViewModel.ZoneName, Is.EqualTo(expectedZoneName));
        }

        [Test]
        public void Sets_OutpostViewModel_using_builder()
        {
            const string xCoordinate = "08";
            const char yCoordinate = 'd';

            var coordinates = new Coordinates(xCoordinate, yCoordinate);
            var outpost = new Outpost("foo name", new NeocronZone(coordinates));
            var outpostViewModel = new OutpostViewModel("foo");

            var outpostViewModelBuilder = MockRepository.GenerateStub<IBuildOutpostViewModels>();
            outpostViewModelBuilder
                .Stub(x => x.Build(outpost))
                .Return(outpostViewModel);

            var zoneDetailsViewModelBuilder = new ZoneDetailsViewModelBuilder(outpostViewModelBuilder);


            var zoneDetailsViewModel = zoneDetailsViewModelBuilder.Build(outpost);

            Assert.That(zoneDetailsViewModel.OutpostViewModel, Is.EqualTo(outpostViewModel));
        }
    }
}