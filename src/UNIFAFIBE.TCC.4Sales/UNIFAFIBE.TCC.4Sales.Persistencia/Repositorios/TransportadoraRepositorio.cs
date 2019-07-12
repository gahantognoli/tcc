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
    public class TransportadoraRepositorio : Repositorio<Transportadora>, ITransportadoraRepositorio
    {
        public TransportadoraRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Transportadora ObterPorId(int id)
        {
            var cn = Db.Database.Connection;
            Transportadora retornoTransportadora;

            retornoTransportadora = cn.Query<Transportadora>(TransportadoraProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoTransportadora;
        }

        public override IEnumerable<Transportadora> ObterTodos()
        {
            var cn = Db.Database.Connection;
            IEnumerable<Transportadora> retornoTransportadora;

            retornoTransportadora = cn.Query<Transportadora>(TransportadoraProcedures.ObterTodos.GetDescription(),
                null,
                commandType: CommandType.StoredProcedure);

            return retornoTransportadora;
        }

        public IEnumerable<Transportadora> ObterPorCidade(string cidade)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Transportadora> retornoTransportadora;

            retornoTransportadora = cn.Query<Transportadora>(TransportadoraProcedures.ObterPorCidade.GetDescription(),
                new { cidade = cidade },
                commandType: CommandType.StoredProcedure);

            return retornoTransportadora;
        }

        public IEnumerable<Transportadora> ObterPorEstado(string estado)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Transportadora> retornoTransportadora;

            retornoTransportadora = cn.Query<Transportadora>(TransportadoraProcedures.ObterPorEstado.GetDescription(),
                new { estado = estado },
                commandType: CommandType.StoredProcedure);

            return retornoTransportadora;
        }

        public IEnumerable<Transportadora> ObterPorNome(string nome)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Transportadora> retornoTransportadora;

            retornoTransportadora = cn.Query<Transportadora>(TransportadoraProcedures.ObterPorNome.GetDescription(),
                new { nome = nome },
                commandType: CommandType.StoredProcedure);

            return retornoTransportadora;
        }
    }
}
