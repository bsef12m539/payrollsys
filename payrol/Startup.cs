using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(payrol.Startup))]
namespace payrol
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
