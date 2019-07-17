using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IStatusPedidoService : IDisposable
    {
        StatusPedido Adicionar(StatusPedido statusPedido);
        StatusPedido Atualizar(StatusPedido statusPedido);
        void Remover(Guid id);
        StatusPedido ObterPorId(Guid id);
        IEnumerable<StatusPedido> ObterPorDescricao(string descricao);
        IEnumerable<StatusPedido> ObterTodos();
    }
}
