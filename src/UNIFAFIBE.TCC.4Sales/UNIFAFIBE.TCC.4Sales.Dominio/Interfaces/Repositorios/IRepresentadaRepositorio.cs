using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IRepresentadaRepositorio : IRepositorio<Representada>
    {
        IEnumerable<Representada> ObterPorRazaoSocial(string razaoSocial);
        IEnumerable<Representada> ObterPorNomeFantansia(string nomeFantasia);
        IEnumerable<Representada> ObterPorCnpj(string cnpj);
    }
}
