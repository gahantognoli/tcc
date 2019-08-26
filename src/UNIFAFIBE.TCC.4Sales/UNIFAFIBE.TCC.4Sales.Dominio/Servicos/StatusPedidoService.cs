using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class StatusPedidoService : IStatusPedidoService
    {
        private readonly IStatusPedidoRepositorio _statusPedidoRepositorio;

        public StatusPedidoService(IStatusPedidoRepositorio statusPedidoRepositorio)
        {
            _statusPedidoRepositorio = statusPedidoRepositorio;
        }

        public StatusPedido Adicionar(StatusPedido statusPedido)
        {
            if (!statusPedido.EhValido(_statusPedidoRepositorio))
                return statusPedido;

            return _statusPedidoRepositorio.Adicionar(statusPedido);
        }

        public StatusPedido Atualizar(StatusPedido statusPedido)
        {
            if (!statusPedido.EstaConsistente())
                return statusPedido;
            return _statusPedidoRepositorio.Atualizar(statusPedido);
        }

        public void Dispose()
        {
            _statusPedidoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<StatusPedido> ObterPorDescricao(string descricao)
        {
            return _statusPedidoRepositorio.ObterPorDescricao(descricao);
        }

        public StatusPedido ObterPorId(Guid id)
        {
            return _statusPedidoRepositorio.ObterPorId(id);
        }

        public IEnumerable<StatusPedido> ObterStatusNaoPadroes()
        {
            return _statusPedidoRepositorio.ObterStatusNaoPadroes();
        }

        public IEnumerable<StatusPedido> ObterTodos()
        {
            return _statusPedidoRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _statusPedidoRepositorio.Remover(id);
        }
    }
}
