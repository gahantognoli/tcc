using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IContatoRepresentadaAppService : IDisposable
    {
        ContatoRepresentadaViewModel Adicionar(ContatoRepresentadaViewModel ContatoRepresentadaViewModel);
        ContatoRepresentadaViewModel Atualizar(ContatoRepresentadaViewModel ContatoRepresentadaViewModel);
        void Remover(Guid id);
        ContatoRepresentadaViewModel ObterPorId(Guid id);
        IEnumerable<ContatoRepresentadaViewModel> ObterTodos(Guid representadaId);
    }
}
