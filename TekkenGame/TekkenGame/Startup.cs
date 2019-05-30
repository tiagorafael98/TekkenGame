using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TekkenGame.Startup))]
namespace TekkenGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
