using Owin;
using __NAME__.Host.Infrastructure.Bootstrapping;

namespace __NAME__.Host
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