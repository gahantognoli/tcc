using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class MetaController : Controller
    {
        private readonly IMetaAppService _metaAppService;
        private readonly IEntitySerializationServices<IEnumerable<MetaViewModel>> _entitySerializationServices;

        public MetaController(IMetaAppService metaAppService,
            IEntitySerializationServices<IEnumerable<MetaViewModel>> entitySerializationServices)
        {
            _metaAppService = metaAppService;
            _entitySerializationServices = entitySerializationServices;
        }

        public ActionResult Listar()
        {
            var json = _entitySerializationServices.Serialize(_metaAppService.ObterTodos());
            return Json(new { meta = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(MetaViewModel metaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metaRetorno = _metaAppService.Adicionar(metaViewModel);
                    if (metaRetorno.EhValido())
                    {
                        TempData["CadastradoSucesso"] = "Meta cadastrada com sucesso";
                        return RedirectToAction("Index", "PainelAdministrativo");
                    }
                    else
                    {
                        return View(metaRetorno);
                    }
                    
                }
                return View(metaViewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Detalhes(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            MetaViewModel metaViewModel = _metaAppService.ObterPorId((Guid)id);

            if (metaViewModel == null)
                return HttpNotFound();

            return View(metaViewModel);
        }

        public ActionResult Alterar(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            MetaViewModel metaViewModel = _metaAppService.ObterPorId((Guid)id);

            if (metaViewModel == null)
                return HttpNotFound();

            return View(metaViewModel);
        }

        [HttpPost]
        public ActionResult Alterar(MetaViewModel metaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _metaAppService.Atualizar(metaViewModel);
                    TempData["AtualizadoSucesso"] = "Meta alterada com sucesso";
                    return RedirectToAction("Index", "PainelAdministrativo");
                }

                return View(metaViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Remover(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            MetaViewModel metaViewModel = _metaAppService.ObterPorId((Guid)id);

            if (metaViewModel == null)
                return HttpNotFound();

            return View(metaViewModel);
        }

        [HttpPost]
        public ActionResult Remover(Guid id)
        {
            try
            {
                _metaAppService.Remover(id);
                TempData["RemovidoSucesso"] = "Meta removida com sucesso";
                return RedirectToAction("Index", "PainelAdministrativo");
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
                _metaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}