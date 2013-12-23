using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.Controllers
{
    public class OutpostListController : Controller
    {
        private readonly IKnowWhereOutpostsAre _outpostLocations;
        private readonly IRetrieveOutpostInformationForZones _outpostService;

        public OutpostListController(IKnowWhereOutpostsAre outpostLocations, IRetrieveOutpostInformationForZones outpostService)
        {
            _outpostLocations = outpostLocations;
            _outpostService = outpostService;
        }

        public ActionResult Index()
        {
            var outposts = new List<IHaveOutpostData>();
            var coordinatesOfAllOutposts = _outpostLocations.GetCoordinatesOfAllOutposts();

            foreach (var outpostCoordinates in coordinatesOfAllOutposts)
            {
                outposts.Add(_outpostService.GetOutpostDataAt(outpostCoordinates));
            }

            var outpostListViewModels = outposts.Select(outpost => new OutpostListViewModel(outpost.Name, outpost.Zone.Coordinates, outpost.CurrentOwners.Faction));

            return View(outpostListViewModels);
        }
    }
}
