using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum TipoPedidoProcedures
    {
        [Description("usp_TipoPedido_ObterPorId")]
        ObterPorId,
        [Description("usp_TipoPedido_ObterPorDescricao")]
        ObterPorDescricao,
        [Description("usp_TipoPedido_ObterTodos")]
        ObterTodos
    }
}
