using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TabMe.Startup))]
namespace TabMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
