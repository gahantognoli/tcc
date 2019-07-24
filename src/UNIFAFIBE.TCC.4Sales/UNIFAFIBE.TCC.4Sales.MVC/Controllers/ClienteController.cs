using System.Collections.Generic;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;
        private readonly IPessoaJuridicaAppService _pessoaJuridicaAppService;

        public ClienteController(IPessoaFisicaAppService pessoaFisicaAppService,
            IPessoaJuridicaAppService pessoaJuridicaAppService)
        {
            _pessoaFisicaAppService = pessoaFisicaAppService;
            _pessoaJuridicaAppService = pessoaJuridicaAppService;
        }

        // GET: Cliente
        public ActionResult Index(string parametro = "", string busca = "")
        {
            ViewBag.Busca = busca;
            ViewBag.Parametro = parametro;

            return View(SearchByParameter(parametro, busca));
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
            }else if(parametro == "nome-fantasia")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    cliente.pessoaJuridicaViewModels = _pessoaJuridicaAppService.ObterPorNomeFantasia(busca);
                    return cliente;
                }
            }else if(parametro == "inscricao-estadual")
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


    }
}