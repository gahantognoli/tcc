using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum MetaProcedures
    {
        [Description("usp_Meta_ObterPorId")]
        ObterPorId,
        [Description("usp_Meta_ObterPorPeriodo")]
        ObterPorPeriodo,
        [Description("usp_Meta_ObterTodos")]
        ObterTodos
    }
}
