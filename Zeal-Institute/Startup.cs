using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zeal_Institute.Startup))]
namespace Zeal_Institute
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
