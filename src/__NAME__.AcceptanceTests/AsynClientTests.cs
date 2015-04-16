using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Graph;
using __NAME__.Api.AsyncClient;
using __NAME__.Api.Client.Async.Bootstrap;

namespace __NAME__.AcceptanceTests
{
    public class AsynClientTests
    {
        public AsynClientTests()
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

            client.Register("Test client");

        }
    }
}
