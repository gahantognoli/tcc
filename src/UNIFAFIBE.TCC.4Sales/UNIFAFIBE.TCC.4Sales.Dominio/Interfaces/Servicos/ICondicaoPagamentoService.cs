using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface ICondicaoPagamentoService : IDisposable
    {
        CondicaoPagamento Adicionar(CondicaoPagamento condicaoPagamento);
        CondicaoPagamento Atualizar(CondicaoPagamento condicaoPagamento);
        void Remover(int id);
        CondicaoPagamento ObterPorId(int id);
        IEnumerable<CondicaoPagamento> ObterTodos(int representadaId);
    }
}
