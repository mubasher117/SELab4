using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTemp.Startup))]
namespace WebTemp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
