using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectTAMA.Startup))]
namespace ProjectTAMA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
