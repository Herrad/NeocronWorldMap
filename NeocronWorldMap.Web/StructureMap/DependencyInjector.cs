using System.Web.Mvc;
using NeocronWorldMap.Web.Controllers.Actions;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.Services.Repositories;
using NeocronWorldMap.Web.ViewModelBuilders;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;

namespace NeocronWorldMap.Web.StructureMap
{
    public static class DependencyInjector
    {
        public static void SetUpIoC()
        {
            ObjectFactory.Configure(x =>
                {
                    x.AddRegistry(new NeocronWorldMapRegistry());
                    x.For<IControllerActivator>().Use<StructureMapControllerActivator>();

                    x.For<IConnectToTheNeocronApi>().LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Singleton));
                    x.For<IConnectToTheNeocronApi>().Use<InMemoryApi>();
                    x.For<IKnowWhereOutpostsAre>().LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Singleton));
                });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }

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