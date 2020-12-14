using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrueCrimeRepo.WebMVC.Startup))]
namespace TrueCrimeRepo.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
