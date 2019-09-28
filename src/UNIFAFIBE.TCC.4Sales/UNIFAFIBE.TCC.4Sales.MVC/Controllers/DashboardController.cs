using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboardAppService _dashboardAppService;

        public DashboardController(IDashboardAppService dashboardAppService)
        {
            _dashboardAppService = dashboardAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDados(int ano, int mes)
        {
            var meta = _dashboardAppService.ObterMeta(ano, mes);
            var totalReceber = _dashboardAppService.ObterTotalAReceber(ano, mes);
            var totalFaturado = _dashboardAppService.ObterTotalFaturamento(ano, mes);
            var dados = new
            {
                meta = meta,
                totalReceber = totalReceber,
                totalFaturado = totalFaturado
            };
            return Json(dados, JsonRequestBehavior.AllowGet);
        }
    }
}