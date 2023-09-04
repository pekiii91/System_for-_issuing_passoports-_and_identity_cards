using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DokumentaPasos.Startup))]
namespace DokumentaPasos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
