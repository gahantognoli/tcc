using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface ITipoPedidoService : IDisposable
    {
        TipoPedido Adicionar(TipoPedido tipoPedido);
        TipoPedido Atualizar(TipoPedido tipoPedido);
        TipoPedido Remover(Guid id);
        TipoPedido ObterPorId(Guid id);
        IEnumerable<TipoPedido> ObterPorDescricao(string tipoPedido);
        IEnumerable<TipoPedido> ObterTodos();
    }
}
