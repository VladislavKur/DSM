using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoDSM.Startup))]
namespace ProyectoDSM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
