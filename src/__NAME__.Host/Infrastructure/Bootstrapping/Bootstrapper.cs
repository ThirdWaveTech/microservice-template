using Owin;

namespace __NAME__.Host.Infrastructure.Bootstrapping
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}