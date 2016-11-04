using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vape4Life.Startup))]
namespace Vape4Life
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
