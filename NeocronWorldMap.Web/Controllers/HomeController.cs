using System.Web.Mvc;
using NeocronWorldMap.Web.Controllers.Actions;

namespace NeocronWorldMap.Web.Controllers
{
    public class HomeController : Controller, IRenderViews
    {
        private readonly IActionIndexRequests _indexAction;
        private object _viewModel;

        public HomeController(IActionIndexRequests indexAction)
        {
            _indexAction = indexAction;
        }

        public ViewResult Index()
        {
            _indexAction.Execute(this);
            return View(_viewModel);
        }

        public void SetViewModel(object viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
