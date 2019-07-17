using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Infra.Helpers;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;
using UNIFAFIBE.TCC._4Sales.Persistencia.Procedures;

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

        public override Meta ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            Meta retornoMeta;

            retornoMeta = cn.Query<Meta>(MetaProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoMeta;
        }

        public IEnumerable<Meta> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Meta> retornoMeta;

            retornoMeta = cn.Query<Meta>(MetaProcedures.ObterPorPeriodo.GetDescription(),
                new { dataInicio = dataInicio, dataFim = dataFim },
                commandType: CommandType.StoredProcedure);

            return retornoMeta;
        }
    }
}
