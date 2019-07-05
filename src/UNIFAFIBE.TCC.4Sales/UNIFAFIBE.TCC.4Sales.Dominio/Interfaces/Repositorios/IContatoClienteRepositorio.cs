using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IContatoClienteRepositorio : IRepositorio<ContatoCliente>
    {
        IEnumerable<ContatoCliente> ObterTodos(int clienteId);
    }
}
