using Microsoft.Owin.Extensions;
using Owin;

namespace __NAME__.Api
{
    // OWIN startup
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}