using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoomMateMatching.Startup))]
namespace RoomMateMatching
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
