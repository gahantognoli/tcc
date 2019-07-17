using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum CondicaoPagamentoProcedures
    {
        [Description("usp_CondicaoPagamento_ObterPorId")]
        ObterPorId,
        [Description("usp_CondicaoPagamento_ObterPorDescricao")]
        ObterPorDescricao,
        [Description("usp_CondicaoPagamento_ObterTodos")]
        ObterTodos
    }
}
