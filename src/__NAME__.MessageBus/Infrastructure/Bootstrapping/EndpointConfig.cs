using Crux.NServiceBus.Extensions;
using Crux.StructureMap;
using Microsoft.Practices.ServiceLocation;
using NServiceBus;
using NServiceBus.Features;
using StructureMap;

namespace __NAME__.MessageBus.Infrastructure.Bootstrapping
{
    [EndpointName("__NAME__.input")]
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        void IWantCustomInitialization.Init()
        {
            InitServiceBus();

            InitStructureMap();

            InitServiceLocator();
        }

        private void InitServiceBus()
        {
            Configure.Serialization.Xml();

            // Keep it simple by default
            Configure.Features
                .Disable<SecondLevelRetries>()
                .Disable<AutoSubscribe>()
                .Disable<TimeoutManager>();

            Configure.Transactions.Enable();

            Configure.With()
                .StructureMapBuilder(ObjectFactory.Container)
                .DefaultMessageNamingConventions()
                .Log4Net()
                .UseTransport<Msmq>()
                    .PurgeOnStartup(false)
                .UnicastBus()
                    .LoadMessageHandlers()
                ;
        }

        private void InitServiceLocator()
        {
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(ObjectFactory.Container));
        }

        private void InitStructureMap()
        {
            ObjectFactory.Configure(c => c.Scan(s => {
                s.TheCallingAssembly(); 
                s.LookForRegistries();
            }));
        }
    }
}
