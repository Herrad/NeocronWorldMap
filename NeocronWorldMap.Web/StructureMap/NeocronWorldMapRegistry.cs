using NeocronWorldMap.Web.Controllers.Actions;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.Services.Repositories;
using NeocronWorldMap.Web.ViewModelBuilders;
using StructureMap.Configuration.DSL;

namespace NeocronWorldMap.Web.StructureMap
{
    public class NeocronWorldMapRegistry : Registry
    {
        public NeocronWorldMapRegistry()
        {
            Scan(scanner  =>
                 {
                     scanner.TheCallingAssembly();
                     scanner.AddAllTypesOf<IActionZoneDetailsRequests>();
                     scanner.AddAllTypesOf<IBuildZoneDetailsViewModels>();
                     scanner.AddAllTypesOf<IActionIndexRequests>();
                     scanner.AddAllTypesOf<IBuildGridViewModels>();
                     scanner.AddAllTypesOf<IRetrieveOutpostInformationForZones>();
                     scanner.AddAllTypesOf<IBuildOutpostViewModels>();
                     scanner.AddAllTypesOf<IKnowWhereOutpostsAre>();        
                     scanner.AddAllTypesOf<IRetrieveOwnershipInformation>();
                     scanner.AddAllTypesOf<IConnectToTheNeocronApi>();
                     scanner.AddAllTypesOf<IBuildFactions>();
                     scanner.AddAllTypesOf<IFormatTimeSpans>();
                 });
        }
    }
}