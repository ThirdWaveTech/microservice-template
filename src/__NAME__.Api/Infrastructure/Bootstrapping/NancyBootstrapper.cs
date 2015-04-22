using System.Linq;
using AutoMapper;
using Crux.Core.Bootstrapping;
using Crux.Logging;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.StructureMap;
using Nancy.Diagnostics;
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

            MessageBusClientBootstrapper.Bootstrap(existingContainer);

            InitializeStartupRunners(existingContainer);
        }

        protected override void RequestStartup(IContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
            // Enable token authentication
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(requestContainer.GetInstance<ITokenizer>()));

            // Set up unit of work
            pipelines.BeforeRequest += UnitOfWorkPipeline.BeforeRequest(requestContainer);
            pipelines.AfterRequest += UnitOfWorkPipeline.AfterRequest();

            // Set up validation exception handling
            pipelines.OnError += Crux.NancyFx.Infrastructure.Pipelines.Pipelines.OnHttpBadRequest;
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