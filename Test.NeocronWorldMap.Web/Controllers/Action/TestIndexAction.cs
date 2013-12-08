using NUnit.Framework;
using NeocronWorldMap.Web.Controllers;
using NeocronWorldMap.Web.Controllers.Actions;
using NeocronWorldMap.Web.ViewModelBuilders;
using NeocronWorldMap.Web.ViewModels;
using Rhino.Mocks;

namespace Test.NeocronWorldMap.Web.Controllers.Action
{
    [TestFixture]
    public class TestIndexAction
    {
        [Test]
        public void Sets_view_model_to_result_of_GridViewModelBuilder()
        {
            var gridViewModel = new GridViewModel(null, null);

            var viewModelBuilder = MockRepository.GenerateStub<IBuildGridViewModels>();
            viewModelBuilder
                .Stub(x => x.Build())
                .Return(gridViewModel);

            var viewRenderer = MockRepository.GenerateMock<IRenderViews>();

            var indexAction = new IndexAction(viewModelBuilder);

            indexAction.Execute(viewRenderer);

            viewRenderer.AssertWasCalled(
                    x => x.SetViewModel(gridViewModel), 
                    c => c.Repeat.Once());
        }
    }
}