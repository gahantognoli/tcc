using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;
        private readonly IPessoaJuridicaAppService _pessoaJuridicaAppService;
        private readonly ISegmentoAppService _segmentoAppService;

        public ClienteController(IPessoaFisicaAppService pessoaFisicaAppService,
            IPessoaJuridicaAppService pessoaJuridicaAppService,
            ISegmentoAppService segmentoAppService)
        {
            _pessoaFisicaAppService = pessoaFisicaAppService;
            _pessoaJuridicaAppService = pessoaJuridicaAppService;
            _segmentoAppService = segmentoAppService;
        }

        public ActionResult Index(string parametro = "", string busca = "")
        {
            ViewBag.Busca = busca;
            ViewBag.Parametro = parametro;

            return View(SearchByParameter(parametro, busca));
        }

        public ActionResult Novo()
        {
            PopularViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovaPessoaJuridica(ClientePFPJCadastroViewModel clientePFPJCadastroViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pessoaJuridicaRetorno = _pessoaJuridicaAppService.Adicionar(clientePFPJCadastroViewModel.pessoaJuridicaViewModels);
                    if (pessoaJuridicaRetorno.ValidationResult.IsValid)
                    {
                        TempData["CadastradoSucesso"] = "Cliente " + clientePFPJCadastroViewModel.pessoaJuridicaViewModels.RazaoSocial +
                              " cadastrado com sucesso";
                        return RedirectToAction("Index", "Cliente");
                    }
                    clientePFPJCadastroViewModel.pessoaJuridicaViewModels.ValidationResult = pessoaJuridicaRetorno.ValidationResult;
                }
                PopularViewBag();
                return View("Novo", clientePFPJCadastroViewModel);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovaPessoaFisica(ClientePFPJCadastroViewModel clientePFPJCadastroViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pessoaJuridicaRetorno = _pessoaFisicaAppService.Adicionar(clientePFPJCadastroViewModel.pessoaFisicaViewModels);
                    if (pessoaJuridicaRetorno.ValidationResult.IsValid)
                    {
                        TempData["CadastradoSucesso"] = "Cliente " + clientePFPJCadastroViewModel.pessoaFisicaViewModels.Nome +
                              " cadastrado com sucesso";
                        return RedirectToAction("Index", "Cliente");
                    }
                    PopularViewBag();
                    clientePFPJCadastroViewModel.pessoaFisicaViewModels.ValidationResult = pessoaJuridicaRetorno.ValidationResult;
                    return View("Novo", clientePFPJCadastroViewModel);
                }
                PopularViewBag();
                return View("Novo", clientePFPJCadastroViewModel);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult DetalhesPessoaFisica(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PessoaFisicaViewModel pessoaFisicaViewModel = _pessoaFisicaAppService.ObterPorId((Guid)id);

            if (pessoaFisicaViewModel == null)
                return HttpNotFound();

            return View(pessoaFisicaViewModel);
        }

        public ActionResult DetalhesPessoaJuridica(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PessoaJuridicaViewModel pessoaJuridicaViewModel = _pessoaJuridicaAppService.ObterPorId((Guid)id);

            if (pessoaJuridicaViewModel == null)
                return HttpNotFound();

            return View(pessoaJuridicaViewModel);
        }

        public ActionResult AlterarPessoaJuridica(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PessoaJuridicaViewModel pessoaJuridicaViewModel = _pessoaJuridicaAppService.ObterPorId((Guid)id);

            if (pessoaJuridicaViewModel == null)
                return HttpNotFound();

            PopularViewBag();
            return View("AlterarPessoaJuridica",pessoaJuridicaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarPessoaJuridica(PessoaJuridicaViewModel pessoaJuridicaViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var pessoaJuridicaRetorno = _pessoaJuridicaAppService.Atualizar(pessoaJuridicaViewModel);
                    if (pessoaJuridicaRetorno.ValidationResult.IsValid)
                    {
                        TempData["AtualizadoSucesso"] = "Cliente " + pessoaJuridicaViewModel.RazaoSocial +
                              " alterado com sucesso";
                        return RedirectToAction("Index", "Cliente");
                    }
                    pessoaJuridicaViewModel.ValidationResult = pessoaJuridicaRetorno.ValidationResult;
                }
                pessoaJuridicaViewModel.Segmento = _segmentoAppService.ObterPorId(pessoaJuridicaViewModel.SegmentoId);
                PopularViewBag();
                return View("AlterarPessoaJuridica", pessoaJuridicaViewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult AlterarPessoaFisica(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PessoaFisicaViewModel pessoaFisicaViewModel = _pessoaFisicaAppService.ObterPorId((Guid)id);

            if (pessoaFisicaViewModel == null)
                return HttpNotFound();

            PopularViewBag();
            return View(pessoaFisicaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarPessoaFisica(PessoaFisicaViewModel pessoaFisicaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pessoaFisicaRetorno = _pessoaFisicaAppService.Atualizar(pessoaFisicaViewModel);
                    if (pessoaFisicaRetorno.ValidationResult.IsValid)
                    {
                        TempData["AtualizadoSucesso"] = "Cliente " + pessoaFisicaViewModel.Nome +
                              " alterado com sucesso";
                        return RedirectToAction("Index", "Cliente");
                    }
                    pessoaFisicaViewModel.ValidationResult = pessoaFisicaRetorno.ValidationResult;
                }
                pessoaFisicaViewModel.Segmento = _segmentoAppService.ObterPorId(pessoaFisicaViewModel.SegmentoId);
                PopularViewBag();
                return View(pessoaFisicaViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult RemoverPessoaFisica(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pessoaFisica = _pessoaFisicaAppService.ObterPorId((Guid)id);

            if (pessoaFisica == null)
                HttpNotFound();

            return View(pessoaFisica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoverPessoaFisica(Guid id)
        {
            try
            {
                _pessoaFisicaAppService.Remover(id);
                TempData["RemovidoSucesso"] = "Cliente removido com sucesso";
                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ActionResult RemoverPessoaJuridica(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pessoaJuridica = _pessoaJuridicaAppService.ObterPorId((Guid)id);

            if (pessoaJuridica == null)
                HttpNotFound();

            return View(pessoaJuridica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoverPessoaJuridica(Guid id)
        {
            try
            {
                _pessoaJuridicaAppService.Remover(id);
                TempData["RemovidoSucesso"] = "Cliente removido com sucesso";
                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private ClientePFPJViewModel SearchByParameter(string parametro = "", string busca = "")
        {
            ClientePFPJViewModel cliente = new ClientePFPJViewModel();

            if (parametro == "cpf")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    cliente.pessoaFisicaViewModels = _pessoaFisicaAppService.ObterPorCPF(busca);
                    return cliente;
                }
            }
            else if (parametro == "nome")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    cliente.pessoaFisicaViewModels = _pessoaFisicaAppService.ObterPorNome(busca);
                    return cliente;
                }
            }
            else if (parametro == "cnpj")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    cliente.pessoaJuridicaViewModels = _pessoaJuridicaAppService.ObterPorCPNJ(busca);
                    return cliente;
                }
            }
            else if (parametro == "razao-social")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    cliente.pessoaJuridicaViewModels = _pessoaJuridicaAppService.ObterPorRazaoSocial(busca);
                    return cliente;
                }
            }
            else if (parametro == "nome-fantasia")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    cliente.pessoaJuridicaViewModels = _pessoaJuridicaAppService.ObterPorNomeFantasia(busca);
                    return cliente;
                }
            }
            else if (parametro == "inscricao-estadual")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    cliente.pessoaJuridicaViewModels = _pessoaJuridicaAppService.ObterPorInscricaoEstadual(busca);
                    return cliente;
                }
            }

            cliente.pessoaFisicaViewModels = _pessoaFisicaAppService.ObterTodos() as List<PessoaFisicaViewModel>;
            cliente.pessoaJuridicaViewModels = _pessoaJuridicaAppService.ObterTodos() as List<PessoaJuridicaViewModel>;

            return cliente;
        }

        public JsonResult ConsultarCEP(string cep, string id)
        {
            var url = "https://viacep.com.br/ws/" + cep.Trim() + "/json/";
            var requisicao = WebRequest.CreateHttp(url);
            requisicao.Method = "GET";
            var dados = "";
            using (var resposta = requisicao.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                dados = reader.ReadToEnd();
            }
            return Json(new { retorno = dados, id = id }, JsonRequestBehavior.AllowGet);
        }

        private void PopularViewBag()
        {
            ViewBag.Segmento = new SelectList(_segmentoAppService.ObterTodos(), "SegmentoId", "Descricao");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pessoaFisicaAppService.Dispose();
                _pessoaJuridicaAppService.Dispose();
                _segmentoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}