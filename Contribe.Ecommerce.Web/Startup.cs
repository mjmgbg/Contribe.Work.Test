using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contribe.Ecommerce.Web.Startup))]
namespace Contribe.Ecommerce.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
