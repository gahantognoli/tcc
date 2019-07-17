using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IPessoaFisicaService : IDisposable { 
        PessoaFisica Adicionar(PessoaFisica cliente);
        PessoaFisica Atualizar(PessoaFisica cliente);
        void Remover(Guid id);
        Cliente ObterPorId(Guid id);
        IEnumerable<Cliente> ObterTodos();
        IEnumerable<PessoaFisica> ObterPorNome(string nome);
        IEnumerable<PessoaFisica> ObterPorCPF(string cpf);
    }
}
