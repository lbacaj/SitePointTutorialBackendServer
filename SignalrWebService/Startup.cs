using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using System.Threading.Tasks;
using Microsoft.Owin;
using SignalrWebService.Performance;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(SignalrWebService.Startup))]

namespace SignalrWebService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            app.MapSignalR(hubConfiguration);


            PerformanceEngine performanceEngine = new PerformanceEngine(800);
            Task.Factory.StartNew(async () => await performanceEngine.OnPerformanceMonitor());
        }
    }
}