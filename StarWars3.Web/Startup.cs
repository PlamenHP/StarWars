
using Microsoft.Owin;
using Owin;
using StarWars3.Data;

[assembly: OwinStartupAttribute(typeof(StarWars3.Web.Startup))]
namespace StarWars3.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            //var context = new StarWars3Context();
            //context.Database.Initialize(true);
        }
    }
}
