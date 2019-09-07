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
    public class ParcelaRepositorio : Repositorio<Parcela>, IParcelaRepositorio
    {
        public ParcelaRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Parcela ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            Parcela retornoParcela;

            retornoParcela = cn.Query<Parcela>(ParcelaProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoParcela;
        }

        public override IEnumerable<Parcela> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parcela> ObterTodos(Guid faturamentoId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Parcela> retornoParcela;

            retornoParcela = cn.Query<Parcela>(ParcelaProcedures.ObterTodos.GetDescription(),
                new { IdFaturamento = faturamentoId },
                commandType: CommandType.StoredProcedure);

            return retornoParcela;
        }
    }
}
