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
    public class PessoaJuridicaRepositorio : Repositorio<PessoaJuridica>, IPessoaJuridicaRepositorio
    {
        public PessoaJuridicaRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override PessoaJuridica ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            PessoaJuridica retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoCliente;
        }

        public override IEnumerable<PessoaJuridica> ObterTodos()
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaJuridica> retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterTodos.GetDescription(),
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaJuridica> ObterPorCPNJ(string cnpj)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaJuridica> retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterPorCNPJ.GetDescription(),
                new { cnpj = cnpj },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaJuridica> ObterPorInscricaoEstadual(string inscricaoEstadual)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaJuridica> retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterPorInscricaoEstadual.GetDescription(),
                new { inscricaoEstadual = inscricaoEstadual },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaJuridica> ObterPorNomeFantasia(string nomeFantasia)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaJuridica> retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterPorNomeFantasia.GetDescription(),
                new { nomeFantasia = nomeFantasia },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaJuridica> ObterPorRazaoSocial(string razaoSocial)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaJuridica> retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterPorRazaoSocial.GetDescription(),
                new { razaoSocial = razaoSocial },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }
    }
}
