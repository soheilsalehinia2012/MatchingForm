using System;
using Microsoft.Owin;
using Owin;
using SampleDb;

[assembly: OwinStartupAttribute(typeof(RoomMateMatching.Startup))]
namespace RoomMateMatching
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DataCollector.CreateDb();
            ConfigureAuth(app);
        }
    }
}
