using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        IEnumerable<Produto> ObterTodos(Guid representadaId);
        IEnumerable<Produto> ObterPorNome(string nome, Guid representadaId);
        IEnumerable<Produto> ObterPorFaixaDePreco(decimal valorInicial, decimal valorFinal, Guid representadaId);
        Produto ObterPorCodigo(string codigo, Guid representadaId);
        //IEnumerable<Produto> ClassificarPorPrecoMaisBarato();
        //IEnumerable<Produto> ClassificarPorPrecoMaisCaro();
        //IEnumerable<Produto> ClassificarPorOrdemAlfabetica();
        //IEnumerable<Produto> ClassificarPorOrdemAlfabeticaDecrescente();
    }
}
