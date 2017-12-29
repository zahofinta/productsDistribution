using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductsDistribution.Startup))]
namespace ProductsDistribution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
