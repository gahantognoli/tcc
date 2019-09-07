using System;
using System.Net;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class FaturamentoController : Controller
    {
        private readonly IFaturamentoAppService _faturamentoAppService;
        private readonly IPedidoAppService _pedidoAppService;

        public FaturamentoController(IFaturamentoAppService faturamentoAppService,
            IPedidoAppService pedidoAppService)
        {
            _faturamentoAppService = faturamentoAppService;
            _pedidoAppService = pedidoAppService;
        }

        public ActionResult Detalhes(Guid id, Guid pedidoId)
        {
            ViewBag.Pedido = _pedidoAppService.ObterPorId(pedidoId);
            return View(_faturamentoAppService.ObterPorId(id));
        }

        public ActionResult Remover(Guid? id, Guid pedidoId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Pedido = _pedidoAppService.ObterPorId(pedidoId);
            return View(_faturamentoAppService.ObterPorId((Guid)id));
        }

        [HttpPost]
        public ActionResult Remover(Guid id, Guid pedidoId)
        {
            _faturamentoAppService.Remover(id, pedidoId);
            TempData["Removido"] = "Faturamento removido com sucesso!";
            return RedirectToAction("Acoes", "Pedido", new { id = pedidoId });
        }

    }
}