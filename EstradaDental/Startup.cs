using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EstradaDental.Startup))]
namespace EstradaDental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
