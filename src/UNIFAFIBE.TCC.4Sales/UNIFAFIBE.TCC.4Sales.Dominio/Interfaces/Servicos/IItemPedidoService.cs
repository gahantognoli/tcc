using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IItemPedidoService : IDisposable
    {
        ItemPedido Adicionar(ItemPedido itemPedido);
        ItemPedido Atualizar(ItemPedido itemPedido);
        void Remover(Guid id);
        ItemPedido ObterPorId(Guid id);
        IEnumerable<ItemPedido> ObterPorProduto(Guid produtoId);
        IEnumerable<ItemPedido> ObterTodos(Guid pedidoId);
    }
}
