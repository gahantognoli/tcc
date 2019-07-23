using AutoMapper;
using System;
using System.Collections.Generic;
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

        public PedidoAppService(IPedidoService pedidoService, IUnitOfWork uow)
            : base(uow)
        {
            _pedidoService = pedidoService;
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

        public void EnviarPorEmail(Guid pedidoId, Guid usuarioId, string[] destinatarios, string assunto = null, string corpo = null)
        {
            _pedidoService.EnviarPorEmail(pedidoId, usuarioId, destinatarios, assunto, corpo);
        }

        public PedidoViewModel GerarOrcamento(PedidoViewModel pedido)
        {
            var pedidoRetorno = new Pedido();

            var pedidoExiste = _pedidoService.ObterPorId(pedido.PedidoId);


            if (pedidoExiste != null)
            {
                pedido.StatusPedido.Descricao = "Em Orçamento";
                pedidoRetorno = _pedidoService.GerarOrcamento(Mapper.Map<Pedido>(pedido));
                Commit();
            }

            return Mapper.Map<PedidoViewModel>(pedidoRetorno);
        }

        public PedidoViewModel GerarPedido(PedidoViewModel pedido)
        {
            var pedidoRetorno = new Pedido();

            var pedidoExiste = _pedidoService.ObterPorId(pedido.PedidoId);
            pedido.StatusPedido.Descricao = "Pedido de Venda Gerado";

            //Verifica se o pedido existe
            if (pedidoExiste != null)
                pedidoRetorno = _pedidoService.Atualizar(Mapper.Map<Pedido>(pedido));
            else
                pedidoRetorno = _pedidoService.GerarPedido(Mapper.Map<Pedido>(pedido));


            Commit();

            return Mapper.Map<PedidoViewModel>(pedidoRetorno);
        }

        public IEnumerable<PedidoViewModel> ObterPorCliente(string cliente)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService.ObterPorCliente(cliente));
        }

        public IEnumerable<PedidoViewModel> ObterPorDataEmissao(DateTime dataEmissao)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService.ObterPorDataEmissao(dataEmissao));
        }

        public PedidoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<PedidoViewModel>(_pedidoService.ObterPorId(id));
        }

        public PedidoViewModel ObterPorNumeroPedido(int numeroPedido)
        {
            return Mapper.Map<PedidoViewModel>(_pedidoService.ObterPorNumeroPedido(numeroPedido));
        }

        public IEnumerable<PedidoViewModel> ObterPorRepresentada(Guid representadaId)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService.ObterPorRepresentada(representadaId));
        }

        public IEnumerable<PedidoViewModel> ObterPorStatus(Guid statusId)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService.ObterPorStatus(statusId));
        }

        public IEnumerable<PedidoViewModel> ObterPorTipo(Guid tipoId)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService.ObterPorTipo(tipoId));
        }

        public IEnumerable<PedidoViewModel> ObterPorVendedor(string usuario)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService.ObterPorVendedor(usuario));
        }

        public IEnumerable<PedidoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoService.ObterTodos());
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
