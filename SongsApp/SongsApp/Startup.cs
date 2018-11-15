using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SongsApp.Startup))]
namespace SongsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
