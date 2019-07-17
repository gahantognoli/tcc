using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IEnderecoClienteService
    {
        EnderecoCliente Adicionar(EnderecoCliente enderecoCliente);
        EnderecoCliente Atualizar(EnderecoCliente enderecoCliente);
        void Remover(Guid id);
        EnderecoCliente ObterPorId(Guid id);
        IEnumerable<EnderecoCliente> ObterTodos(Guid clienteId);
    }
}
