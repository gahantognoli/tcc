using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoService(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }


        public Pedido Atualizar(Pedido pedido)
        {
            if (!pedido.EstaConsistente())
                return pedido;

            return _pedidoRepositorio.Atualizar(pedido);
        }

        public Pedido AtualizarStatus(Guid statusId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _pedidoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public void EnviarPorEmail(Guid pedidoId, Guid usuarioId, string[] destinatarios, string assunto = null, string corpo = null)
        {
            throw new NotImplementedException();
        }

        public Pedido GerarOrcamento(Pedido pedido)
        {
            if (!pedido.EhValido(_pedidoRepositorio))
                return pedido;

            return _pedidoRepositorio.Adicionar(pedido);
        }

        public Pedido GerarPedido(Pedido pedido)
        {
            if (!pedido.EstaConsistente())
                return pedido;

            return _pedidoRepositorio.Adicionar(pedido);
        }

        public int ObterNumeroPedido()
        {
            return _pedidoRepositorio.ObterNumeroPedido();
        }

        public IEnumerable<Pedido> ObterPorCliente(Usuario vendedor, string cliente)
        {
            return _pedidoRepositorio.ObterPorCliente(vendedor, cliente);
        }

        public IEnumerable<Pedido> ObterPorDataEmissao(Usuario vendedor, DateTime dataEmissao)
        {
            return _pedidoRepositorio.ObterPorDataEmissao(vendedor, dataEmissao);
        }

        public Pedido ObterPorId(Guid id)
        {
            return _pedidoRepositorio.ObterPorId(id);
        }

        public Pedido ObterPorNumeroPedido(Usuario vendedor, int numeroPedido)
        {
            return _pedidoRepositorio.ObterPorNumeroPedido(vendedor, numeroPedido);
        }

        public IEnumerable<Pedido> ObterPorRepresentada(Usuario vendedor, Guid representadaId)
        {
            return _pedidoRepositorio.ObterPorRepresentada(vendedor, representadaId);
        }

        public IEnumerable<Pedido> ObterPorRepresentada(Guid representadaId)
        {
            return _pedidoRepositorio.ObterPorRepresentada(representadaId);
        }

        public IEnumerable<Pedido> ObterPorStatus(Usuario vendedor, Guid statusId)
        {
            return _pedidoRepositorio.ObterPorStatus(vendedor, statusId);
        }

        public IEnumerable<Pedido> ObterPorTipo(Usuario vendedor, Guid tipoId)
        {
            return _pedidoRepositorio.ObterPorTipo(vendedor, tipoId);
        }

        public IEnumerable<Pedido> ObterPorVendedor(string vendedor)
        {
            return _pedidoRepositorio.ObterPorVendedor(vendedor);
        }

        public IEnumerable<Pedido> ObterTodos(Usuario vendedor)
        {
            return _pedidoRepositorio.ObterTodos(vendedor);
        }

        public void Remover(Guid id)
        {
            _pedidoRepositorio.Remover(id);
        }

        public void VisualizarEmDocumento(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
