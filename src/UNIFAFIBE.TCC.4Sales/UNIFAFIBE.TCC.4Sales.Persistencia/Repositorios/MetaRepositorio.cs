using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class MetaRepositorio : Repositorio<Meta>, IMetaRepositorio
    {
        public MetaRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override IEnumerable<Meta> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public override Meta ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Meta> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }
    }
}
