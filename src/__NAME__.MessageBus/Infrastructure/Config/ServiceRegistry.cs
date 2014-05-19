using StructureMap.Configuration.DSL;

namespace __NAME__.MessageBus.Infrastructure.Config
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            Scan(s => { s.TheCallingAssembly(); s.WithDefaultConventions(); });
        }
    }
}
