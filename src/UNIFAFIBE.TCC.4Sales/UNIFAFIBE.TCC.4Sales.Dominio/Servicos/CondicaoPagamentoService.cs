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
            if (!condicaoPagamento.EhValido(_condicaoPagamentoRepositorio))
                return condicaoPagamento;

            return _condicaoPagamentoRepositorio.Adicionar(condicaoPagamento);
        }

        public CondicaoPagamento Atualizar(CondicaoPagamento condicaoPagamento)
        {
            //if (!condicaoPagamento.EstaConsistente())
            //    return condicaoPagamento;

            return _condicaoPagamentoRepositorio.Atualizar(condicaoPagamento);
        }

        public void Dispose()
        {
            _condicaoPagamentoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public CondicaoPagamento ObterPorId(Guid id)
        {
            return _condicaoPagamentoRepositorio.ObterPorId(id);
        }

        public IEnumerable<CondicaoPagamento> ObterTodos(Guid representadaId)
        {
            return _condicaoPagamentoRepositorio.ObterTodos(representadaId);
        }

        public void Remover(Guid id)
        {
            _condicaoPagamentoRepositorio.Remover(id);
        }
    }
}
