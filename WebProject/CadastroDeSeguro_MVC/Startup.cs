using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CadastroDeSeguro_MVC.Startup))]
namespace CadastroDeSeguro_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
