using InteractionHub.Logging;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace InteractionHub
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.HubPipeline.AddModule(new LoggingPipelineModule());

            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
