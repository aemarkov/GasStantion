using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GasStantion.Startup))]
namespace GasStantion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
