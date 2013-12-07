using System.Web.Mvc;
using NeocronWorldMap.Web.Controllers.Actions;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.ViewModelBuilders;
using StructureMap;

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
                            scanner.AddAllTypesOf<ICreateZonesFromCoordinates>();
                            scanner.AddAllTypesOf<IBuildZoneDetailsViewModels>();
                        });
                });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }
}