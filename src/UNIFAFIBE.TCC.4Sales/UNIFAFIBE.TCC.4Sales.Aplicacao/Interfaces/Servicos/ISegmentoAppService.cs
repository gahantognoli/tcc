using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface ISegmentoAppService
    {
        SegmentoViewModel Adicionar(SegmentoViewModel segmento);
        SegmentoViewModel Atualizar(SegmentoViewModel segmento);
        void Remover(Guid id);
        SegmentoViewModel ObterPorId(Guid id);
        IEnumerable<SegmentoViewModel> ObterTodos();
        IEnumerable<SegmentoViewModel> ObterPorDescricao(string descricao);
    }
}
