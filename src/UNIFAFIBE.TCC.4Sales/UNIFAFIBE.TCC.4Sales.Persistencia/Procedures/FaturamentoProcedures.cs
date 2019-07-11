using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum FaturamentoProcedures
    {
        [Description("usp_Faturamento_ObterPorId")]
        ObterPorId,
        [Description("usp_Faturamento_ObterTodos")]
        ObterTodos
    }
}
