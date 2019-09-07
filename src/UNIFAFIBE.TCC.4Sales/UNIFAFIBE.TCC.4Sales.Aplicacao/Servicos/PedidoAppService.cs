using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Persistencia.UnitOfWork;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos
{
    public class PedidoAppService : AppService, IPedidoAppService
    {
        private readonly IPedidoService _pedidoService;
        private readonly IStatusPedidoService _statusPedidoService;
        private readonly IItemPedidoAppService _itemPedidoAppService;
        private readonly IFaturamentoAppService _faturamentoAppService;
        private readonly IParcelaAppService _parcelaAppService;

        public PedidoAppService(IPedidoService pedidoService, IStatusPedidoService statusPedidoService,
            IItemPedidoAppService itemPedidoAppService, IFaturamentoAppService faturamentoAppService,
            IParcelaAppService parcelaAppService, IUnitOfWork uow) : base(uow)
        {
            _pedidoService = pedidoService;
            _statusPedidoService = statusPedidoService;
            _itemPedidoAppService = itemPedidoAppService;
            _faturamentoAppService = faturamentoAppService;
            _parcelaAppService = parcelaAppService;
        }

        public PedidoViewModel AlterarStatus(Guid statusId, Guid pedidoId)
        {
            var pedido = Mapper.Map<PedidoViewModel>(_pedidoService.AlterarStatus(statusId, pedidoId));
            Commit();
            return pedido;
        }

        public PedidoViewModel Atualizar(PedidoViewModel pedido)
        {
            pedido.ItensPedido.ToList().ForEach(item => item.PedidoId = pedido.PedidoId);
            var pedidoRetorno = Mapper.Map<PedidoViewModel>(_pedidoService.Atualizar(Mapper.Map<Pedido>(pedido)));

            if (pedidoRetorno.EhValido())
                Commit();

            return pedidoRetorno;
        }

        public void Dispose()
        {
            _pedidoService.Dispose();
        }

        public void EnviarPorEmail(Guid pedidoId, Guid usuarioId, string[] destinatarios, string assunto = null, string corpo = null)
        {
            _pedidoService.EnviarPorEmail(pedidoId, usuarioId, destinatarios, assunto, corpo);
        }

        public PedidoViewModel GerarOrcamento(PedidoViewModel pedido)
        {
            pedido.StatusPedidoId = _statusPedidoService.ObterPorDescricao("Em Orçamento")
            .FirstOrDefault().StatusPedidoId;
            pedido.ItensPedido.ToList().ForEach(item => item.PedidoId = pedido.PedidoId);
            var pedidoRetorno = Mapper.Map<PedidoViewModel>(_pedidoService
                .GerarOrcamento(Mapper.Map<Pedido>(pedido)));
            if (pedidoRetorno.EhValido())
                Commit();

            return pedidoRetorno;
        }

        public PedidoViewModel GerarPedido(PedidoViewModel pedido)
        {
            if (_pedidoService.ObterPorId(pedido.PedidoId) != null)
            {
                var pedidoRetorno = _pedidoService
                    .Atualizar(Mapper.Map<Pedido>(pedido), "Pedido de Venda Gerado");
                Commit();
                return Mapper.Map<PedidoViewModel>(pedidoRetorno);
            }
            else
            {
                pedido.StatusPedidoId = _statusPedidoService.ObterPorDescricao("Pedido de Venda Gerado")
                .FirstOrDefault().StatusPedidoId;
                pedido.ItensPedido.ToList().ForEach(item => item.PedidoId = pedido.PedidoId);
                var pedidoRetorno = Mapper.Map<PedidoViewModel>(_pedidoService
                    .GerarPedido(Mapper.Map<Pedido>(pedido)));
                if (pedidoRetorno.EhValido())
                    Commit();

                return pedidoRetorno;
            }
        }

        public int ObterNumeroPedido()
        {
            return _pedidoService.ObterNumeroPedido();
        }

        public IEnumerable<PedidoViewModel> ObterPorCliente(UsuarioViewModel vendedor, string cliente)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService
                .ObterPorCliente(Mapper.Map<Usuario>(vendedor), cliente));
        }

        public IEnumerable<PedidoViewModel> ObterPorDataEmissao(UsuarioViewModel vendedor, DateTime dataEmissao)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService
                .ObterPorDataEmissao(Mapper.Map<Usuario>(vendedor), dataEmissao));
        }

        public PedidoViewModel ObterPorId(Guid id)
        {
            var pedido = Mapper.Map<PedidoViewModel>(_pedidoService.ObterPorId(id));

            foreach (var item in Mapper.Map<IEnumerable<ItemPedidoViewModel>>
                (_itemPedidoAppService.ObterTodos(id)))
            {
                pedido.ItensPedido.Add(item);
            }
            return pedido;

        }

        public PedidoViewModel ObterPorNumeroPedido(UsuarioViewModel vendedor, int numeroPedido)
        {
            return Mapper.Map<PedidoViewModel>(_pedidoService
                .ObterPorNumeroPedido(Mapper.Map<Usuario>(vendedor), numeroPedido));
        }

        public IEnumerable<PedidoViewModel> ObterPorRepresentada(UsuarioViewModel vendedor, Guid representadaId)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService
                .ObterPorRepresentada(Mapper.Map<Usuario>(vendedor), representadaId));
        }

        public IEnumerable<PedidoViewModel> ObterPorRepresentada(Guid representadaId)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService
                .ObterPorRepresentada(representadaId));
        }

        public IEnumerable<PedidoViewModel> ObterPorStatus(UsuarioViewModel vendedor, Guid statusId)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService
                .ObterPorStatus(Mapper.Map<Usuario>(vendedor), statusId));
        }

        public IEnumerable<PedidoViewModel> ObterPorTipo(UsuarioViewModel vendedor, Guid tipoId)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService
                .ObterPorTipo(Mapper.Map<Usuario>(vendedor), tipoId));
        }

        public IEnumerable<PedidoViewModel> ObterPorVendedor(string usuario)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService.ObterPorVendedor(usuario));
        }

        public IEnumerable<PedidoViewModel> ObterTodos(UsuarioViewModel vendedor)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService.ObterTodos(Mapper.Map<Usuario>(vendedor)));
        }

        public void Remover(Guid id)
        {
            var faturamento = _faturamentoAppService.ObterTodos(id);
            if (faturamento.Count() > 0)
            {
                foreach (var item in faturamento)
                {
                    var parcela = _parcelaAppService.ObterTodos(item.FaturamentoId);
                    if (parcela.Count() > 0)
                    {
                        parcela.ToList().ForEach(f => _parcelaAppService.Remover(f.ParcelaId));
                    }
                }
                faturamento.ToList().ForEach(f => _faturamentoAppService.Remover(f.FaturamentoId));
            }

            var itensPedido = _itemPedidoAppService.ObterTodos(id);
            if (itensPedido.Count() > 0)
            {
                itensPedido.ToList().ForEach(p => _itemPedidoAppService.Remover(p.ItemPedidoId));
            }
            _pedidoService.Remover(id);
            Commit();
        }

        public void VisualizarEmDocumento(Guid id)
        {
            _pedidoService.VisualizarEmDocumento(id);
        }
    }
}
