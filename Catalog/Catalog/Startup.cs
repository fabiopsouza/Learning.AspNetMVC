using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Catalog.Startup))]
namespace Catalog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
