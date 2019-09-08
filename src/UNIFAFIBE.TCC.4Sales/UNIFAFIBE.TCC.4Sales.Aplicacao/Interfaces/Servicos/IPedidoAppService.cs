using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IPedidoAppService : IDisposable
    {
        PedidoViewModel GerarPedido(PedidoViewModel pedido);
        PedidoViewModel GerarOrcamento(PedidoViewModel pedido);
        PedidoViewModel Atualizar(PedidoViewModel pedido);
        PedidoViewModel AlterarStatus(Guid statusId, Guid pedidoId);
        void Remover(Guid id);
        void VisualizarEmDocumento(Guid id);
        void EnviarPorEmail(Guid pedidoId, Guid usuarioId, string[] destinatarios,
            string assunto = null, string corpo = null);
        PedidoViewModel ObterPorId(Guid id);
        int ObterNumeroPedido();
        PedidoViewModel ObterPorNumeroPedido(UsuarioViewModel vendedor, int numeroPedido);
        IEnumerable<PedidoViewModel> ObterPorDataEmissao(UsuarioViewModel vendedor, DateTime dataEmissao);
        IEnumerable<PedidoViewModel> ObterPorCliente(UsuarioViewModel vendedor, string cliente);
        IEnumerable<PedidoViewModel> ObterPorVendedor(string vendedor);
        IEnumerable<PedidoViewModel> ObterPorStatus(UsuarioViewModel vendedor, Guid statusId);
        IEnumerable<PedidoViewModel> ObterPorTipo(UsuarioViewModel vendedor, Guid tipoId);
        IEnumerable<PedidoViewModel> ObterPorRepresentada(UsuarioViewModel vendedor, Guid representadaId);
        IEnumerable<PedidoViewModel> ObterTodos(UsuarioViewModel vendedor);
        IEnumerable<PedidoViewModel> ObterPorRepresentada(Guid representadaId);
        IEnumerable<PedidoViewModel> ObterPorCliente(Guid clienteId);
        IEnumerable<PedidoViewModel> ObterPorTransportadora(Guid transportadoraId);
        IEnumerable<PedidoViewModel> ObterPorStatus(Guid statusId);
        IEnumerable<PedidoViewModel> ObterPorTipo(Guid tipoId);
    }
}
