using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IPedidoService : IDisposable
    {
        Pedido GerarPedido(Pedido pedido);
        Pedido GerarOrcamento(Pedido pedido);
        Pedido Atualizar(Pedido pedido);
        void Remover(Guid id);
        void VisualizarEmDocumento(Guid id);
        void EnviarPorEmail(Guid pedidoId, Guid usuarioId, string[] destinatarios, 
            string assunto = null, string corpo = null);
        Pedido AtualizarStatus(Guid statusId);
        Pedido ObterPorId(Guid id);
        Pedido ObterPorNumeroPedido(int numeroPedido);
        IEnumerable<Pedido> ObterPorDataEmissao(DateTime dataEmissao);
        IEnumerable<Pedido> ObterPorCliente(string cliente);
        IEnumerable<Pedido> ObterPorVendedor(string usuario);
        IEnumerable<Pedido> ObterPorStatus(Guid statusId);
        IEnumerable<Pedido> ObterPorTipo(Guid tipoId);
        IEnumerable<Pedido> ObterPorRepresentada(Guid representadaId);
        IEnumerable<Pedido> ObterTodos();
    }
}
