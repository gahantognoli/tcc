using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Produto ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Produto> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ClassificarPorOrdemAlfabetica()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ClassificarPorOrdemAlfabeticaDecrescente()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ClassificarPorPrecoMaisBarato()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ClassificarPorPrecoMaisCaro()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ObterPorFaixaDePreco(decimal valorInicial, decimal valorFinal)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ObterTodos(int representadaId)
        {
            throw new NotImplementedException();
        }
    }
}
