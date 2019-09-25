using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        Pedido AlterarStatus(Guid statusId, Guid pedidoId);
        IEnumerable<Pedido> ObterTodos(Usuario vendedor);
        Pedido ObterPorNumeroPedido(Usuario vendedor, int numeroPedido);
        int ObterNumeroPedido();
        IEnumerable<Pedido> ObterPorDataEmissao(Usuario vendedor, DateTime dataEmissao);
        IEnumerable<Pedido> ObterPorCliente(Usuario vendedor, string cliente);
        IEnumerable<Pedido> ObterPorCliente(Guid clienteId);
        IEnumerable<Pedido> ObterPorVendedor(string vendedor);
        IEnumerable<Pedido> ObterPorStatus(Usuario vendedor, Guid statusId);
        IEnumerable<Pedido> ObterPorTipo(Usuario vendedor, Guid tipoId);
        IEnumerable<Pedido> ObterPorRepresentada(Usuario vendedor, Guid representadaId);
        IEnumerable<Pedido> ObterPorRepresentada(Guid representadaId);
        IEnumerable<Pedido> ObterPorTransportadora(Guid transportadoraId);
        IEnumerable<Pedido> ObterPorStatus(Guid statusId);
        IEnumerable<Pedido> ObterPorTipo(Guid tipoId);
        IEnumerable<Comissao> ObterComissoes(int mes, int ano);
        void AtualizarPagamentoComissao(Guid parcelaId, bool pago);
    }
}
