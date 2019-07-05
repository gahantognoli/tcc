using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IEnderecoClienteRepositorio : IRepositorio<EnderecoCliente>
    {
        IEnumerable<EnderecoCliente> ObterTodos(int clienteId);
    }
}
