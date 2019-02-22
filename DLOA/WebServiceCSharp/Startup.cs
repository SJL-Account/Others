using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebServiceCSharp.Startup))]
namespace WebServiceCSharp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
