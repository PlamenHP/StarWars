using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StarWars3.Web.Startup))]
namespace StarWars3.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
