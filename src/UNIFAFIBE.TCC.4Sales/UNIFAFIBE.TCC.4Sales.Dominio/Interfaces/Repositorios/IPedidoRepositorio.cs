using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        IEnumerable<Pedido> ObterTodos(Usuario vendedor);
        Pedido ObterPorNumeroPedido(Usuario vendedor, int numeroPedido);
        int ObterNumeroPedido();
        IEnumerable<Pedido> ObterPorDataEmissao(Usuario vendedor, DateTime dataEmissao);
        IEnumerable<Pedido> ObterPorCliente(Usuario vendedor, string cliente);
        IEnumerable<Pedido> ObterPorVendedor(string vendedor);
        IEnumerable<Pedido> ObterPorStatus(Usuario vendedor, Guid statusId);
        IEnumerable<Pedido> ObterPorTipo(Usuario vendedor, Guid tipoId);
        IEnumerable<Pedido> ObterPorRepresentada(Usuario vendedor, Guid representadaId);
        IEnumerable<Pedido> ObterPorRepresentada(Guid representadaId);
    }
}
