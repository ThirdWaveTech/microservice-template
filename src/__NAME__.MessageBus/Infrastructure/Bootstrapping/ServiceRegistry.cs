using StructureMap.Configuration.DSL;

namespace __NAME__.MessageBus.Infrastructure.Bootstrapping
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            Scan(s => { s.TheCallingAssembly(); s.WithDefaultConventions(); });
        }
    }
}
