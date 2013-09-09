using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Cards.Presentation.Core;
using Microsoft.AspNet.SignalR;

namespace Cards.Presentation
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Initialization.Initialize();

            var hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = true
            };
            RouteTable.Routes.MapHubs(hubConfiguration);
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            

        }
    }
}