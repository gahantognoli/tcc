using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum StatusPedidoProcedures
    {
        [Description("usp_StatusPedido_ObterPorId")]
        ObterPorId,
        [Description("usp_StatusPedido_ObterPorDescricao")]    
        ObterPorDescricao,
        [Description("usp_StatusPedido_ObterTodos")]
        ObterTodos
    }
}
