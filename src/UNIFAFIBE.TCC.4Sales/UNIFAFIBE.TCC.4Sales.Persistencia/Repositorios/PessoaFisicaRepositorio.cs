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
    public class PessoaFisicaRepositorio : Repositorio<PessoaFisica>, IPessoaFisicaRepositorio
    {
        public PessoaFisicaRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override PessoaFisica ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            PessoaFisica retornoCliente;

            retornoCliente = cn.Query<PessoaFisica>(PessoaFisicaProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoCliente;
        }

        public override IEnumerable<PessoaFisica> ObterTodos()
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaFisica> retornoCliente;

            retornoCliente = cn.Query<PessoaFisica>(PessoaFisicaProcedures.ObterTodos.GetDescription(),
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaFisica> ObterPorCPF(string cpf)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaFisica> retornoCliente;

            retornoCliente = cn.Query<PessoaFisica>(PessoaFisicaProcedures.ObterPorCPF.GetDescription(),
                new { cpf = cpf },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaFisica> ObterPorNome(string nome)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaFisica> retornoCliente;

            retornoCliente = cn.Query<PessoaFisica>(PessoaFisicaProcedures.ObterPorNome.GetDescription(),
                new { nome = nome },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }
    }
}
