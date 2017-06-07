using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aula0706MVC.Startup))]
namespace Aula0706MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
