using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class SegmentoController : Controller
    {
        private readonly ISegmentoAppService _segmentoAppService;
        private readonly IEntitySerializationServices<IEnumerable<SegmentoViewModel>> _serializationColecaSegmentosServices;
        private readonly IEntitySerializationServices<SegmentoViewModel> _serializationSegmentosService;

        public SegmentoController(ISegmentoAppService segmentoAppService,
            IEntitySerializationServices<IEnumerable<SegmentoViewModel>> serializationColecaSegmentosServices,
            IEntitySerializationServices<SegmentoViewModel> serializationSegmentosService)
        {
            _segmentoAppService = segmentoAppService;
            _serializationColecaSegmentosServices = serializationColecaSegmentosServices;
            _serializationSegmentosService = serializationSegmentosService;
        }

        [HttpGet]
        public JsonResult Listar()
        {
            var json = _serializationColecaSegmentosServices.Serialize(_segmentoAppService.ObterTodos());
            return Json(new { segmento = json }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Novo(string descricao)
        {
            SegmentoViewModel segmento = new SegmentoViewModel();
            segmento.Descricao = descricao;

            var segmentoRetorno = _segmentoAppService.Adicionar(segmento);
            var json = _serializationSegmentosService.Serialize(segmentoRetorno);

            return Json(new { segmento = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Alterar(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            SegmentoViewModel segmentoViewModel = _segmentoAppService.ObterPorId((Guid)id);

            if (segmentoViewModel == null)
                return HttpNotFound();

            return View(segmentoViewModel);
        }

        [HttpPost]
        public ActionResult Alterar(SegmentoViewModel segmento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _segmentoAppService.Atualizar(segmento);
                    TempData["AtualizadoSucesso"] = "Segmento " + segmento.Descricao +
                      " alterado com sucesso";
                    return RedirectToAction("Index", "Cliente");
                }

                return View(segmento);
            }
            catch (Exception e)
            {
                return View(segmento);
            }
        }

        public ActionResult Remover(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            SegmentoViewModel segmentoViewModel = _segmentoAppService.ObterPorId((Guid)id);

            if (segmentoViewModel == null)
                return HttpNotFound();

            return View(segmentoViewModel);
        }

        [HttpPost]
        public ActionResult Remover(Guid id)
        {
            try
            {
                var segmentoRetorno = _segmentoAppService.Remover(id);
                if (segmentoRetorno.ValidationResult.IsValid)
                {
                    TempData["RemovidoSucesso"] = "Segmento removido com sucesso";
                    return RedirectToAction("Index", "Cliente");
                }
                else
                {
                    TempData["FalhaRemover"] = segmentoRetorno.ValidationResult.Erros.FirstOrDefault().Message;
                    return View(segmentoRetorno);
                }
                
            }
            catch (Exception e)
            {
                throw;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _segmentoAppService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}