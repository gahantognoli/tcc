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
    public class FaturamentoRepositorio : Repositorio<Faturamento>, IFaturamentoRepositorio
    {

        public FaturamentoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Faturamento ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            Faturamento retornoFaturamento;

            retornoFaturamento = cn.Query<Faturamento>(FaturamentoProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoFaturamento;
        }

        public override IEnumerable<Faturamento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Faturamento> ObterTodos(Guid pedidoId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Faturamento> retornoFaturamento;

            retornoFaturamento = cn.Query<Faturamento>(FaturamentoProcedures.ObterTodos.GetDescription(),
                new { pedidoId = pedidoId },
                commandType: CommandType.StoredProcedure);

            return retornoFaturamento;
        }
    }
}
