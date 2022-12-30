using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(stock_management.Startup))]
namespace stock_management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
