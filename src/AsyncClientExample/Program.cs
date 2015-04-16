using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Graph;
using __NAME__.Api.AsyncClient;
using __NAME__.Api.Client.Async.Bootstrap;

namespace AsyncClientExample
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


            var client = ObjectFactory.GetInstance<__NAME__AsyncClient>();

            client.Register("Sample client");
        }
    }
}
