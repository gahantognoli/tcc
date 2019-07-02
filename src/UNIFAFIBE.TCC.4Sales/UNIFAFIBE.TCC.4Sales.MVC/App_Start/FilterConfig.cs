using System.Web;
using System.Web.Mvc;

namespace UNIFAFIBE.TCC._4Sales.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
