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
            var yaxis = new[] { 'k', 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a' };

            var gridViewModelBuilder = new GridViewModelBuilder();

            var viewModel = gridViewModelBuilder.Build();

            Assert.That(viewModel.YAxis, Is.EqualTo(yaxis));
        }

        [Test]
        public void Sets_x_axis()
        {
            var xaxis = new[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17" };

            var gridViewModelBuilder = new GridViewModelBuilder();

            var viewModel = gridViewModelBuilder.Build();

            Assert.That(viewModel.XAxis, Is.EqualTo(xaxis));
        } 
    }
}