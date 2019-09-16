using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IMetaAppService : IDisposable
    {
        MetaViewModel Adicionar(MetaViewModel meta);
        MetaViewModel Atualizar(MetaViewModel meta);
        void Remover(Guid id);
        MetaViewModel ObterPorId(Guid id);
        IEnumerable<MetaViewModel> ObterTodos();
        IEnumerable<MetaViewModel> ObterPorPeriodo(string ano, string mes);
    }
}
