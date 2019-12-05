using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDotnetProject.Startup))]
namespace MVCDotnetProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
