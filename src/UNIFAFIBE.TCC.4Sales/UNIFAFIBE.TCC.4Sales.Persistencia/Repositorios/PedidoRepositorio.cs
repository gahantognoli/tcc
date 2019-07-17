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
    public class PedidoRepositorio : Repositorio<Pedido>, IPedidoRepositorio
    {

        public PedidoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Pedido ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            Pedido retornoPedido;

            retornoPedido = cn.Query<Pedido>(PedidoProcedures.ObterPorId.GetDescription(), 
                new { id = id}, 
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoPedido;
        }

        public override IEnumerable<Pedido> ObterTodos()
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            retornoPedido = cn.Query<Pedido>(PedidoProcedures.ObterTodos.GetDescription(),
                null,
                commandType: CommandType.StoredProcedure);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorCliente(string cliente)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            retornoPedido = cn.Query<Pedido>(PedidoProcedures.ObterPorCliente.GetDescription(),
                new { cliente = cliente },
                commandType: CommandType.StoredProcedure);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorDataEmissao(DateTime dataEmissao)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            retornoPedido = cn.Query<Pedido>(PedidoProcedures.ObterPorDataEmissao.GetDescription(),
                new { dataEmissao = dataEmissao },
                commandType: CommandType.StoredProcedure);

            return retornoPedido;
        }

        public Pedido ObterPorNumeroPedido(int numeroPedido)
        {
            var cn = Db.Database.Connection;
            Pedido retornoPedido;

            retornoPedido = cn.Query<Pedido>(PedidoProcedures.ObterPorNumeroPedido.GetDescription(),
                new { numeroPedido = numeroPedido },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorRepresentada(Guid representadaId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            retornoPedido = cn.Query<Pedido>(PedidoProcedures.ObterPorRepresentada.GetDescription(),
                new { representadaId = representadaId },
                commandType: CommandType.StoredProcedure);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorStatus(Guid statusId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            retornoPedido = cn.Query<Pedido>(PedidoProcedures.ObterPorStatus.GetDescription(),
                new { statusId = statusId },
                commandType: CommandType.StoredProcedure);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorTipo(Guid tipoId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            retornoPedido = cn.Query<Pedido>(PedidoProcedures.ObterPorTipo.GetDescription(),
                new { tipoId = tipoId },
                commandType: CommandType.StoredProcedure);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorVendedor(string usuario)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            retornoPedido = cn.Query<Pedido>(PedidoProcedures.ObterPorVendedor.GetDescription(),
                new { usuario = usuario },
                commandType: CommandType.StoredProcedure);

            return retornoPedido;
        }
    }
}
