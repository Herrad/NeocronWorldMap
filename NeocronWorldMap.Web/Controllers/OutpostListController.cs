using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.NeocronPublicInterface;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.Services.Repositories;
using NeocronWorldMap.Web.ViewModels;
using Outpost = NeocronWorldMap.Web.Domain.Outpost;

namespace NeocronWorldMap.Web.Controllers
{
    public class OutpostListController : Controller
    {
        private readonly IConnectToTheNeocronApi _neocronApi;
        private readonly IKnowWhereOutpostsAre _outpostLocations;
        private readonly IRetrieveOwnershipInformation _ownershipService;

        public OutpostListController(IConnectToTheNeocronApi neocronApi, IKnowWhereOutpostsAre outpostLocations, IRetrieveOwnershipInformation ownershipService)
        {
            _neocronApi = neocronApi;
            _outpostLocations = outpostLocations;
            _ownershipService = ownershipService;
        }

        public ActionResult Index()
        {
            var outpostsFromApi = _neocronApi.GetOutposts().Outposts;

            var outposts = outpostsFromApi.Select(BuildOutpost);

            var outpostListViewModels = outposts.Select(outpost => new OutpostListViewModel(outpost.Name, outpost.Zone.Coordinates, outpost.CurrentOwners.Faction));

            return View(outpostListViewModels);
        }

        private Outpost BuildOutpost(NeocronPublicInterface.Outpost outpostFromApi)
        {
            var coordinates = BuildCoordinates(outpostFromApi.Id);
            var name = GetOutpostName(outpostFromApi.Id);
            var neocronZone = new NeocronZone(coordinates);
            var currentOwners = _ownershipService.GetCurrentOwners(coordinates);

            return new Outpost(name, neocronZone, currentOwners);
        }

        private string GetOutpostName(int id)
        {
            var coordinates = BuildCoordinates(id);

            return _outpostLocations.GetOutpostNameAt(coordinates);
        }

        private static Coordinates BuildCoordinates(int id)
        {
            var baseId = id - 2000;
            var yCoordinate = (char) (baseId/20);
            var xCoordinate = (baseId%20).ToString(CultureInfo.InvariantCulture);
            var coordinates = new Coordinates(xCoordinate, yCoordinate);
            return coordinates;
        }
    }
}
