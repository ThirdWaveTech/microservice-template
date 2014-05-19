using System.Web.Mvc;

namespace __NAME__.WebApi.Controllers
{
    public class PingController : Controller
    {
        public void Index()
        {
            Response.Write("status=active");
        }
    }
}
