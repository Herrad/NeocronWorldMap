using NUnit.Framework;
using NeocronWorldMap.Web.ViewModelBuilders;

namespace Test.NeocronWorldMap.Web.ViewModelBuilders
{
    [TestFixture]
    public class TestGridViewModelBuilder
    {
        [Test]
        public void Builds_a_ViewModel()
        {
            var gridViewModelBuilder = new GridViewModelBuilder();

            var viewModel = gridViewModelBuilder.Build();

            Assert.That(viewModel, Is.Not.Null);
        }
        [Test]
        public void Sets_y_axis()
        {
            var yaxis = new[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k'};

            var gridViewModelBuilder = new GridViewModelBuilder();

            var viewModel = gridViewModelBuilder.Build();

            Assert.That(viewModel.YAxis, Is.EqualTo(yaxis));
        } 
    }
}