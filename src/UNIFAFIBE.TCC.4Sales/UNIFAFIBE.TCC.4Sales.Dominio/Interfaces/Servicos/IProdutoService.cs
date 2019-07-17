using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IProdutoService : IDisposable
    {
        Produto Adicionar(Produto produto);
        Produto Atualizar(Produto produto);
        void Remover(Guid id);
        Produto ObterPorId(Guid id);
        IEnumerable<Produto> ObterTodos(Guid representadaId);
        IEnumerable<Produto> ObterPorNome(string nome, Guid representadaId);
        IEnumerable<Produto> ObterPorFaixaDePreco(decimal valorInicial, decimal valorFinal, Guid representadaId);
        //IEnumerable<Produto> ClassificarPorPrecoMaisBarato();
        //IEnumerable<Produto> ClassificarPorPrecoMaisCaro();
        //IEnumerable<Produto> ClassificarPorOrdemAlfabetica();
        //IEnumerable<Produto> ClassificarPorOrdemAlfabeticaDecrescente();
    }
}
