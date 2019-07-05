using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface ITransportadoraRepositorio : IRepositorio<Transportadora>
    {
        IEnumerable<Transportadora> ObterPorNome(string nome);
        IEnumerable<Transportadora> ObterPorCidade(string cidade);
        IEnumerable<Transportadora> ObterPorEstado(string estado);
    }
}
