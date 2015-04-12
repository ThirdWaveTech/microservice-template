using Owin;
using __NAME__.Api.Infrastructure.Bootstrapping;

namespace __NAME__.Api
{
    //OWIN startup
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Bootstrapper.Bootstrap(app);
        }
    }
}