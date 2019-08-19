﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class StatusPedidoController : Controller
    {
        private readonly IStatusPedidoAppService _statusPedidoAppService;
        private readonly IEntitySerializationServices<IEnumerable<StatusPedidoViewModel>> _serializationColecaoStatusServices;
        private readonly IEntitySerializationServices<StatusPedidoViewModel> _serializationStatusService;

        public StatusPedidoController(IStatusPedidoAppService statusPedidoAppService,
            IEntitySerializationServices<IEnumerable<StatusPedidoViewModel>> entitySerializationServices,
            IEntitySerializationServices<StatusPedidoViewModel> entitySerializationService)
        {
            _statusPedidoAppService = statusPedidoAppService;
            _serializationColecaoStatusServices = entitySerializationServices;
            _serializationStatusService = entitySerializationService;
        }

        [HttpGet]
        public JsonResult Listar()
        {
            var json = _serializationColecaoStatusServices.Serialize(_statusPedidoAppService.ObterTodos());
            return Json(new { statusPedido = json }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Novo(string descricao)
        {
            StatusPedidoViewModel statusPedido = new StatusPedidoViewModel();
            statusPedido.Descricao = descricao;

            var statusRetorno = _statusPedidoAppService.Adicionar(statusPedido);
            var json = _serializationStatusService.Serialize(statusRetorno);

            return Json(new { statusPedido = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Alterar(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StatusPedidoViewModel statusPedidoViewModel = _statusPedidoAppService.ObterPorId((Guid)id);

            if (statusPedidoViewModel == null)
                return HttpNotFound();

            return View(statusPedidoViewModel);
        }

        [HttpPost]
        public ActionResult Alterar(StatusPedidoViewModel statusPedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _statusPedidoAppService.Atualizar(statusPedido);
                    TempData["AtualizadoSucesso"] = "Status " + statusPedido.Descricao +
                      " alterado com sucesso";
                    return RedirectToAction("Index", "PainelAdministrativo");
                }

                return View(statusPedido);
            }
            catch (Exception)
            {
                return View(statusPedido);
            }
        }

        public ActionResult Remover(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StatusPedidoViewModel statusPedidoViewModel = _statusPedidoAppService.ObterPorId((Guid)id);

            if (statusPedidoViewModel == null)
                return HttpNotFound();

            return View(statusPedidoViewModel);
        }

        [HttpPost]
        public ActionResult Remover(Guid id)
        {
            try
            {
                _statusPedidoAppService.Remover(id);
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
                _statusPedidoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}