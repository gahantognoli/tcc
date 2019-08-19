using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IItemPedidoAppService : IDisposable
    {
        ItemPedidoViewModel Adicionar(ItemPedidoViewModel itemPedido);
        ItemPedidoViewModel Atualizar(ItemPedidoViewModel itemPedido);
        void Remover(Guid id);
        ItemPedidoViewModel ObterPorId(Guid id);
        IEnumerable<ItemPedidoViewModel> ObterTodos(Guid pedidoId);
    }
}
