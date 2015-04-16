using StructureMap;
using StructureMap.Graph;
using __NAME__.MessageBus.Client;
using __NAME__.MessageBus.Client.Bootstrap;

namespace __NAME__.MessageBus.ClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectFactory.Initialize(x =>
            {
                x.IncludeRegistry<SendOnlyClientRegistry>();
                x.Scan(y =>
                {
                    y.AssembliesFromApplicationBaseDirectory();
                    y.TheCallingAssembly();
                });
            });


            var client = ObjectFactory.GetInstance<Sender>();

            client.Register("Sample client");
        }
    }
}
