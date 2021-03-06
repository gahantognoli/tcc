﻿using Dapper;
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
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Produto ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            Produto retornoProduto;

            retornoProduto = cn.Query<Produto>(ProdutoProcedures.ObterPorId.GetDescription(),
                new { idProduto = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoProduto;
        }

        public override IEnumerable<Produto> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ObterPorFaixaDePreco(decimal valorInicial, decimal valorFinal, Guid representadaId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Produto> retornoProduto;

            retornoProduto = cn.Query<Produto>(ProdutoProcedures.ObterPorFaixaDePreco.GetDescription(),
                new { valorInicial = valorInicial, valorFinal = valorFinal, representadaId = representadaId },
                commandType: CommandType.StoredProcedure);

            return retornoProduto;
        }

        public IEnumerable<Produto> ObterPorNome(string nome, Guid representadaId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Produto> retornoProduto;

            retornoProduto = cn.Query<Produto>(ProdutoProcedures.ObterPorNome.GetDescription(),
                new { nome = nome, representadaId = representadaId },
                commandType: CommandType.StoredProcedure);

            return retornoProduto;
        }

        public IEnumerable<Produto> ObterTodos(Guid representadaId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Produto> retornoProduto;

            retornoProduto = cn.Query<Produto>(ProdutoProcedures.ObterTodos.GetDescription(),
                new { representadaId = representadaId },
                commandType: CommandType.StoredProcedure);

            return retornoProduto;
        }

        public Produto ObterPorCodigo(string codigo, Guid representadaId)
        {
            var cn = Db.Database.Connection;
            Produto retornoProduto;

            retornoProduto = cn.Query<Produto>(ProdutoProcedures.ObterPorCodigo.GetDescription(),
                new { codigo = codigo, representadaId = representadaId },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoProduto;
        }
    }
}
