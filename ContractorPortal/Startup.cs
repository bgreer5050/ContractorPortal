using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContractorPortal.Startup))]
namespace ContractorPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
