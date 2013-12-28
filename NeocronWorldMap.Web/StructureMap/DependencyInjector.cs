using System.Web.Mvc;
using NeocronWorldMap.Web.Services;
using NeocronWorldMap.Web.Services.Repositories;
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
                    x.AddRegistry(new NeocronWorldMapRegistry());
                    x.For<IControllerActivator>().Use<StructureMapControllerActivator>();

                    x.For<IConnectToTheNeocronApi>().LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Singleton));
                    x.For<IConnectToTheNeocronApi>().Use<InMemoryApi>();
                    x.For<IKnowWhereOutpostsAre>().LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Singleton));
                });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }
}