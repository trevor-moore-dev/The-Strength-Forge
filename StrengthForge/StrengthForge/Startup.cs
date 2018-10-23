using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StrengthForge.Startup))]
namespace StrengthForge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
