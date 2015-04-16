using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Features;
using StructureMap.Configuration.DSL;

namespace __NAME__.Api.Client.Async.Bootstrap
{
    class SendOnlyClientRegistry: Registry
    {
        public SendOnlyClientRegistry()
        {
            //NServiceBus.Logging.LogManager.Use<Log4NetFactory>();

            var configuration = new BusConfiguration();

            //configuration.UseContainer<StructureMapBuilder>(c => c.ExistingContainer(ObjectFactory.Container));
            //configuration.AssembliesToScan(new Assembly[] { typeof(ReportReceivedMessage).Assembly });
            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.DisableFeature<Sagas>();
            configuration.DisableFeature<MessageDrivenSubscriptions>();
            configuration.DisableFeature<TimeoutManager>();
            var bus = Bus.CreateSendOnly(configuration);

            ForSingletonOf<ISendOnlyBus>().Use(bus);

        }
    }
}
