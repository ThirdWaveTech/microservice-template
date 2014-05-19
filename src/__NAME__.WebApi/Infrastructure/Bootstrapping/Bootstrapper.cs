using System.Web.Http;
using System.Web.Http.Dispatcher;
using Crux.Logging;
using Crux.StructureMap;
using Crux.WebApi.Activators;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace __NAME__.WebApi.Infrastructure.Bootstrapping
{
    public static class Bootstrapper
    {
        public static void Bootstrap()
        {
            InitializeLogging();

            InitializeStructureMap();

            InitializeServiceLocator();

            InitializeControllerActivator();
        }

        private static void InitializeControllerActivator()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new ControllerActivator());
        }

        private static void InitializeServiceLocator()
        {
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(ObjectFactory.Container));
        }

        private static void InitializeStructureMap()
        {
            ObjectFactory.Configure(c => 
                c.Scan(s => {
                    s.TheCallingAssembly();
                    s.LookForRegistries();
                })
            );
        }

        private static void InitializeLogging()
        {
            new LoggingConfigurator().Configure();
        }
    }
}