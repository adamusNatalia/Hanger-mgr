using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hanger.Startup))]
namespace Hanger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
