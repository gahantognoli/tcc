using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IPessoaJuridicaService : IDisposable
    {
        PessoaJuridica Adicionar(PessoaJuridica cliente);
        PessoaJuridica Atualizar(PessoaJuridica cliente);
        void Remover(Guid id);
        PessoaJuridica ObterPorId(Guid id);
        IEnumerable<PessoaJuridica> ObterTodos();
        IEnumerable<PessoaJuridica> ObterPorCPNJ(string cnpj);
        IEnumerable<PessoaJuridica> ObterPorRazaoSocial(string razaoSocial);
        IEnumerable<PessoaJuridica> ObterPorNomeFantasia(string nomeFantasia);
        IEnumerable<PessoaJuridica> ObterPorInscricaoEstadual(string inscricaoEstadual);
    }
}
