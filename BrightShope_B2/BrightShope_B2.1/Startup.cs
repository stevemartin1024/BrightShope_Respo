using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrightShope_B2._1.Startup))]
namespace BrightShope_B2._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
