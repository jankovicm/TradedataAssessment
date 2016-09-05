using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TradedataAssessment.Startup))]
namespace TradedataAssessment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
