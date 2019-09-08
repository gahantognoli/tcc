using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class TipoPedidoService : ITipoPedidoService
    {
        private readonly ITipoPedidoRepositorio _tipoPedidoRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public TipoPedidoService(ITipoPedidoRepositorio tipoPedidoRepositorio,
            IPedidoRepositorio pedidoRepositorio)
        {
            _tipoPedidoRepositorio = tipoPedidoRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
        }

        public TipoPedido Adicionar(TipoPedido tipoPedido)
        {
            if (!tipoPedido.EhValido(_tipoPedidoRepositorio))
                return tipoPedido;

            return _tipoPedidoRepositorio.Adicionar(tipoPedido);
        }

        public TipoPedido Atualizar(TipoPedido tipoPedido)
        {
            if (!tipoPedido.EstaConsistente())
                return tipoPedido;
            return _tipoPedidoRepositorio.Atualizar(tipoPedido);
        }

        public void Dispose()
        {
            _tipoPedidoRepositorio.Dispose();
            _pedidoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TipoPedido> ObterPorDescricao(string tipoPedido)
        {
            return _tipoPedidoRepositorio.ObterPorDescricao(tipoPedido);
        }

        public TipoPedido ObterPorId(Guid id)
        {
            return _tipoPedidoRepositorio.ObterPorId(id);
        }

        public IEnumerable<TipoPedido> ObterTodos()
        {
            return _tipoPedidoRepositorio.ObterTodos();
        }

        public TipoPedido Remover(Guid id)
        {
            var tipoPedidoRetorno = _tipoPedidoRepositorio.ObterPorId(id);
            if (tipoPedidoRetorno.EstaAptoParaRemover(_pedidoRepositorio))
                _tipoPedidoRepositorio.Remover(id);

            return tipoPedidoRetorno;
        }
    }
}
