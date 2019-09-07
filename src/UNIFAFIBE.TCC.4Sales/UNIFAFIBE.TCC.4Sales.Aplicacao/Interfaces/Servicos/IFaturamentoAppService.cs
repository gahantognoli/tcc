using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IFaturamentoAppService : IDisposable
    {
        FaturamentoViewModel Faturar(FaturamentoViewModel faturamento);
        FaturamentoViewModel Atualizar(FaturamentoViewModel faturamento);
        void Remover(Guid id, Guid pedidoId);
        void Remover(Guid id);
        FaturamentoViewModel ObterPorId(Guid id);
        IEnumerable<FaturamentoViewModel> ObterTodos(Guid pedidoId);
        decimal ObterTotalFaturamento(Guid pedidoId);
    }
}
