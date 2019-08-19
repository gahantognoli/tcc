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
        int ObterNumeroPedido();
        Pedido ObterPorNumeroPedido(Usuario vendedor, int numeroPedido);
        IEnumerable<Pedido> ObterPorDataEmissao(Usuario vendedor, DateTime dataEmissao);
        IEnumerable<Pedido> ObterPorCliente(Usuario vendedor, string cliente);
        IEnumerable<Pedido> ObterPorVendedor(string vendedor);
        IEnumerable<Pedido> ObterPorStatus(Usuario vendedor, Guid statusId);
        IEnumerable<Pedido> ObterPorTipo(Usuario vendedor, Guid tipoId);
        IEnumerable<Pedido> ObterPorRepresentada(Usuario vendedor, Guid representadaId);
        IEnumerable<Pedido> ObterTodos(Usuario vendedor);
        IEnumerable<Pedido> ObterPorRepresentada(Guid representadaId);
    }
}
