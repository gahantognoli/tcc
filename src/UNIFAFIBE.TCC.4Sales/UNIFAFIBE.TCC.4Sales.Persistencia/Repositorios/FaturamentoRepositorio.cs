using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class FaturamentoRepositorio : Repositorio<Faturamento>, IFaturamentoRepositorio
    {

        public FaturamentoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Faturamento ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Faturamento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Faturamento> ObterTodos(int pedidoId)
        {
            throw new NotImplementedException();
        }
    }
}
