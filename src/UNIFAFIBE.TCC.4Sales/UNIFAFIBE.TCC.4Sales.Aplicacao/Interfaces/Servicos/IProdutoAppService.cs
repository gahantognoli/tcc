using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IProdutoAppService : IDisposable
    {
        ProdutoViewModel Adicionar(ProdutoViewModel produto);
        ProdutoViewModel Atualizar(ProdutoViewModel produto);
        void Remover(Guid id);
        ProdutoViewModel ObterPorId(Guid id);
        IEnumerable<ProdutoViewModel> ObterTodos(Guid representadaId);
        IEnumerable<ProdutoViewModel> ObterPorNome(string nome, Guid representadaId);
        IEnumerable<ProdutoViewModel> ObterPorFaixaDePreco(decimal valorInicial, decimal valorFinal, Guid representadaId);
        //IEnumerable<Produto> ClassificarPorPrecoMaisBarato();
        //IEnumerable<Produto> ClassificarPorPrecoMaisCaro();
        //IEnumerable<Produto> ClassificarPorOrdemAlfabetica();
        //IEnumerable<Produto> ClassificarPorOrdemAlfabeticaDecrescente();
    }
}
