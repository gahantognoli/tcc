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
    public class ContatoRepresentadaRepositorio : Repositorio<ContatoRepresentada>, IContatoRepresentadaRepositorio
    {
        public ContatoRepresentadaRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override ContatoRepresentada ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            ContatoRepresentada retornoContatoRepresentada;

            retornoContatoRepresentada = cn.Query<ContatoRepresentada>(ContatoRepresentadaProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoContatoRepresentada;
        }

        public override IEnumerable<ContatoRepresentada> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContatoRepresentada> ObterTodos(Guid representadaId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<ContatoRepresentada> retornoContatoRepresentada;

            retornoContatoRepresentada = cn.Query<ContatoRepresentada>(ContatoRepresentadaProcedures.ObterTodos.GetDescription(),
                new { representadaId = representadaId },
                commandType: CommandType.StoredProcedure);

            return retornoContatoRepresentada;
        }
    }
}
