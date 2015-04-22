using StructureMap;
using __NAME__.Api.Client.Diagnostics;
using __NAME__.Api.Client.Examples;

namespace __NAME__.Api.Client
{
    public static class ApiClientBootstrapper
    {
        public static void Bootstrap(IContainer container)
        {
            container.Configure(c => {
                c.ForSingletonOf<IDiagnosticsClient>().Use(ApiClientFactory.GetClient<IDiagnosticsClient>());
                c.ForSingletonOf<IExampleClient>().Use(ApiClientFactory.GetClient<IExampleClient>());
            });
        }
    }
}
