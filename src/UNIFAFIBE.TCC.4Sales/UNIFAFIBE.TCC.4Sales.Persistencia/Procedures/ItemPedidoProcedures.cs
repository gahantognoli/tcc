using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum ItemPedidoProcedures
    {
        [Description("usp_ItemPedido_ObterPorId")]
        ObterPorId,
        [Description("usp_ItemPedido_ObterTodos")]
        ObterTodos
    }
}
