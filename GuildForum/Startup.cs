using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuildForum.Startup))]
namespace GuildForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
