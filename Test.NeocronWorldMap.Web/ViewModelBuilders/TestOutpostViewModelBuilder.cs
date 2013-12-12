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

            var outpost = new Outpost(expectedName, null, null);

            var outpostViewModel = outpostViewModelBuilder.Build(outpost);

            Assert.That(outpostViewModel, Is.Not.Null);
            Assert.That(outpostViewModel.Name, Is.EqualTo(expectedName));
        }
    }
}