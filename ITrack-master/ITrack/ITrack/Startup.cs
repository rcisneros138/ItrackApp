using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITrack.Startup))]
namespace ITrack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
