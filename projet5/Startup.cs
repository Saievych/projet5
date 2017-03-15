using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projet5.Startup))]
namespace projet5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
