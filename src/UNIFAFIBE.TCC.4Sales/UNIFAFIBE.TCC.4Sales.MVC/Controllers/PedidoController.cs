using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;
using X.PagedList;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoAppService _pedidoAppService;
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;
        private readonly IPessoaJuridicaAppService _pessoaJuridicaAppService;
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IRepresentadaAppService _representadaAppService;
        private readonly IStatusPedidoAppService _statusPedidoAppService;
        private readonly ITipoPedidoAppService _tipoPedidoAppService;
        private readonly ITransportadoraAppService _transportadoraAppService;
        private readonly ICondicaoPagamentoAppService _condicaoPagamentoAppService;
        private readonly IContatoClienteAppService _contatoClienteAppService;
        private readonly IEnderecoClienteAppService _enderecoClienteAppService;
        private readonly IProdutoAppService _produtoAppService;
        private readonly IFaturamentoAppService _faturamentoAppService;
        private readonly IEntitySerializationServices<PedidoViewModel> _entitySerializationServices;


        public PedidoController(IPedidoAppService pedidoAppService, IUsuarioAppService usuarioAppService,
            IRepresentadaAppService representadaAppService, IStatusPedidoAppService statusPedidoAppService,
            ITipoPedidoAppService tipoPedidoAppService, ITransportadoraAppService transportadoraAppService, 
            ICondicaoPagamentoAppService condicaoPagamentoAppService, IContatoClienteAppService contatoClienteAppService,
            IEnderecoClienteAppService enderecoClienteAppService, IPessoaFisicaAppService pessoaFisicaAppService,
            IPessoaJuridicaAppService pessoaJuridicaAppService, IProdutoAppService produtoAppService,
            IFaturamentoAppService faturamentoAppService, IEntitySerializationServices<PedidoViewModel> entitySerializationServices)
        {
            _pedidoAppService = pedidoAppService;
            _usuarioAppService = usuarioAppService;
            _representadaAppService = representadaAppService;
            _statusPedidoAppService = statusPedidoAppService;
            _tipoPedidoAppService = tipoPedidoAppService;
            _transportadoraAppService = transportadoraAppService;
            _condicaoPagamentoAppService = condicaoPagamentoAppService;
            _contatoClienteAppService = contatoClienteAppService;
            _enderecoClienteAppService = enderecoClienteAppService;
            _pessoaFisicaAppService = pessoaFisicaAppService;
            _pessoaJuridicaAppService = pessoaJuridicaAppService;
            _produtoAppService = produtoAppService;
            _faturamentoAppService = faturamentoAppService;
            _entitySerializationServices = entitySerializationServices;
        }

        // GET: Pedido
        public ActionResult Index(string parametro = "", string busca = "", string buscaRepresentada = "", string buscaStatus = "",
            string buscaTipoPedido = "", int pagina = 1, int tamanhoPagina = 20)
        {
            ViewBag.Busca = busca;
            ViewBag.Parametro = parametro;
            PopularViewBag();

            return View(SearchByParameter(parametro, busca, buscaRepresentada, buscaStatus, buscaTipoPedido)
                .ToPagedList(pagina, tamanhoPagina));
        }

        public ActionResult Novo()
        {
            PopularViewBagCadastro();
            return View();
        }

        [HttpPost]
        public JsonResult GerarOrcamento(string pedido)
        {
            var orcamento = _entitySerializationServices.Deserialize(pedido);
            var orcamentoRetorno = _pedidoAppService.GerarOrcamento(orcamento);
            if (orcamentoRetorno.ValidationResult.IsValid)
                TempData["OrcamentoGerado"] = "Orçamento " + orcamento.NumeroPedido +
                              " gerado com sucesso";
            
            return Json(orcamentoRetorno.ValidationResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SalvarOrcamento(string orcamento)
        {
            var orcamentoRetorno = _entitySerializationServices.Deserialize(orcamento);
            orcamentoRetorno = _pedidoAppService.Atualizar(orcamentoRetorno);
            if(orcamentoRetorno.ValidationResult.IsValid)
                TempData["OrcamentoAtualizado"] = "Orçamento " + orcamentoRetorno.NumeroPedido +
                              " atualizado com sucesso";

            return Json(orcamentoRetorno.ValidationResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GerarPedido(string pedido)
        {
            var pedidoDeserializado = _entitySerializationServices.Deserialize(pedido);
            var pedidoRetorno = _pedidoAppService.GerarPedido(pedidoDeserializado);
            if (pedidoRetorno.ValidationResult.IsValid)
                TempData["PedidoGerado"] = "Pedido " + pedidoDeserializado.NumeroPedido +
                              " gerado com com sucesso";

            return Json(pedidoRetorno.ValidationResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Faturar(Guid pedidoId)
        {
            ViewBag.JaFaturado = _faturamentoAppService.ObterTotalFaturamento(pedidoId);
            return View(_pedidoAppService.ObterPorId(pedidoId));
        }

        [HttpPost]
        public JsonResult AlterarStatus(Guid statusId, Guid pedidoId)
        {
            var pedidoRetorno = _pedidoAppService.AlterarStatus(statusId, pedidoId);
            TempData["StatusAtualizado"] = "Status do pedido " + pedidoRetorno.NumeroPedido + " alterado com sucesso!";
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Remover(Guid pedidoId)
        {
            _pedidoAppService.Remover(pedidoId);
            TempData["PedidoRemovido"] = "Pedido removido com sucesso!";
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Acoes(Guid id)
        {
            var pedido = _pedidoAppService.ObterPorId(id);
            PopularViewBagAcoes(pedido.RepresentadaId, pedido.ClienteId);
            return View(pedido);
        }

        private IEnumerable<PedidoViewModel> SearchByParameter(string parametro = "", string busca = "",
            string buscaRepresentada = "", string buscaStatus = "", string buscaTipoPedido = "")
        {
            IEnumerable<PedidoViewModel> pedidos = new List<PedidoViewModel>();

            //Isso vira de uma claim, depois que fizermos o esquema de autenticação.
            var usuario = _usuarioAppService.ObterPorId(Guid.Parse("65d44201-487e-46f0-bc3f-d4774c1768d5"));

            if (parametro == "cliente")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    pedidos = _pedidoAppService.ObterPorCliente(usuario, busca);
                    return pedidos;
                }
            }
            else if (parametro == "representada")
            {
                if (!string.IsNullOrEmpty(buscaRepresentada))
                {
                    pedidos = _pedidoAppService.ObterPorRepresentada(usuario, Guid.Parse(buscaRepresentada));
                    return pedidos;
                }
            }
            else if (parametro == "vendedor")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    pedidos = _pedidoAppService.ObterPorVendedor(busca);
                    return pedidos;
                }
            }
            else if (parametro == "dataEmissao")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    pedidos = _pedidoAppService.ObterPorDataEmissao(usuario, Convert.ToDateTime(busca));
                    return pedidos;
                }
            }
            else if (parametro == "numeroPedido")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    var pedido = _pedidoAppService.ObterPorNumeroPedido(usuario, Convert.ToInt32(busca));
                    pedidos.ToList().Add(pedido);
                    return pedidos;
                }
            }
            else if (parametro == "status")
            {
                if (!string.IsNullOrEmpty(buscaStatus))
                {
                    pedidos = _pedidoAppService.ObterPorStatus(usuario, Guid.Parse(buscaStatus));
                    return pedidos;
                }
            }
            else if (parametro == "tipo")
            {
                if (!string.IsNullOrEmpty(buscaTipoPedido))
                {
                    pedidos = _pedidoAppService.ObterPorTipo(usuario, Guid.Parse(buscaTipoPedido));
                    return pedidos;
                }
            }

            pedidos = _pedidoAppService.ObterTodos(usuario);
            return pedidos;
        }

        public JsonResult GetCliente(string query)
        {
            var pessoaFisica = _pessoaFisicaAppService.ObterPorNome(query).ToList();
            var pessoaJuridica = _pessoaJuridicaAppService.ObterPorRazaoSocial(query).ToList();

            var listaJson = new List<dynamic>();

            foreach (var item in pessoaFisica)
            {
                var json = new
                {
                    NomeRazaoSocial = item.Nome,
                    ClienteId = item.ClienteId
                };
                listaJson.Add(json);
            }

            foreach (var item in pessoaJuridica)
            {
                var json = new
                {
                    NomeRazaoSocial = item.RazaoSocial,
                    ClienteId = item.ClienteId
                };
                listaJson.Add(json);
            }

            return Json(new { listaJson }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCondicoesPagamentoRepresentada(Guid id)
        {
            return Json(new { json = _condicaoPagamentoAppService.ObterTodos(id) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEnderecosCliente(Guid id)
        {
            return Json(new { json = _enderecoClienteAppService.ObterTodos(id) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetContatosCliente(Guid id)
        {
            return Json(new { json = _contatoClienteAppService.ObterTodos(id) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRepresentadas(string query)
        {
            return Json(new { json = _representadaAppService.ObterTodos() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProdutos(Guid id, string query)
        {
            return Json(new { json = _produtoAppService.ObterPorNome(query, id) }, JsonRequestBehavior.AllowGet);
        }

        private void PopularViewBagCadastro()
        {
            ViewBag.NumeroPedido = _pedidoAppService.ObterNumeroPedido();
            ViewBag.Vendedor = new SelectList(_usuarioAppService.ObterTodos(), "UsuarioId", "Nome");
            ViewBag.Transportadora = new SelectList(_transportadoraAppService.ObterTodos(), "TransportadoraId", "Nome");
            ViewBag.TipoPedidoCadastro = new SelectList(_tipoPedidoAppService.ObterTodos(), "TipoPedidoId", "Descricao");
        }

        private void PopularViewBag()
        {
            ViewBag.Representada = _representadaAppService.ObterTodos();
            ViewBag.Status = _statusPedidoAppService.ObterTodos();
            ViewBag.TipoPedido = _tipoPedidoAppService.ObterTodos();
        }

        private void PopularViewBagAcoes(Guid representadaId, Guid clienteId)
        {
            ViewBag.Vendedor = _usuarioAppService.ObterTodos();
            ViewBag.Transportadora = _transportadoraAppService.ObterTodos();
            ViewBag.TipoPedido = _tipoPedidoAppService.ObterTodos();
            ViewBag.CondicoesPagamento = _condicaoPagamentoAppService.ObterTodos(representadaId);
            ViewBag.EnderecosCliente = _enderecoClienteAppService.ObterTodos(clienteId);
            ViewBag.ContatosCliente = _contatoClienteAppService.ObterTodos(clienteId);
            ViewBag.StatusNaoPadroes = _statusPedidoAppService.ObterStatusNaoPadroes();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _condicaoPagamentoAppService.Dispose();
                _contatoClienteAppService.Dispose();
                _enderecoClienteAppService.Dispose();
                _pessoaFisicaAppService.Dispose();
                _pessoaJuridicaAppService.Dispose();
                _produtoAppService.Dispose();
                _representadaAppService.Dispose();
                _tipoPedidoAppService.Dispose();
                _transportadoraAppService.Dispose();
                _usuarioAppService.Dispose();
                _pedidoAppService.Dispose();
                _faturamentoAppService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}