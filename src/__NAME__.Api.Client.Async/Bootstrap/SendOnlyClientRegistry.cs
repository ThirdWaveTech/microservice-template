using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Features;
using StructureMap;
using StructureMap.Configuration.DSL;
using __NAME__.Api.AsyncClient;
using __NAME__.Messages.Commands;

namespace __NAME__.Api.Client.Async.Bootstrap
{
    public class SendOnlyClientRegistry: Registry
    {
        public SendOnlyClientRegistry()
        {
            //NServiceBus.Logging.LogManager.Use<Log4NetFactory>();

            var configuration = new BusConfiguration();

            configuration.UseContainer<StructureMapBuilder>(c => c.ExistingContainer(ObjectFactory.Container));
            //configuration.AssembliesToScan(new Assembly[] { typeof(RegisterClientCommand).Assembly });
            ConventionsBuilder conventions = configuration.Conventions();
            conventions.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("__NAME__") && t.Namespace.EndsWith("Commands"));
            conventions.DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("__NAME__") && t.Namespace.EndsWith("Events"));
            conventions.DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("__NAME__") && t.Namespace.EndsWith("Messages"));
            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.DisableFeature<Sagas>();
            configuration.DisableFeature<MessageDrivenSubscriptions>();
            configuration.DisableFeature<TimeoutManager>();
            var bus = Bus.CreateSendOnly(configuration);

            ForSingletonOf<ISendOnlyBus>().Use(bus);

            ForSingletonOf<__NAME__AsyncClient>().Use(new __NAME__AsyncClient(bus));
        }
    }
}
