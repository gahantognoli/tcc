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
    public class RepresentadaController : Controller
    {
        private readonly IRepresentadaAppService _representadaAppService;
        private readonly IEntitySerializationServices<IEnumerable<RepresentadaViewModel>> _serializationColecaoRepresentadaServices;
        private readonly IEntitySerializationServices<RepresentadaViewModel> _serializationRepresentadaService;
        private readonly IProdutoAppService _produtoAppService;
        private readonly IEntitySerializationServices<IEnumerable<ProdutoViewModel>> _serializationProdutoservice;

        public RepresentadaController(IRepresentadaAppService representadaAppService,
            IEntitySerializationServices<IEnumerable<RepresentadaViewModel>> serializationColecaoRepresentadaServices,
            IEntitySerializationServices<RepresentadaViewModel> serializationRepresentadaService,
            IProdutoAppService produtoAppService, IEntitySerializationServices<IEnumerable<ProdutoViewModel>> serializationProdutoservice)
        {
            _representadaAppService = representadaAppService;
            _serializationRepresentadaService = serializationRepresentadaService;
            _serializationColecaoRepresentadaServices = serializationColecaoRepresentadaServices;
            _produtoAppService = produtoAppService;
            _serializationProdutoservice = serializationProdutoservice;
        }

        public ActionResult Index(string parametro = "", string busca = "")
        {
            ViewBag.Busca = busca;
            ViewBag.Parametro = parametro;

            return View(SearchByParameter(parametro, busca));
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(RepresentadaViewModel representadaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var representadaRetorno = _representadaAppService.Adicionar(representadaViewModel);
                    if (representadaRetorno.ValidationResult.IsValid)
                    {
                        TempData["CadastradoSucesso"] = "Representada " + representadaRetorno.RazaoSocial +
                              " cadastrada com sucesso";
                        return RedirectToAction("Index", "Representada");
                    }
                    representadaViewModel.ValidationResult = representadaRetorno.ValidationResult;
                }
                return View("Novo", representadaViewModel);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ActionResult Atualizar(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            RepresentadaViewModel representada = _representadaAppService.ObterPorId((Guid)id);

            if (representada == null)
                return HttpNotFound();

            return View(representada);
        }

        [HttpPost]
        public ActionResult Atualizar(RepresentadaViewModel representadaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var representadaRetorno = _representadaAppService.Atualizar(representadaViewModel);
                    if (representadaRetorno.ValidationResult.IsValid)
                    {
                        TempData["AtualizadoSucesso"] = "Representada " + representadaRetorno.RazaoSocial +
                              " atualizada com sucesso";
                        return RedirectToAction("Index", "Representada");
                    }
                    representadaViewModel.ValidationResult = representadaRetorno.ValidationResult;
                }
                return View("Atualizar", representadaViewModel);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ActionResult Remover(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var representada = _representadaAppService.ObterPorId((Guid)id);

            if (representada == null)
                HttpNotFound();

            return View(representada);
        }

        [HttpPost]
        public ActionResult Remover(Guid id)
        {
            try
            {
                _representadaAppService.Remover(id);
                TempData["RemovidoSucesso"] = "Representada removida com sucesso";
                return RedirectToAction("Index", "Representada");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        public JsonResult DetalhesRepresentada(Guid representadaId)
        {
            if (representadaId != null)
            {
                var representada = _representadaAppService.ObterPorId(representadaId);
                var json = _serializationRepresentadaService.Serialize(representada);

                return Json(new { representada = json }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { representada = "" }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Painel(Guid Id)
        {
            ViewBag.IdRepresentada = Id;
            return View();
        }

        public JsonResult Listar(Guid representadaId, string ordemAlfabetica, string ordemPreco,
            string parametro = "", string busca = "")
        {
            return PesquisarProdutoPorParametro(representadaId, parametro, busca, ordemAlfabetica, ordemPreco);
        }

        public JsonResult PesquisarProdutoPorParametro(Guid representadaId, string parametro, string busca,
            string ordemAlfabetica, string ordemPreco)
        {
            var json = "";
            if (representadaId != null)
            {
                if (parametro == "")
                {
                    var produto = Ordenar(_produtoAppService.ObterTodos(representadaId), ordemAlfabetica, ordemPreco);
                    json = _serializationProdutoservice.Serialize(produto);
                }
                else if (parametro == "nome")
                {
                    var produto = Ordenar(_produtoAppService.ObterPorNome(busca, representadaId), ordemAlfabetica, 
                        ordemPreco);
                    json = _serializationProdutoservice.Serialize(produto);
                }

            }
            return Json(new { produtos = json }, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<ProdutoViewModel> Ordenar(IEnumerable<ProdutoViewModel> lista, string OrdemAlfabetica,
            string Preco)
        {
            IEnumerable<ProdutoViewModel> listaRetorno = new List<ProdutoViewModel>();
            if (OrdemAlfabetica == "Crescente")
            {
                if (Preco == "MaiorPreco")
                {
                    listaRetorno = lista.ToList().OrderBy(p => p.Nome).ThenByDescending(p => p.Preco);
                }
                else if (Preco == "MenorPreco")
                {
                    listaRetorno = lista.ToList().OrderBy(p => p.Nome).ThenBy(p => p.Preco);
                }
                else 
                {
                    listaRetorno = lista.ToList().OrderBy(p => p.Nome);
                }
                return listaRetorno;
            }

            if (OrdemAlfabetica == "Decrescente")
            {
                if (Preco == "MaiorPreco")
                {
                    listaRetorno = lista.ToList().OrderByDescending(p => p.Nome).ThenByDescending(p => p.Preco);
                }
                else if (Preco == "MenorPreco")
                {
                    listaRetorno = lista.ToList().OrderByDescending(p => p.Nome).ThenBy(p => p.Preco);
                }else
                {
                    listaRetorno = lista.ToList().OrderByDescending(p => p.Nome);
                }
                return listaRetorno;
            }

            if (OrdemAlfabetica == "")
            {
                if (Preco == "MaiorPreco")
                {
                    listaRetorno = lista.ToList().OrderByDescending(p => p.Preco);
                }
                else if (Preco == "MenorPreco")
                {
                    listaRetorno = lista.ToList().OrderBy(p => p.Preco);
                }
                else
                {
                    listaRetorno = lista;
                }

                return listaRetorno;
            }

            return lista;
        }

        public JsonResult ObterProdutosRepresentada(Guid representadaId)
        {

            if (representadaId != null)
            {
                var produto = _produtoAppService.ObterTodos(representadaId);
                var json = _serializationProdutoservice.Serialize(produto);
                return Json(new { produtos = json }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { produtos = "" }, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<RepresentadaViewModel> SearchByParameter(string parametro = "", string busca = "")
        {
            IEnumerable<RepresentadaViewModel> representada = new List<RepresentadaViewModel>();

            if (parametro == "cnpj")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    busca = busca.Replace(".", "").Replace("-", "").Replace("/", "");
                    representada = _representadaAppService.ObterPorCnpj(busca);
                    return representada;
                }
            }
            else if (parametro == "nomeFantasia")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    representada = _representadaAppService.ObterPorNomeFantansia(busca);
                    return representada;
                }
            }
            else if (parametro == "razaoSocial")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    representada = _representadaAppService.ObterPorRazaoSocial(busca);
                    return representada;
                }
            }
            else
            {
                representada = _representadaAppService.ObterTodos();
                return representada;
            }

            return representada;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoAppService.Dispose();
                _representadaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}