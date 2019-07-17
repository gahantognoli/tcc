using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UNIFAFIBE.TCC._4Sales.Aplicacao.AutoMapper;
using UNIFAFIBE.TCC._4Sales.MVC.App_Start;

namespace UNIFAFIBE.TCC._4Sales.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SimpleInjectorInitializer.Initialize();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
