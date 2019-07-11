﻿using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        IEnumerable<Produto> ObterTodos(int representadaId);
        IEnumerable<Produto> ObterPorNome(string nome);
        IEnumerable<Produto> ObterPorFaixaDePreco(decimal valorInicial, decimal valorFinal);
        IEnumerable<Produto> ClassificarPorPrecoMaisBarato();
        IEnumerable<Produto> ClassificarPorPrecoMaisCaro();
        IEnumerable<Produto> ClassificarPorOrdemAlfabetica();
        IEnumerable<Produto> ClassificarPorOrdemAlfabeticaDecrescente();
    }
}