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
            return _itemPedidoRepositorio.Adicionar(itemPedido);
        }

        public ItemPedido Atualizar(ItemPedido itemPedido)
        {
            return _itemPedidoRepositorio.Atualizar(itemPedido);
        }

        public void Dispose()
        {
            _itemPedidoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public ItemPedido ObterPorId(int id)
        {
            return _itemPedidoRepositorio.ObterPorId(id);
        }

        public IEnumerable<ItemPedido> ObterTodos(int pedidoId)
        {
            return _itemPedidoRepositorio.ObterTodos(pedidoId);
        }

        public void Remover(int id)
        {
            _itemPedidoRepositorio.Remover(id);
        }
    }
}
