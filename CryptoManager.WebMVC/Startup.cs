using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CryptoManager.WebMVC.Startup))]
namespace CryptoManager.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
