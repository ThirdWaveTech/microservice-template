using Crux.Core.Bootstrapping;
using Crux.StructureMap;
using Microsoft.Practices.ServiceLocation;
using NServiceBus.UnitOfWork;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace __NAME__.MessageBus.Infrastructure.Bootstrapping
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            Scan(s => {
                s.TheCallingAssembly(); 
                s.WithDefaultConventions();

                s.AddAllTypesOf<IRunAtStartup>();
            });

            For<IServiceLocator>().Use<StructureMapServiceLocator>();

            For<IManageUnitsOfWork>().Use<UnitOfWorkManager>();
        }
    }
}
