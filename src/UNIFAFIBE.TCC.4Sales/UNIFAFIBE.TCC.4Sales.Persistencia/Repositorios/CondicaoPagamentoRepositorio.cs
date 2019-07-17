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
    public class CondicaoPagamentoRepositorio : Repositorio<CondicaoPagamento>, ICondicaoPagamentoRepositorio
    {
        public CondicaoPagamentoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public IEnumerable<CondicaoPagamento> ObterPorDescricao(string descricao)
        {
            var cn = Db.Database.Connection;
            IEnumerable<CondicaoPagamento> retornoCondicaoPagamento;

            retornoCondicaoPagamento = cn.Query<CondicaoPagamento>(CondicaoPagamentoProcedures.ObterPorDescricao.GetDescription(),
                new { descricao = descricao },
                commandType: CommandType.StoredProcedure);

            return retornoCondicaoPagamento;
        }

        public override CondicaoPagamento ObterPorId(Guid id)
        {
           var cn = Db.Database.Connection;
           CondicaoPagamento retornoCondicaoPagamento;

            retornoCondicaoPagamento = cn.Query<CondicaoPagamento>(CondicaoPagamentoProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoCondicaoPagamento;
        }

        public override IEnumerable<CondicaoPagamento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CondicaoPagamento> ObterTodos(Guid representadaId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<CondicaoPagamento> retornoCondicaoPagamento;

            retornoCondicaoPagamento = cn.Query<CondicaoPagamento>(CondicaoPagamentoProcedures.ObterTodos.GetDescription(),
                new { representadaId = representadaId },
                commandType: CommandType.StoredProcedure);

            return retornoCondicaoPagamento;
        }
    }
}
