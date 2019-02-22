using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DLOA.UI.Startup))]
namespace DLOA.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
