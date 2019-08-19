﻿using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum PedidoProcedures
    {
        [Description("usp_Pedido_ObterPorCliente")]
        ObterPorCliente,
        [Description("usp_Pedido_ObterPorDataEmissao")]
        ObterPorDataEmissao,
        [Description("usp_Pedido_ObterPorId")]
        ObterPorId,
        [Description("usp_ObterNumeroPedido")]
        ObterNumeroPedido,
        [Description("usp_Pedido_ObterPorNumeroPedido")]
        ObterPorNumeroPedido,
        [Description("usp_Pedido_ObterPorRepresentada")]
        ObterPorRepresentada,
        [Description("usp_Pedido_ObterPorRepresentadaRemover")]
        ObterPorRepresentadaRemover,
        [Description("usp_Pedido_ObterPorStatus")]
        ObterPorStatus,
        [Description("usp_Pedido_ObterPorTipo")]
        ObterPorTipo,
        [Description("usp_Pedido_ObterPorVendedor")]
        ObterPorVendedor,
        [Description("usp_Pedido_ObterTodos")]
        ObterTodos
    }
}
