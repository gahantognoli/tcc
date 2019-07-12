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
    public class ItemPedidoRepositorio : Repositorio<ItemPedido>, IItemPedidoRepositorio
    {
        public ItemPedidoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override ItemPedido ObterPorId(int id)
        {
            var cn = Db.Database.Connection;
            ItemPedido retornoItemPedido;

            retornoItemPedido = cn.Query<ItemPedido>(ItemPedidoProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoItemPedido;
        }

        public override IEnumerable<ItemPedido> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemPedido> ObterTodos(int pedidoId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<ItemPedido> retornoItemPedido;

            retornoItemPedido = cn.Query<ItemPedido>(ItemPedidoProcedures.ObterTodos.GetDescription(),
                new { pedidoId = pedidoId },
                commandType: CommandType.StoredProcedure);

            return retornoItemPedido;
        }
    }
}
