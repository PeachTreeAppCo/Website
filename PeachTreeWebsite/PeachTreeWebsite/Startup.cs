using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeachTreeWebsite.Startup))]
namespace PeachTreeWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
