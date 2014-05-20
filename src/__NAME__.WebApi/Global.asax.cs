using System;
using System.Web.Http;
using __NAME__.WebApi.Infrastructure.Bootstrapping;

namespace __NAME__.WebApi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalConfiguration.Configuration.Filters);
            Bootstrapper.Bootstrap();
        }
    }
}