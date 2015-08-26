using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(disk.web.Startup))]
namespace disk.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
