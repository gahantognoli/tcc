﻿using System;
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
        IEnumerable<Pedido> ObterPorStatus(int statusId);
        IEnumerable<Pedido> ObterPorTipo(int tipoId);
        IEnumerable<Pedido> ObterPorRepresentada(int representadaId);
    }
}
