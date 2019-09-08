using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IStatusPedidoAppService : IDisposable
    {
        StatusPedidoViewModel Adicionar(StatusPedidoViewModel statusPedido);
        StatusPedidoViewModel Atualizar(StatusPedidoViewModel statusPedido);
        StatusPedidoViewModel Remover(Guid id);
        StatusPedidoViewModel ObterPorId(Guid id);
        IEnumerable<StatusPedidoViewModel> ObterPorDescricao(string descricao);
        IEnumerable<StatusPedidoViewModel> ObterStatusNaoPadroes();
        IEnumerable<StatusPedidoViewModel> ObterTodos();
    }
}
