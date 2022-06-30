using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainersMVC.Startup))]
namespace TrainersMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
