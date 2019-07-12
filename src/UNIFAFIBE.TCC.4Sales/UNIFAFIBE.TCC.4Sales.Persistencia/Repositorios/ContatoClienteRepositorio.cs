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
    public class ContatoClienteRepositorio : Repositorio<ContatoCliente>, IContatoClienteRepositorio
    {
        public ContatoClienteRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override ContatoCliente ObterPorId(int id)
        {
            var cn = Db.Database.Connection;
            ContatoCliente retornoContatoCliente;

            retornoContatoCliente = cn.Query<ContatoCliente>(ContatoClienteProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoContatoCliente;
        }

        public override IEnumerable<ContatoCliente> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContatoCliente> ObterTodos(int clienteId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<ContatoCliente> retornoContatoCliente;

            retornoContatoCliente = cn.Query<ContatoCliente>(ContatoClienteProcedures.ObterTodos.GetDescription(),
                new { clienteId = clienteId },
                commandType: CommandType.StoredProcedure);

            return retornoContatoCliente;
        }
    }
}
