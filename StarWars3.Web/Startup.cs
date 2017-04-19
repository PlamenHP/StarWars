
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Owin;
using Ninject;
using Owin;
using StartWars3.Data.UnitOfWork;
using StarWars3.Data;
using StarWars3.Web.SignalR;

[assembly: OwinStartupAttribute(typeof(StarWars3.Web.Startup))]
namespace StarWars3.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();

            var context = new StarWars3Context();
            context.Database.Initialize(true);
        }
    }
}
