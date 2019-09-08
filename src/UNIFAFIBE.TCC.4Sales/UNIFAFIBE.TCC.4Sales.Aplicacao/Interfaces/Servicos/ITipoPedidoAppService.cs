using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface ITipoPedidoAppService : IDisposable
    {
        TipoPedidoViewModel Adicionar(TipoPedidoViewModel tipoPedido);
        TipoPedidoViewModel Atualizar(TipoPedidoViewModel tipoPedido);
        TipoPedidoViewModel Remover(Guid id);
        TipoPedidoViewModel ObterPorId(Guid id);
        IEnumerable<TipoPedidoViewModel> ObterPorDescricao(string tipoPedido);
        IEnumerable<TipoPedidoViewModel> ObterTodos();
    }
}
