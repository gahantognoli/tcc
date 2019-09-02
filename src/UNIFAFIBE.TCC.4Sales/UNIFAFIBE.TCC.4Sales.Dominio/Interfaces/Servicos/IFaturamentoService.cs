using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IFaturamentoService : IDisposable
    {
        Faturamento Faturar(Faturamento faturamento);
        Faturamento Atualizar(Faturamento faturamento);
        void Remover(Guid id);
        Faturamento ObterPorId(Guid id);
        IEnumerable<Faturamento> ObterTodos(Guid pedidoId);
        decimal ObterTotalFaturamento(Guid pedidoId);
    }
}
