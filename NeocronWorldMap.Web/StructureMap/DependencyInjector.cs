using System.Web.Mvc;
using NeocronWorldMap.Web.Controllers.Actions;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.Services.Repositories;
using NeocronWorldMap.Web.ViewModelBuilders;
using StructureMap;
using StructureMap.Pipeline;

namespace NeocronWorldMap.Web.StructureMap
{
    public static class DependencyInjector
    {
        public static void SetUpIoC()
        {
            ObjectFactory.Configure(x =>
                {
                    x.For<IControllerActivator>().Use<StructureMapControllerActivator>();
                    x.Scan(scanner  =>
                        {
                            scanner.TheCallingAssembly();
                            scanner.AddAllTypesOf<IActionZoneDetailsRequests>();
                            scanner.AddAllTypesOf<IBuildZoneDetailsViewModels>();
                            scanner.AddAllTypesOf<IActionIndexRequests>();
                            scanner.AddAllTypesOf<IBuildGridViewModels>();
                            scanner.AddAllTypesOf<IRetrieveOutpostInformation>();
                            scanner.AddAllTypesOf<IBuildOutpostViewModels>();
                            scanner.AddAllTypesOf<IKnowWhereOutpostsAre>();        
                            scanner.AddAllTypesOf<IRetrieveOwnershipInformation>();
                            scanner.AddAllTypesOf<IConnectToTheNeocronApi>();
                            scanner.AddAllTypesOf<IConvertCoordinatesToSectorCodes>();
                        });

                    x.For<OutpostLocations>().LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Singleton));
                });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }
}