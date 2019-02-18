using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DavesTools.Startup))]
namespace DavesTools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
