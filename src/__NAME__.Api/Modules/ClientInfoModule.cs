using Nancy;

namespace __NAME__.Api.Modules
{
    public class ClientInfoModule : NancyModule
    {
        public static string ClientInfoModulePath = "clientinfo";
        public ClientInfoModule() : base(ClientInfoModulePath)
        {
            
        }
    }
}