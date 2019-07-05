using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface ISegmentoRepositorio : IRepositorio<Segmento>
    {
        IEnumerable<Segmento> ObterPorDescricao(string descricao);
    }
}
