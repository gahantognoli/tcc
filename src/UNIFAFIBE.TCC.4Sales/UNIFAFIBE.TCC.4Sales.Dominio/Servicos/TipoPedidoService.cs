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

        public TipoPedidoService(ITipoPedidoRepositorio tipoPedidoRepositorio)
        {
            _tipoPedidoRepositorio = tipoPedidoRepositorio;
        }

        public TipoPedido Adicionar(TipoPedido tipoPedido)
        {
            if (!tipoPedido.EhValido())
                return tipoPedido;

            return _tipoPedidoRepositorio.Adicionar(tipoPedido);
        }

        public TipoPedido Atualizar(TipoPedido tipoPedido)
        {
            if (!tipoPedido.EhValido())
                return tipoPedido;

            return _tipoPedidoRepositorio.Atualizar(tipoPedido);
        }

        public void Dispose()
        {
            _tipoPedidoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TipoPedido> ObterPorDescricao(string tipoPedido)
        {
            return _tipoPedidoRepositorio.ObterPorDescricao(tipoPedido);
        }

        public TipoPedido ObterPorId(int id)
        {
            return _tipoPedidoRepositorio.ObterPorId(id);
        }

        public IEnumerable<TipoPedido> ObterTodos()
        {
            return _tipoPedidoRepositorio.ObterTodos();
        }

        public void Remover(int id)
        {
            _tipoPedidoRepositorio.Remover(id);
        }
    }
}
