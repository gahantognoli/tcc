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
    public class SegmentoRepositorio : Repositorio<Segmento>, ISegmentoRepositorio
    {
        public SegmentoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Segmento ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            Segmento retornoSegmento;

            retornoSegmento = cn.Query<Segmento>(SegmentoProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoSegmento;
        }

        public override IEnumerable<Segmento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Segmento> ObterPorDescricao(string descricao)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Segmento> retornoSegmento;

            retornoSegmento = cn.Query<Segmento>(SegmentoProcedures.ObterPorDescricao.GetDescription(),
                new { descricao = descricao },
                commandType: CommandType.StoredProcedure);

            return retornoSegmento;
        }
    }
}
