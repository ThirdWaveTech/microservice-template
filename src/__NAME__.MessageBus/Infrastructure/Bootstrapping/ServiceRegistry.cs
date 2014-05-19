using Crux.Core.Bootstrapping;
using Crux.StructureMap;
using Microsoft.Practices.ServiceLocation;
using StructureMap.Configuration.DSL;

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

            RegisterServiceLocator();
        }

        private void RegisterServiceLocator()
        {
            For<IServiceLocator>().Use<StructureMapServiceLocator>();
        }
    }
}
