using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Recnote.Startup))]
namespace Recnote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
