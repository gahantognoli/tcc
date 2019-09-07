using Dapper;
using Slapper;
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

        public override ItemPedido ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            ItemPedido retornoItemPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(ItemPedidoProcedures.ObterPorId.GetDescription(),
                new
                {
                    Id = id,
                },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            AutoMapper.Configuration.AddIdentifier(typeof(Produto), "ProdutoId");

            retornoItemPedido = (AutoMapper.MapDynamic<ItemPedido>(query, false) as IEnumerable<ItemPedido>).FirstOrDefault();

            return retornoItemPedido;
        }

        public IEnumerable<ItemPedido> ObterPorProduto(Guid produtoId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<ItemPedido> retornoItemPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(ItemPedidoProcedures.ObterProduto.GetDescription(),
                new
                {
                    IdProduto = produtoId,
                },
                commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Produto), "ProdutoId");

            retornoItemPedido = (AutoMapper.MapDynamic<ItemPedido>(query, false) as IEnumerable<ItemPedido>);

            return retornoItemPedido;
        }

        public override IEnumerable<ItemPedido> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemPedido> ObterTodos(Guid pedidoId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<ItemPedido> retornoItemPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(ItemPedidoProcedures.ObterTodos.GetDescription(),
                new
                {
                    pedidoId = pedidoId,
                },
                commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Produto), "ProdutoId");

            retornoItemPedido = (AutoMapper.MapDynamic<ItemPedido>(query, false) as IEnumerable<ItemPedido>);

            return retornoItemPedido;
        }
    }
}
