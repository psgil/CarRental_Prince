using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarRental_Prince.Startup))]
namespace CarRental_Prince
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
