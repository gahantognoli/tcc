using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IMetaRepositorio : IRepositorio<Meta>
    {
        IEnumerable<Meta> ObterPorPeriodo(string ano, string mes);
    }
}
