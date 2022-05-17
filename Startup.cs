using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionarVE.Startup))]
namespace GestionarVE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
