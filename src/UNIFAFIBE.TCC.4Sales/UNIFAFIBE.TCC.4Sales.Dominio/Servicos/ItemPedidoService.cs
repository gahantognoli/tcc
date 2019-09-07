using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepositorio _itemPedidoRepositorio;

        public ItemPedidoService(IItemPedidoRepositorio itemPedidoRepositorio)
        {
            _itemPedidoRepositorio = itemPedidoRepositorio;
        }

        public ItemPedido Adicionar(ItemPedido itemPedido)
        {
            if (!itemPedido.EhValido())
                return itemPedido;

            return _itemPedidoRepositorio.Adicionar(itemPedido);
        }

        public ItemPedido Atualizar(ItemPedido itemPedido)
        {
            if (!itemPedido.EhValido())
                return itemPedido;

            return _itemPedidoRepositorio.Atualizar(itemPedido);
        }

        public void Dispose()
        {
            _itemPedidoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public ItemPedido ObterPorId(Guid id)
        {
            return _itemPedidoRepositorio.ObterPorId(id);
        }

        public IEnumerable<ItemPedido> ObterPorProduto(Guid produtoId)
        {
            return _itemPedidoRepositorio.ObterPorProduto(produtoId);
        }

        public IEnumerable<ItemPedido> ObterTodos(Guid pedidoId)
        {
            return _itemPedidoRepositorio.ObterTodos(pedidoId);
        }

        public void Remover(Guid id)
        {
            _itemPedidoRepositorio.Remover(id);
        }
    }
}
