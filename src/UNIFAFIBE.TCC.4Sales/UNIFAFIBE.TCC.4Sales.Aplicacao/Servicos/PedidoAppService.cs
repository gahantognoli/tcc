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

        public PedidoAppService(IPedidoService pedidoService, IStatusPedidoService statusPedidoService,
            IItemPedidoAppService itemPedidoAppService, IUnitOfWork uow) : base(uow)
        {
            _pedidoService = pedidoService;
            _statusPedidoService = statusPedidoService;
            _itemPedidoAppService = itemPedidoAppService;
        }

        public PedidoViewModel Atualizar(PedidoViewModel pedido)
        {
            var pedidoRetorno = Mapper.Map<PedidoViewModel>(_pedidoService.Atualizar(Mapper.Map<Pedido>(pedido)));

            if (pedidoRetorno.EhValido())
                Commit();

            return pedidoRetorno;
        }

        public PedidoViewModel AtualizarStatus(Guid statusId)
        {
            var pedidoRetorno = Mapper.Map<PedidoViewModel>(_pedidoService.AtualizarStatus(statusId));

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
            pedido.StatusPedidoId = _statusPedidoService.ObterPorDescricao("Pedido de Venda Gerado")
                .FirstOrDefault().StatusPedidoId;
            pedido.ItensPedido.ToList().ForEach(item => item.PedidoId = pedido.PedidoId);
            var pedidoRetorno = Mapper.Map<PedidoViewModel>(_pedidoService
                .GerarPedido(Mapper.Map<Pedido>(pedido)));
            if (pedidoRetorno.EhValido())
                Commit();

            return pedidoRetorno;
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
            _pedidoService.Remover(id);
            Commit();
        }

        public void VisualizarEmDocumento(Guid id)
        {
            _pedidoService.VisualizarEmDocumento(id);
        }
    }
}
