using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurveyApplication.Startup))]
namespace SurveyApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
