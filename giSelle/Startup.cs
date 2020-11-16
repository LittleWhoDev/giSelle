using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(giSelle.Startup))]
namespace giSelle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
