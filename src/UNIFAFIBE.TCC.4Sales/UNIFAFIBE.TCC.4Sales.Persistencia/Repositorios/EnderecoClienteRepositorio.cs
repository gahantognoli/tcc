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
    public class EnderecoClienteRepositorio : Repositorio<EnderecoCliente>, IEnderecoClienteRepositorio
    {
        public EnderecoClienteRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override EnderecoCliente ObterPorId(int id)
        {
            var cn = Db.Database.Connection;
            EnderecoCliente retornoEnderecoCliente;

            retornoEnderecoCliente = cn.Query<EnderecoCliente>(EnderecoClienteProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoEnderecoCliente;
        }

        public override IEnumerable<EnderecoCliente> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EnderecoCliente> ObterTodos(int clienteId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<EnderecoCliente> retornoEnderecoCliente;

            retornoEnderecoCliente = cn.Query<EnderecoCliente>(EnderecoClienteProcedures.ObterTodos.GetDescription(),
                new { clienteId = clienteId },
                commandType: CommandType.StoredProcedure);

            return retornoEnderecoCliente;
        }
    }
}
