using System.Web;
using Crux.Core.Bootstrapping;
using Crux.StructureMap;
using Microsoft.Practices.ServiceLocation;
using StructureMap.Configuration.DSL;

namespace __NAME__.WebApi.Infrastructure.Bootstrapping
{
    public class SiteRegistry : Registry
    {
        public SiteRegistry()
        {
            Scan(s => {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.AddAllTypesOf<IRunAtStartup>();
            });

            RegisterServiceLocator();

            RegisterHttpContext();
        }

        private void RegisterHttpContext()
        {
            For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
        }

        private void RegisterServiceLocator()
        {
            For<IServiceLocator>().Use<StructureMapServiceLocator>();
        }
    }
}