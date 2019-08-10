using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Infra.Helpers;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;
using UNIFAFIBE.TCC._4Sales.Persistencia.Procedures;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class RepresentadaRepositorio : Repositorio<Representada>, IRepresentadaRepositorio
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IContatoRepresentadaRepositorio _contatoRepresentadaRepositorio;
        private readonly ICondicaoPagamentoRepositorio _condicaoPagamentoRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public RepresentadaRepositorio(TCC_Contexto contexto,
            IPedidoRepositorio pedidoRepositorio, IContatoRepresentadaRepositorio contatoRepresentadaRepositorio,
            ICondicaoPagamentoRepositorio condicaoPagamentoRepositorio, IProdutoRepositorio produtoRepositorio) : base(contexto)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _contatoRepresentadaRepositorio = contatoRepresentadaRepositorio;
            _condicaoPagamentoRepositorio = condicaoPagamentoRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public override Representada Atualizar(Representada representada)
        {
            Representada existingRepresentada = Db.Representadas.
                Include("CondicoesPagamento").Include("ContatosRepresentada")
                 .Where(r => r.RepresentadaId == representada.RepresentadaId).FirstOrDefault<Representada>();

            List<CondicaoPagamento> deletedCondicoesPagamento = existingRepresentada.CondicoesPagamento.Except(representada.CondicoesPagamento, c => c.CondicaoPagamentoId).ToList<CondicaoPagamento>();
            List<ContatoRepresentada> deletedContatos = existingRepresentada.ContatosRepresentada.Except(representada.ContatosRepresentada, c => c.ContatoRepresentadaId).ToList<ContatoRepresentada>();


            List<CondicaoPagamento> addedCondicoesPagamento = representada.CondicoesPagamento.Except(existingRepresentada.CondicoesPagamento, c => c.CondicaoPagamentoId).ToList<CondicaoPagamento>();
            List<ContatoRepresentada> addedContatos = representada.ContatosRepresentada.Except(existingRepresentada.ContatosRepresentada, c => c.ContatoRepresentadaId).ToList<ContatoRepresentada>();

            if (deletedCondicoesPagamento.Count() > 0 || deletedContatos.Count() > 0)
            {
                deletedCondicoesPagamento.ForEach(c => { existingRepresentada.CondicoesPagamento.Remove(c); _condicaoPagamentoRepositorio.Remover(c.CondicaoPagamentoId); });
                deletedContatos.ForEach(c => { existingRepresentada.ContatosRepresentada.Remove(c); _contatoRepresentadaRepositorio.Remover(c.ContatoRepresentadaId); });
            }

            if (addedCondicoesPagamento.Count() > 0 || addedContatos.Count() > 0)
            {
                foreach (ContatoRepresentada c in addedContatos)
                {
                    c.RepresentadaId = representada.RepresentadaId;
                    if (Db.Entry(c).State == System.Data.Entity.EntityState.Detached)
                    {
                        Db.ContatosRepresentada.Attach(c);
                    }

                    _contatoRepresentadaRepositorio.Adicionar(c);
                }

              
                foreach (CondicaoPagamento c in addedCondicoesPagamento)
                {
                    c.RepresentadaId = representada.RepresentadaId;
                    if (Db.Entry(c).State == System.Data.Entity.EntityState.Detached)
                    {
                        Db.CondicoesPagamento.Attach(c);
                    }

                    _condicaoPagamentoRepositorio.Adicionar(c);
                }
            }

            Db.Set<Representada>().AddOrUpdate(representada);

            List<ContatoRepresentada> modifiedContatos = representada.ContatosRepresentada.Except(addedContatos, c => c.ContatoRepresentadaId).ToList<ContatoRepresentada>();
            List<CondicaoPagamento> modifiedCondicoesPagamento = representada.CondicoesPagamento.Except(addedCondicoesPagamento, c => c.CondicaoPagamentoId).ToList<CondicaoPagamento>();

            foreach (var item in modifiedContatos)
            {
                Db.Set<ContatoRepresentada>().AddOrUpdate(item);
            }

            foreach (var item in modifiedCondicoesPagamento)
            {
                Db.Set<CondicaoPagamento>().AddOrUpdate(item);
            }

            return existingRepresentada;
        }

        public override Representada ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            Representada retornoRepresentada;

            retornoRepresentada = cn.Query<Representada>(RepresentadaProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoRepresentada;
        }

        public override IEnumerable<Representada> ObterTodos()
        {
            var cn = Db.Database.Connection;
            IEnumerable<Representada> retornoRepresentada;

            retornoRepresentada = cn.Query<Representada>(RepresentadaProcedures.ObterTodos.GetDescription(),
                commandType: CommandType.StoredProcedure);

            return retornoRepresentada;
        }

        public IEnumerable<Representada> ObterPorCnpj(string cnpj)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Representada> retornoRepresentada;

            retornoRepresentada = cn.Query<Representada>(RepresentadaProcedures.ObterPorCnpj.GetDescription(),
                new { cnpj = cnpj },
                commandType: CommandType.StoredProcedure);

            return retornoRepresentada;
        }

        public IEnumerable<Representada> ObterPorNomeFantansia(string nomeFantasia)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Representada> retornoRepresentada;

            retornoRepresentada = cn.Query<Representada>(RepresentadaProcedures.ObterPorNomeFantasia.GetDescription(),
                new { nomeFantasia = nomeFantasia },
                commandType: CommandType.StoredProcedure);

            return retornoRepresentada;
        }

        public IEnumerable<Representada> ObterPorRazaoSocial(string razaoSocial)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Representada> retornoRepresentada;

            retornoRepresentada = cn.Query<Representada>(RepresentadaProcedures.ObterPorRazaoSocial.GetDescription(),
                new { razaoSocial = razaoSocial },
                commandType: CommandType.StoredProcedure);

            return retornoRepresentada;
        }
    }
}
