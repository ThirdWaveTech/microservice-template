using System.Linq;
using AutoMapper;
using Crux.Core.Bootstrapping;
using Crux.Logging;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.StructureMap;
using Nancy.Diagnostics;
using NServiceBus;
using NServiceBus.Features;
using StructureMap;
using StructureMap.Graph;
using __NAME__.Api.Infrastructure.Pipelines;
using __NAME__.MessageBus.Client;

namespace __NAME__.Api.Infrastructure.Bootstrapping
{
    public class NancyBootstrapper : StructureMapNancyBootstrapper
    {
        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new DiagnosticsConfiguration {Password = "1234"}; }
        }

        static NancyBootstrapper()
        {
            InitializeLogging();
        }

        protected override void ConfigureApplicationContainer(IContainer existingContainer)
        {
            existingContainer.Configure(c => c.Scan(s => {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.LookForRegistries();
            }));

            InitializeNServiceBus(existingContainer);

            InitializeStartupRunners(existingContainer);
        }

        private void InitializeNServiceBus(IContainer existingContainer)
        {
            var configuration = new BusConfiguration();

            configuration.UseContainer<StructureMapBuilder>(c => c.ExistingContainer(existingContainer));

            var conventions = configuration.Conventions();
            conventions.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("__NAME__") && t.Namespace.EndsWith("Commands"));
            conventions.DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("__NAME__") && t.Namespace.EndsWith("Events"));
            conventions.DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("__NAME__") && t.Namespace.EndsWith("Messages"));

            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.DisableFeature<Sagas>();
            configuration.DisableFeature<MessageDrivenSubscriptions>();
            configuration.DisableFeature<TimeoutManager>();
            var bus = Bus.CreateSendOnly(configuration);

            existingContainer.Configure(c => {
                c.ForSingletonOf<ISendOnlyBus>().Use(bus);
                c.ForSingletonOf<Sender>().Use(new Sender(bus));
            });
        }

        protected override void RequestStartup(IContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
            // Enable token authentication
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(requestContainer.GetInstance<ITokenizer>()));

            // Set up unit of work
            pipelines.BeforeRequest += UnitOfWorkPipeline.BeforeRequest(requestContainer);
            pipelines.AfterRequest += UnitOfWorkPipeline.AfterRequest();
        }

        private static void InitializeLogging()
        {
            new LoggingConfigurator().Configure();
        }

        private static void InitializeStartupRunners(IContainer existingContainer)
        {
            var mappingDefinitions = existingContainer.GetAllInstances<IRunAtStartup>().ToList();
            mappingDefinitions.ForEach(mappingDefinition => mappingDefinition.Init());

            Mapper.AssertConfigurationIsValid();
        }
    }
}