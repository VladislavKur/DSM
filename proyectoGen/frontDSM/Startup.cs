using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(frontDSM.Startup))]
namespace frontDSM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
