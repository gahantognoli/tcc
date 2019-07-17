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
    public class TipoPedidoRepositorio : Repositorio<TipoPedido>, ITipoPedidoRepositorio
    {
        public TipoPedidoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override TipoPedido ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            TipoPedido retornoTipoPedido;

            retornoTipoPedido = cn.Query<TipoPedido>(TipoPedidoProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoTipoPedido;
        }

        public override IEnumerable<TipoPedido> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoPedido> ObterPorDescricao(string tipoPedido)
        {
            var cn = Db.Database.Connection;
            IEnumerable<TipoPedido> retornoTipoPedido;

            retornoTipoPedido = cn.Query<TipoPedido>(TipoPedidoProcedures.ObterPorDescricao.GetDescription(),
                new { tipoPedido = tipoPedido },
                commandType: CommandType.StoredProcedure);

            return retornoTipoPedido;
        }
    }
}
