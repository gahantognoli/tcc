using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IPessoaJuridicaAppService
    {
        PessoaJuridicaViewModel Adicionar(PessoaJuridicaViewModel cliente);
        PessoaJuridicaViewModel Atualizar(PessoaJuridicaViewModel cliente);
        void Remover(Guid id);
        ClienteViewModel ObterPorId(Guid id);
        IEnumerable<PessoaJuridicaViewModel> ObterPorCPNJ(string cnpj);
        IEnumerable<PessoaJuridicaViewModel> ObterPorRazaoSocial(string razaoSocial);
        IEnumerable<PessoaJuridicaViewModel> ObterPorNomeFantasia(string nomeFantasia);
        IEnumerable<PessoaJuridicaViewModel> ObterPorInscricaoEstadual(string inscricaoEstadual);
    }
}
