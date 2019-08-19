using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IRepresentadaAppService : IDisposable
    {
        RepresentadaViewModel Adicionar(RepresentadaViewModel representada);
        RepresentadaViewModel Atualizar(RepresentadaViewModel representada);
        void Remover(Guid id);
        RepresentadaViewModel ObterPorId(Guid id);
        IEnumerable<RepresentadaViewModel> ObterTodos();
        IEnumerable<RepresentadaViewModel> ObterPorRazaoSocial(string razaoSocial);
        IEnumerable<RepresentadaViewModel> ObterPorNomeFantansia(string nomeFantasia);
        IEnumerable<RepresentadaViewModel> ObterPorCnpj(string cnpj);
    }
}
