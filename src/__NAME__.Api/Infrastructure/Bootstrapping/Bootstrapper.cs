using Owin;

namespace __NAME__.Api.Infrastructure.Bootstrapping
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}