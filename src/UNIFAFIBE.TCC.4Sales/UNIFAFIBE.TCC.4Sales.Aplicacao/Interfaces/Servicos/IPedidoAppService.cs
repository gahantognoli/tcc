using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IPedidoAppService
    {
        PedidoViewModel GerarPedido(PedidoViewModel pedido);
        PedidoViewModel GerarOrcamento(PedidoViewModel pedido);
        PedidoViewModel Atualizar(PedidoViewModel pedido);
        void Remover(Guid id);
        void VisualizarEmDocumento(Guid id);
        void EnviarPorEmail(Guid pedidoId, Guid usuarioId, string[] destinatarios,
            string assunto = null, string corpo = null);
        PedidoViewModel AtualizarStatus(Guid statusId);
        PedidoViewModel ObterPorId(Guid id);
        PedidoViewModel ObterPorNumeroPedido(int numeroPedido);
        IEnumerable<PedidoViewModel> ObterPorDataEmissao(DateTime dataEmissao);
        IEnumerable<PedidoViewModel> ObterPorCliente(string cliente);
        IEnumerable<PedidoViewModel> ObterPorVendedor(string usuario);
        IEnumerable<PedidoViewModel> ObterPorStatus(Guid statusId);
        IEnumerable<PedidoViewModel> ObterPorTipo(Guid tipoId);
        IEnumerable<PedidoViewModel> ObterPorRepresentada(Guid representadaId);
        IEnumerable<PedidoViewModel> ObterTodos();
    }
}
