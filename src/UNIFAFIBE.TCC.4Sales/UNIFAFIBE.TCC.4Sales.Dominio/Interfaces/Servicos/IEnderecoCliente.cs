using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IEnderecoCliente
    {
        EnderecoCliente Adicionar(EnderecoCliente enderecoCliente);
        EnderecoCliente Atualizar(EnderecoCliente enderecoCliente);
        void Remover(int id);
        EnderecoCliente ObterPorId(int id);
        IEnumerable<EnderecoCliente> ObterTodos(int clienteId);
    }
}
