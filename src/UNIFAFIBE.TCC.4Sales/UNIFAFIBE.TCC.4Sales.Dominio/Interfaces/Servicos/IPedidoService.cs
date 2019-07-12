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
        void Remover(int id);
        void VisualizarEmDocumento(int id);
        void EnviarPorEmail(int pedidoId, int usuarioId, string[] destinatarios, 
            string assunto = null, string corpo = null);
        Pedido AtualizarStatus(int statusId);
        Pedido ObterPorId(int id);
        Pedido ObterPorNumeroPedido(int numeroPedido);
        IEnumerable<Pedido> ObterPorDataEmissao(DateTime dataEmissao);
        IEnumerable<Pedido> ObterPorCliente(string cliente);
        IEnumerable<Pedido> ObterPorVendedor(string usuario);
        IEnumerable<Pedido> ObterPorStatus(int statusId);
        IEnumerable<Pedido> ObterPorTipo(int tipoId);
        IEnumerable<Pedido> ObterPorRepresentada(int representadaId);
        IEnumerable<Pedido> ObterTodos();
    }
}
