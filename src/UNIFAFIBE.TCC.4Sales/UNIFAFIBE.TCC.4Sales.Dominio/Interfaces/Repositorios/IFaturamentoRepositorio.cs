using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IFaturamentoRepositorio : IRepositorio<Faturamento>
    {
        IEnumerable<Faturamento> ObterTodos(int pedidoId);
    }
}
