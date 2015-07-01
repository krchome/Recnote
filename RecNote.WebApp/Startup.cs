using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecNote.WebApp.Startup))]
namespace RecNote.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
