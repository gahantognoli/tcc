using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public ActionResult Novo(Guid representadaId)
        {
            ViewBag.RepresentadaId = representadaId;
            return View();
        }

        [HttpPost]
        public ActionResult Novo(ProdutoViewModel produtoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produtoRetorno = _produtoAppService.Adicionar(produtoViewModel);
                    if (produtoRetorno.ValidationResult.IsValid)
                    {
                        TempData["CadastradoSucesso"] = "Produto " + produtoViewModel. Nome +
                              " cadastrado com sucesso";
                        return RedirectToAction("Painel", "Representada", new { id = produtoViewModel.RepresentadaId });
                    }
                    produtoViewModel.ValidationResult = produtoRetorno.ValidationResult;
                }
                ViewBag.RepresentadaId = produtoViewModel.RepresentadaId;
                return View(produtoViewModel);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ActionResult Detalhes(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProdutoViewModel produto = _produtoAppService.ObterPorId((Guid)id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        public ActionResult Alterar(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProdutoViewModel produto = _produtoAppService.ObterPorId((Guid)id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(ProdutoViewModel produtoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produto = _produtoAppService.Atualizar(produtoViewModel);
                    if (produto.ValidationResult.IsValid)
                    {
                        TempData["AtualizadoSucesso"] = "Produto " + produtoViewModel.Nome +
                              " alterado com sucesso";
                        return RedirectToAction("Painel", "Representada", new { id = produtoViewModel.RepresentadaId });
                    }
                    produtoViewModel.ValidationResult = produto.ValidationResult;
                }
                return View(produtoViewModel);
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

            ProdutoViewModel produto = _produtoAppService.ObterPorId((Guid)id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        [HttpPost]
        public ActionResult Remover(Guid id)
        {
            try
            {
                var produto = _produtoAppService.Remover(id);
                if (produto.ValidationResult.IsValid)
                {
                    TempData["RemovidoSucesso"] = "Produto removido com sucesso";
                    return RedirectToAction("Painel", "Representada", new { id = produto.RepresentadaId });
                }
                else
                {
                    TempData["FalhaRemover"] = produto.ValidationResult.Erros.FirstOrDefault().Message;
                    return View(produto);
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
                _produtoAppService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}