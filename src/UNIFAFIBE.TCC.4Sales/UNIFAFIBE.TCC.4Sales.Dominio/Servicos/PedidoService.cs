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
            return _pedidoRepositorio.Atualizar(pedido);
        }

        public Pedido AtualizarStatus(int statusId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _pedidoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public void EnviarPorEmail(int pedidoId, int usuarioId, string[] destinatarios, string assunto = null, string corpo = null)
        {
            throw new NotImplementedException();
        }

        public Pedido GerarOrcamento(Pedido pedido)
        {
            pedido.StatusPedido.Descricao = "Em Orçamento";
            return _pedidoRepositorio.Adicionar(pedido);
        }

        public Pedido GerarPedido(Pedido pedido)
        {
            var pedidoExiste = _pedidoRepositorio.ObterPorId(pedido.PedidoId);
            pedido.StatusPedido.Descricao = "Pedido de Venda Gerado";

            if (pedidoExiste != null)
                return _pedidoRepositorio.Atualizar(pedido);
         
            return _pedidoRepositorio.Adicionar(pedido);
        }

        public IEnumerable<Pedido> ObterPorCliente(string cliente)
        {
            return _pedidoRepositorio.ObterPorCliente(cliente);
        }

        public IEnumerable<Pedido> ObterPorDataEmissao(DateTime dataEmissao)
        {
            return _pedidoRepositorio.ObterPorDataEmissao(dataEmissao);
        }

        public Pedido ObterPorId(int id)
        {
            return _pedidoRepositorio.ObterPorId(id);
        }

        public Pedido ObterPorNumeroPedido(int numeroPedido)
        {
            return _pedidoRepositorio.ObterPorNumeroPedido(numeroPedido);
        }

        public IEnumerable<Pedido> ObterPorRepresentada(int representadaId)
        {
            return _pedidoRepositorio.ObterPorRepresentada(representadaId);
        }

        public IEnumerable<Pedido> ObterPorStatus(int statusId)
        {
            return _pedidoRepositorio.ObterPorStatus(statusId);
        }

        public IEnumerable<Pedido> ObterPorTipo(int tipoId)
        {
            return _pedidoRepositorio.ObterPorTipo(tipoId);
        }

        public IEnumerable<Pedido> ObterPorVendedor(string usuario)
        {
            return _pedidoRepositorio.ObterPorVendedor(usuario);
        }

        public IEnumerable<Pedido> ObterTodos()
        {
            return _pedidoRepositorio.ObterTodos();
        }

        public void Remover(int id)
        {
            _pedidoRepositorio.Remover(id);
        }

        public void VisualizarEmDocumento(int id)
        {
            throw new NotImplementedException();
        }
    }
}
