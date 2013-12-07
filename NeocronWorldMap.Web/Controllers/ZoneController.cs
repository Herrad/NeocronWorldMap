using System.Web.Mvc;
using NeocronWorldMap.Web.Controllers.Actions;

namespace NeocronWorldMap.Web.Controllers
{
    public class ZoneController : Controller
    {
        private readonly IActionZoneDetailsRequests _detailsAction;

        public ZoneController(IActionZoneDetailsRequests detailsAction)
        {
            _detailsAction = detailsAction;
        }

        public ViewResult Details(char xCoordinate, int yCoordinate)
        {
            _detailsAction.Execute(xCoordinate, yCoordinate, this);

            return View();
        }
    }
}