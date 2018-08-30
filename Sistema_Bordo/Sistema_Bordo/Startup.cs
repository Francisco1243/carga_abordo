using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sistema_Bordo.Startup))]
namespace Sistema_Bordo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
