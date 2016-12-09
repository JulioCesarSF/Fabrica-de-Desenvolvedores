using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fiap.Exemplo05.MVC.Web.Startup))]
namespace Fiap.Exemplo05.MVC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
