using System.Security.Claims;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.MVC.Filters;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    [Authorize]
    [ClaimsAutorize(ClaimType = ClaimTypes.Role, ClaimValue = "ADM")]
    public class PainelAdministrativoController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
    }
}