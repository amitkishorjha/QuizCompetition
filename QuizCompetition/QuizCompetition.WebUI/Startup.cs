using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(School.WebUI.SMHS.Startup))]
namespace School.WebUI.SMHS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
