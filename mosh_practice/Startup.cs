using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mosh_practice.Startup))]
namespace mosh_practice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
