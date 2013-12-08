using NeocronWorldMap.Web.ViewModelBuilders;

namespace NeocronWorldMap.Web.Controllers.Actions
{
    public class IndexAction : IActionIndexRequests
    {
        private readonly IBuildGridViewModels _viewModelBuilder;

        public IndexAction(IBuildGridViewModels viewModelBuilder)
        {
            _viewModelBuilder = viewModelBuilder;
        }

        public void Execute(IRenderViews viewRenderer)
        {
            var gridViewModel = _viewModelBuilder.Build();

            viewRenderer.SetViewModel(gridViewModel);
        }
    }
}