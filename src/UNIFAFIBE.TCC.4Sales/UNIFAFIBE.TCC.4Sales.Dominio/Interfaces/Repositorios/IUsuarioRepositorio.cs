using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        IEnumerable<Usuario> ObterPorNome(string nome);
    }
}
