using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface ICondicaoPagamentoAppService
    {
        CondicaoPagamentoViewModel Adicionar(CondicaoPagamentoViewModel condicaoPagamento);
        CondicaoPagamentoViewModel Atualizar(CondicaoPagamentoViewModel condicaoPagamento);
        void Remover(Guid id);
        CondicaoPagamentoViewModel ObterPorId(Guid id);
        IEnumerable<CondicaoPagamentoViewModel> ObterTodos(Guid representadaId);
    }
}
