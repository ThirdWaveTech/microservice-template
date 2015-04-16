using StructureMap.Configuration.DSL;
using __NAME__.Api.Client.ResourceClients;

namespace __NAME__.Api.Client.Bootstrap
{
    public class __NAME__ApiClientRegistry : Registry
    {
        public __NAME__ApiClientRegistry()
        {
            ForSingletonOf<IApiInfoClient>().Use(__NAME__ClientFactory.GetClient<IApiInfoClient>());
        }
    }
}
