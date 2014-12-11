using Crux.Core.Bootstrapping;
using Crux.NancyFx.Infrastructure.Serialization;
using Nancy.Authentication.Token;
using Newtonsoft.Json;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace __NAME__.Host.Infrastructure.Bootstrapping.Registries
{
    public class AppRegistry : Registry
    {
        public AppRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.AddAllTypesOf<IRunAtStartup>();
            });

            For<ITokenizer>().Use(new Tokenizer());
            For<JsonSerializer>().Use<CustomJsonSerializer>();
        }
    }
}