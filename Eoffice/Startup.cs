using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eoffice.Startup))]
namespace Eoffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
