using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class CondicaoPagamentoRepositorio : Repositorio<CondicaoPagamento>, ICondicaoPagamentoRepositorio
    {
        public CondicaoPagamentoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override CondicaoPagamento ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<CondicaoPagamento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CondicaoPagamento> ObterTodos(int representadaId)
        {
            throw new NotImplementedException();
        }
    }
}
