using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IParcelaAppService : IDisposable
    {
        ParcelaViewModel Adicionar(ParcelaViewModel parcela);
        ParcelaViewModel Atualizar(ParcelaViewModel parcela);
        decimal CalcularComissao(decimal valorFaturamento, decimal comissao, int numParcela);
        void Remover(Guid parcelaId);
        ParcelaViewModel ObterPorId(Guid id);
        IEnumerable<ParcelaViewModel> ObterTodos(Guid faturamentoId);
    }
}
