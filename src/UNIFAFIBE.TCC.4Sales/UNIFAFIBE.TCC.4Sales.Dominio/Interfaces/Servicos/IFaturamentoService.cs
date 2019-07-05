using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IFaturamentoService : IDisposable
    {
        Faturamento Faturar(Faturamento faturamento);
        Faturamento Atualizar(Faturamento faturamento);
        void Remover(int id);
        Faturamento ObterPorId(int id);
        IEnumerable<Faturamento> ObterTodos(int pedidoId);
    }
}
