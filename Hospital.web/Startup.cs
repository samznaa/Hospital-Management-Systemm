using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hospital.web.Startup))]
namespace Hospital.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
