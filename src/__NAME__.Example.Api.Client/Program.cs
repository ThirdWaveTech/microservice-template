using System;
using StructureMap;
using __NAME__.Api.Client;
using __NAME__.Api.Client.Bootstrap;
using __NAME__.Api.Client.ResourceClients;
using __NAME__.Models.ClientInfo;

namespace __NAME__.Example.Api.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReSharper disable once CSharpWarnings::CS0618
            ObjectFactory.Initialize(x => x.AddRegistry<__NAME__ApiClientRegistry>());

            TestApi();
        }

        public static async void TestApi()
        {
            // ReSharper disable once CSharpWarnings::CS0618
            var client = ObjectFactory.GetInstance<IApiInfoClient>();

            var clientConnect = client.Post(new RegisterClientModel(), Guid.NewGuid().ToString());

            clientConnect.Wait();

            var ping = await client.Get();

            Console.WriteLine(ping);
        }
    }
}
