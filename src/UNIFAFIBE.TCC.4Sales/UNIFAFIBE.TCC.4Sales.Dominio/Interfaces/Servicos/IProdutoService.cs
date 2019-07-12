using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IProdutoService : IDisposable
    {
        Produto Adicionar(Produto produto);
        Produto Atualizar(Produto produto);
        void Remover(int id);
        Produto ObterPorId(int id);
        IEnumerable<Produto> ObterTodos(int representadaId);
        IEnumerable<Produto> ObterPorNome(string nome, int representadaId);
        IEnumerable<Produto> ObterPorFaixaDePreco(decimal valorInicial, decimal valorFinal, int representadaId);
        //IEnumerable<Produto> ClassificarPorPrecoMaisBarato();
        //IEnumerable<Produto> ClassificarPorPrecoMaisCaro();
        //IEnumerable<Produto> ClassificarPorOrdemAlfabetica();
        //IEnumerable<Produto> ClassificarPorOrdemAlfabeticaDecrescente();
    }
}
