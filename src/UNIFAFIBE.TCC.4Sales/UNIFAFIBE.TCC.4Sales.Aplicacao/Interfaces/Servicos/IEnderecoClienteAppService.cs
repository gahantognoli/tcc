using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IEnderecoClienteAppService
    {
        EnderecoClienteViewModel Adicionar(EnderecoClienteViewModel enderecoCliente);
        EnderecoClienteViewModel Atualizar(EnderecoClienteViewModel enderecoCliente);
        void Remover(Guid id);
        EnderecoClienteViewModel ObterPorId(Guid id);
        IEnumerable<EnderecoClienteViewModel> ObterTodos(Guid clienteId);
    }
}
