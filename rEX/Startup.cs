using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rEX.Startup))]
namespace rEX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
