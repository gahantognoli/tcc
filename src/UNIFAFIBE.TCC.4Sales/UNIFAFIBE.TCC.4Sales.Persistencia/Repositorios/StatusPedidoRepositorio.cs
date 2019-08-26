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
    public class StatusPedidoRepositorio : Repositorio<StatusPedido>, IStatusPedidoRepositorio
    {
        public StatusPedidoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override StatusPedido ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            StatusPedido retornoStatusPedido;

            retornoStatusPedido = cn.Query<StatusPedido>(StatusPedidoProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoStatusPedido;
        }

        public override IEnumerable<StatusPedido> ObterTodos()
        {
            var cn = Db.Database.Connection;
            IEnumerable<StatusPedido> retornoStatusPedido;

            retornoStatusPedido = cn.Query<StatusPedido>(StatusPedidoProcedures.ObterTodos.GetDescription(),
                commandType: CommandType.StoredProcedure);

            return retornoStatusPedido;
        }

        public IEnumerable<StatusPedido> ObterPorDescricao(string descricao)
        {
            var cn = Db.Database.Connection;
            IEnumerable<StatusPedido> retornoStatusPedido;

            retornoStatusPedido = cn.Query<StatusPedido>(StatusPedidoProcedures.ObterPorDescricao.GetDescription(),
                new { descricao = descricao },
                commandType: CommandType.StoredProcedure);

            return retornoStatusPedido;
        }

        public IEnumerable<StatusPedido> ObterStatusNaoPadroes()
        {
            var cn = Db.Database.Connection;
            IEnumerable<StatusPedido> retornoStatusPedido;

            retornoStatusPedido = cn.Query<StatusPedido>(StatusPedidoProcedures.ObterNaoPadroes.GetDescription(),
                commandType: CommandType.StoredProcedure);

            return retornoStatusPedido;
        }
    }
}
