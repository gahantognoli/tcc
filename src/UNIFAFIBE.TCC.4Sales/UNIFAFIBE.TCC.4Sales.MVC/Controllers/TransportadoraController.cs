using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.MVC.Filters;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    [Authorize]
    [ClaimsAutorize(ClaimType = ClaimTypes.Role, ClaimValue = "ADM")]
    public class TransportadoraController : Controller
    {
        private readonly ITransportadoraAppService _transportadoraAppService;
        private readonly IEntitySerializationServices<IEnumerable<TransportadoraViewModel>> _entitySerializationServices;

        public TransportadoraController(ITransportadoraAppService transportadoraAppService,
            IEntitySerializationServices<IEnumerable<TransportadoraViewModel>> entitySerializationServices)
        {
            _transportadoraAppService = transportadoraAppService;
            _entitySerializationServices = entitySerializationServices;
        }

        public ActionResult Listar()
        {
            var json = _entitySerializationServices.Serialize(_transportadoraAppService.ObterTodos());
            return Json(new { transportadora = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PesquisarNome(string nome)
        {
            var json = _entitySerializationServices.Serialize(_transportadoraAppService.ObterPorNome(nome));
            return Json(new { transportadora = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Novo()
        {            
            return View();
        }
        
        [HttpPost]
        public ActionResult Novo(TransportadoraViewModel transportadoraViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var transportadoraRetorno = _transportadoraAppService.Adicionar(transportadoraViewModel);
                    TempData["CadastradoSucesso"] = "Transportadora " + transportadoraViewModel.Nome + 
                        " cadastrada com sucesso";
                    return RedirectToAction("Index", "PainelAdministrativo");
                }
                return View(transportadoraViewModel);
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

            TransportadoraViewModel transportadoraViewModel = _transportadoraAppService.ObterPorId((Guid)id);

            if (transportadoraViewModel == null)
                return HttpNotFound();

            return View(transportadoraViewModel);
        }

        public ActionResult Alterar(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TransportadoraViewModel transportadoraViewModel = _transportadoraAppService.ObterPorId((Guid)id);

            if (transportadoraViewModel == null)
                return HttpNotFound();

            return View(transportadoraViewModel);
        }

        [HttpPost]
        public ActionResult Alterar(TransportadoraViewModel transportadoraViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _transportadoraAppService.Atualizar(transportadoraViewModel);
                    TempData["AtualizadoSucesso"] = "Transportadora " + transportadoraViewModel.Nome +
                      " alterada com sucesso";
                    return RedirectToAction("Index", "PainelAdministrativo");
                }

                return View(transportadoraViewModel);
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

            TransportadoraViewModel transportadoraViewModel = _transportadoraAppService.ObterPorId((Guid)id);

            if (transportadoraViewModel == null)
                return HttpNotFound();

            return View(transportadoraViewModel);
        }

        [HttpPost]
        public ActionResult Remover(Guid id)
        {
            try
            {
                var transportadoraRetorno = _transportadoraAppService.Remover(id);
                if (transportadoraRetorno.ValidationResult.IsValid)
                {
                    TempData["RemovidoSucesso"] = "Transportadora removida com sucesso";
                    return RedirectToAction("Index", "PainelAdministrativo");
                }
                else
                {
                    TempData["FalhaRemover"] = transportadoraRetorno.ValidationResult.Erros.FirstOrDefault().Message;
                    return View(transportadoraRetorno);
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
                _transportadoraAppService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}