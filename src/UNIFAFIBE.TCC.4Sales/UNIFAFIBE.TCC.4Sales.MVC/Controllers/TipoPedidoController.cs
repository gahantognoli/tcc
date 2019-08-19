using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class TipoPedidoController : Controller
    {

        private readonly ITipoPedidoAppService _tipoPedidoAppService;
        private readonly IEntitySerializationServices<IEnumerable<TipoPedidoViewModel>> _serializationColecaoTipoPedidoServices;
        private readonly IEntitySerializationServices<TipoPedidoViewModel> _serializationTipoPedidoService;

        public TipoPedidoController(ITipoPedidoAppService tipoPedidoAppService,
            IEntitySerializationServices<IEnumerable<TipoPedidoViewModel>> serializationColecaoTipoPedidoServices,
            IEntitySerializationServices<TipoPedidoViewModel> serializationTipoPedidoService)
        {
            _tipoPedidoAppService = tipoPedidoAppService;
            _serializationColecaoTipoPedidoServices = serializationColecaoTipoPedidoServices;
            _serializationTipoPedidoService = serializationTipoPedidoService;
        }

        [HttpGet]
        public JsonResult Listar()
        {
            var json = _serializationColecaoTipoPedidoServices.Serialize(_tipoPedidoAppService.ObterTodos());
            return Json(new { tipoPedido = json }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Novo(string descricao)
        {
            TipoPedidoViewModel tipoPedido = new TipoPedidoViewModel();
            tipoPedido.Descricao = descricao;

            var statusRetorno = _tipoPedidoAppService.Adicionar(tipoPedido);
            var json = _serializationTipoPedidoService.Serialize(statusRetorno);

            return Json(new { tipoPedido = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Alterar(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TipoPedidoViewModel tipoPedidoViewModel = _tipoPedidoAppService.ObterPorId((Guid)id);

            if (tipoPedidoViewModel == null)
                return HttpNotFound();

            return View(tipoPedidoViewModel);
        }

        [HttpPost]
        public ActionResult Alterar(TipoPedidoViewModel tipoPedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tipoPedidoAppService.Atualizar(tipoPedido);
                    TempData["AtualizadoSucesso"] = "Status " + tipoPedido.Descricao +
                      " alterado com sucesso";
                    return RedirectToAction("Index", "PainelAdministrativo");
                }

                return View(tipoPedido);
            }
            catch (Exception)
            {
                return View(tipoPedido);
            }
        }

        public ActionResult Remover(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TipoPedidoViewModel tipoPedidoViewModel = _tipoPedidoAppService.ObterPorId((Guid)id);

            if (tipoPedidoViewModel == null)
                return HttpNotFound();

            return View(tipoPedidoViewModel);
        }

        [HttpPost]
        public ActionResult Remover(Guid id)
        {
            try
            {
                _tipoPedidoAppService.Remover(id);
                TempData["RemovidoSucesso"] = "Status removido com sucesso";
                return RedirectToAction("Index", "PainelAdministrativo");
            }
            catch (Exception)
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tipoPedidoAppService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}