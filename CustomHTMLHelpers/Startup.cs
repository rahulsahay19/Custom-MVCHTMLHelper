using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomHTMLHelpers.Startup))]
namespace CustomHTMLHelpers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
