using System.Linq;
using AutoMapper;
using Crux.Core.Bootstrapping;
using Crux.Logging;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.StructureMap;
using StructureMap;
using StructureMap.Graph;

namespace __NAME__.Host.Infrastructure.Bootstrapping
{
    public class NancyBootstrapper : StructureMapNancyBootstrapper
    {
        static NancyBootstrapper()
        {
            InitializeLogging();
        }

        protected override void ConfigureApplicationContainer(IContainer existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);

            existingContainer.Configure(c => c.Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.LookForRegistries();
            }));

            InitializeStartupRunners(existingContainer);
        }

        protected override void RequestStartup(IContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(requestContainer.GetInstance<ITokenizer>()));

            pipelines.OnError += Crux.NancyFx.Infrastructure.Pipelines.Pipelines.OnError;
            pipelines.BeforeRequest += Crux.NancyFx.Infrastructure.Pipelines.Pipelines.BeforeEveryRequest(requestContainer);
            pipelines.AfterRequest += Crux.NancyFx.Infrastructure.Pipelines.Pipelines.AfterEveryRequest;
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