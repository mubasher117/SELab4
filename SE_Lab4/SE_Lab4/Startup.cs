using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SE_Lab4.Startup))]
namespace SE_Lab4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
