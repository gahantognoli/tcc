using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        Pedido ObterPorNumeroPedido(int numeroPedido);
        Pedido ObterPorId(Guid id);
        IEnumerable<Pedido> ObterPorDataEmissao(DateTime dataEmissao);
        IEnumerable<Pedido> ObterPorCliente(string cliente);
        IEnumerable<Pedido> ObterPorVendedor(string usuario);
        IEnumerable<Pedido> ObterPorStatus(Guid statusId);
        IEnumerable<Pedido> ObterPorTipo(Guid tipoId);
        IEnumerable<Pedido> ObterPorRepresentada(Guid representadaId);
    }
}
