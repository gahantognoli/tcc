using Dapper;
using Slapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        public override Pedido Atualizar(Pedido obj)
        {
            Pedido pedidos = Db.Pedidos.Include("ItensPedido")
                .Where(e => e.PedidoId == obj.PedidoId).FirstOrDefault();

            List<ItemPedido> deletedItensPedido = pedidos.ItensPedido.Except(obj.ItensPedido, p => p.ItemPedidoId).ToList<ItemPedido>();
            List<ItemPedido> AddItensPedido = obj.ItensPedido.Except(pedidos.ItensPedido, p => p.ItemPedidoId).ToList<ItemPedido>();

            foreach (var item in deletedItensPedido)
            {
                Db.ItensPedido.Remove(item);
            }

            foreach (ItemPedido p in AddItensPedido)
            {
                if (Db.Entry(p).State == EntityState.Detached)
                {
                    Db.ItensPedido.Attach(p);
                }
                Db.ItensPedido.Add(p);
            }

            Db.Set<Pedido>().AddOrUpdate(obj);

            foreach (var item in obj.ItensPedido)
            {
                Db.Set<ItemPedido>().AddOrUpdate(item);
            }

            return obj;
        }

        public override Pedido ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            Pedido retornoPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PedidoProcedures.ObterPorId.GetDescription(),
                new
                {
                    Id = id,
                },
                commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Cliente), "ClienteId");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaFisica), "Nome");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaJuridica), "RazaoSocial");
            AutoMapper.Configuration.AddIdentifier(typeof(CondicaoPagamento), "CondicaoPagamentoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Representada), "RepresentadaId");
            AutoMapper.Configuration.AddIdentifier(typeof(Transportadora), "TransportadoraId");
            AutoMapper.Configuration.AddIdentifier(typeof(StatusPedido), "StatusPedidoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");

            retornoPedido = (AutoMapper.MapDynamic<Pedido>(query, false) as IEnumerable<Pedido>).FirstOrDefault();

            return retornoPedido;
        }

        public override IEnumerable<Pedido> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> ObterPorCliente(Usuario vendedor, string cliente)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PedidoProcedures.ObterPorCliente.GetDescription(),
                new
                {
                    @NomeOuRazaoSocial = cliente,
                    @idVendedor = vendedor.UsuarioId,
                    @responsavelSistema = vendedor.UsuarioResponsavel
                },
                commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Cliente), "ClienteId");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaFisica), "Nome");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaJuridica), "RazaoSocial");
            AutoMapper.Configuration.AddIdentifier(typeof(Representada), "RepresentadaId");
            AutoMapper.Configuration.AddIdentifier(typeof(StatusPedido), "StatusPedidoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");

            retornoPedido = (AutoMapper.MapDynamic<Pedido>(query, false) as IEnumerable<Pedido>);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorDataEmissao(Usuario vendedor, DateTime dataEmissao)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PedidoProcedures.ObterPorDataEmissao.GetDescription(),
               new
               {
                   @DataEmissao = dataEmissao.ToString(),
                   @idVendedor = vendedor.UsuarioId,
                   @responsavelSistema = vendedor.UsuarioResponsavel
               },
               commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Cliente), "ClienteId");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaFisica), "Nome");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaJuridica), "RazaoSocial");
            AutoMapper.Configuration.AddIdentifier(typeof(Representada), "RepresentadaId");
            AutoMapper.Configuration.AddIdentifier(typeof(StatusPedido), "StatusPedidoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");

            retornoPedido = (AutoMapper.MapDynamic<Pedido>(query, false) as IEnumerable<Pedido>);

            return retornoPedido;
        }

        public Pedido ObterPorNumeroPedido(Usuario vendedor, int numeroPedido)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PedidoProcedures.ObterPorNumeroPedido.GetDescription(),
               new
               {
                   @numeroPedido = numeroPedido,
                   @idVendedor = vendedor.UsuarioId,
                   @responsavelSistema = vendedor.UsuarioResponsavel
               },
               commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Cliente), "ClienteId");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaFisica), "Nome");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaJuridica), "RazaoSocial");
            AutoMapper.Configuration.AddIdentifier(typeof(Representada), "RepresentadaId");
            AutoMapper.Configuration.AddIdentifier(typeof(StatusPedido), "StatusPedidoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");

            retornoPedido = (AutoMapper.MapDynamic<Pedido>(query, false) as IEnumerable<Pedido>);

            return retornoPedido.FirstOrDefault();
        }

        public IEnumerable<Pedido> ObterPorRepresentada(Usuario vendedor, Guid representadaId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PedidoProcedures.ObterPorRepresentada.GetDescription(),
               new
               {
                   @representadaId = representadaId,
                   @idVendedor = vendedor.UsuarioId,
                   @responsavelSistema = vendedor.UsuarioResponsavel
               },
               commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Cliente), "ClienteId");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaFisica), "Nome");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaJuridica), "RazaoSocial");
            AutoMapper.Configuration.AddIdentifier(typeof(Representada), "RepresentadaId");
            AutoMapper.Configuration.AddIdentifier(typeof(StatusPedido), "StatusPedidoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");

            retornoPedido = (AutoMapper.MapDynamic<Pedido>(query, false) as IEnumerable<Pedido>);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorStatus(Usuario vendedor, Guid statusId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PedidoProcedures.ObterPorStatus.GetDescription(),
               new
               {
                   @statusId = statusId,
                   @idVendedor = vendedor.UsuarioId,
                   @responsavelSistema = vendedor.UsuarioResponsavel
               },
               commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Cliente), "ClienteId");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaFisica), "Nome");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaJuridica), "RazaoSocial");
            AutoMapper.Configuration.AddIdentifier(typeof(Representada), "RepresentadaId");
            AutoMapper.Configuration.AddIdentifier(typeof(StatusPedido), "StatusPedidoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");

            retornoPedido = (AutoMapper.MapDynamic<Pedido>(query, false) as IEnumerable<Pedido>);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorTipo(Usuario vendedor, Guid tipoId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PedidoProcedures.ObterPorTipo.GetDescription(),
               new
               {
                   @tipoId = tipoId,
                   @idVendedor = vendedor.UsuarioId,
                   @responsavelSistema = vendedor.UsuarioResponsavel
               },
               commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Cliente), "ClienteId");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaFisica), "Nome");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaJuridica), "RazaoSocial");
            AutoMapper.Configuration.AddIdentifier(typeof(Representada), "RepresentadaId");
            AutoMapper.Configuration.AddIdentifier(typeof(StatusPedido), "StatusPedidoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");

            retornoPedido = (AutoMapper.MapDynamic<Pedido>(query, false) as IEnumerable<Pedido>);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorVendedor(string vendedor)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PedidoProcedures.ObterPorVendedor.GetDescription(),
               new
               {
                   @usuario = vendedor
               },
               commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Cliente), "ClienteId");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaFisica), "Nome");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaJuridica), "RazaoSocial");
            AutoMapper.Configuration.AddIdentifier(typeof(Representada), "RepresentadaId");
            AutoMapper.Configuration.AddIdentifier(typeof(StatusPedido), "StatusPedidoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");

            retornoPedido = (AutoMapper.MapDynamic<Pedido>(query, false) as IEnumerable<Pedido>);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterTodos(Usuario vendedor)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PedidoProcedures.ObterTodos.GetDescription(),
                new { @idVendedor = vendedor.UsuarioId, @responsavelSistema = vendedor.UsuarioResponsavel },
                commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Cliente), "ClienteId");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaFisica), "Nome");
            AutoMapper.Configuration.AddIdentifier(typeof(PessoaJuridica), "RazaoSocial");
            AutoMapper.Configuration.AddIdentifier(typeof(Representada), "RepresentadaId");
            AutoMapper.Configuration.AddIdentifier(typeof(StatusPedido), "StatusPedidoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");

            retornoPedido = (AutoMapper.MapDynamic<Pedido>(query, false) as IEnumerable<Pedido>);

            return retornoPedido;
        }

        public IEnumerable<Pedido> ObterPorRepresentada(Guid representadaId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Pedido> retornoPedido;

            retornoPedido = cn.Query<Pedido>(PedidoProcedures.ObterPorRepresentadaRemover.GetDescription(),
                new { @idRepresentada = representadaId },
                commandType: CommandType.StoredProcedure);

            return retornoPedido;
        }

        public int ObterNumeroPedido()
        {
            var cn = Db.Database.Connection;

            int numeroPedido = cn.Query<int>(PedidoProcedures.ObterNumeroPedido.GetDescription(),
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return numeroPedido;
        }

        public Pedido AlterarStatus(Guid statusId, Guid pedidoId)
        {
            var pedido = DbSet.Find(pedidoId);
            pedido.StatusPedidoId = statusId;
            return pedido;
        }
    }
}
