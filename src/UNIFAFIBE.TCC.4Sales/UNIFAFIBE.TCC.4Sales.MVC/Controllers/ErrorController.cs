using System.Web.Mvc;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(int? code)
        {
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }

        public ActionResult NotAccess()
        {
            return View("NotAccess");
        }
    }
}