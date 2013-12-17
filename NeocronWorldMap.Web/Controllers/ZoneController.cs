using System.Web.Mvc;
using NeocronWorldMap.Web.Controllers.Actions;

namespace NeocronWorldMap.Web.Controllers
{
    public class ZoneController : Controller, IRenderViews, IRenderJsonViews
    {
        private readonly IActionZoneDetailsRequests _detailsAction;
        private object _viewModel;
        private object _jsonObject;

        public ZoneController(IActionZoneDetailsRequests detailsAction)
        {
            _detailsAction = detailsAction;
        }

        public ViewResult Details(string xCoordinate, char yCoordinate)
        {
            _detailsAction.Execute(xCoordinate, yCoordinate, this);

            return View(_viewModel);
        }

        public void SetViewModel(object viewModel)
        {
            _viewModel = viewModel;
        }

        public PartialViewResult PartialDetails(string xCoordinate, char yCoordinate)
        {
            var detailsResult = Details(xCoordinate, yCoordinate);

            return PartialView("_PartialDetails", detailsResult.Model);
        }

        public JsonResult OutpostsOwnedByFaction()
        {
            return Json(_jsonObject);
        }

        public void SetJsonObject(object objectToJsonify)
        {
            _jsonObject = objectToJsonify;
        }
    }
}