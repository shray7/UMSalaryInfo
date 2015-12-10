using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UMSalaryInfo.Startup))]
namespace UMSalaryInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
