using Nancy;
using Nancy.Responses;

namespace __NAME__.Api.Infrastructure.Diagnostics
{
    public class PingModule : NancyModule
    {
        public PingModule()
        {
            Get["ping"] = _ => new TextResponse("__NAME__.Api\nStatus=active");
        }
    }
}