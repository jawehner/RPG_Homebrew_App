using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeBrewApp.Startup))]
namespace HomeBrewApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
