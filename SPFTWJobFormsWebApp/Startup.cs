using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SPFTWJobFormsWebApp.Startup))]
namespace SPFTWJobFormsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
