using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class CondicaoPagamentoService : ICondicaoPagamentoService
    {
        private readonly ICondicaoPagamentoRepositorio _condicaoPagamentoRepositorio;

        public CondicaoPagamentoService(ICondicaoPagamentoRepositorio condicaoPagamentoRepositorio)
        {
            _condicaoPagamentoRepositorio = condicaoPagamentoRepositorio;
        }

        public CondicaoPagamento Adicionar(CondicaoPagamento condicaoPagamento)
        {
            return _condicaoPagamentoRepositorio.Adicionar(condicaoPagamento);
        }

        public CondicaoPagamento Atualizar(CondicaoPagamento condicaoPagamento)
        {
            return _condicaoPagamentoRepositorio.Atualizar(condicaoPagamento);
        }

        public void Dispose()
        {
            _condicaoPagamentoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public CondicaoPagamento ObterPorId(int id)
        {
            return _condicaoPagamentoRepositorio.ObterPorId(id);
        }

        public IEnumerable<CondicaoPagamento> ObterTodos(int representadaId)
        {
            return _condicaoPagamentoRepositorio.ObterTodos(representadaId);
        }

        public void Remover(int id)
        {
            _condicaoPagamentoRepositorio.Remover(id);
        }
    }
}
