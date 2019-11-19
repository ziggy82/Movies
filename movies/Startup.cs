using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(movies.Startup))]
namespace movies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
