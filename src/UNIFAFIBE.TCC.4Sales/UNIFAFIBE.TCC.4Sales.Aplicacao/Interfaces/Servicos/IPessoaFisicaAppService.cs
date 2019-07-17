using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IPessoaFisicaAppService
    {
        PessoaFisicaViewModel Adicionar(PessoaFisicaViewModel cliente);
        PessoaFisicaViewModel Atualizar(PessoaFisicaViewModel cliente);
        void Remover(Guid id);
        ClienteViewModel ObterPorId(Guid id);
        IEnumerable<ClienteViewModel> ObterTodos();
        IEnumerable<PessoaFisicaViewModel> ObterPorNome(string nome);
        IEnumerable<PessoaFisicaViewModel> ObterPorCPF(string cpf);
    }
}
