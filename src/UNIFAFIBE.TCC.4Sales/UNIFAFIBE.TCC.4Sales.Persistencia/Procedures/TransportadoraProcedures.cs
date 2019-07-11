using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum TransportadoraProcedures
    {
        [Description("usp_Transportadorea_ObterPorId")]
        ObterPorId,
        [Description("usp_Transportadorea_ObterPorCidade")]
        ObterPorCidade,
        [Description("usp_Transportadorea_ObterPorEstado")]
        ObterPorEstado,
        [Description("usp_Transportadorea_ObterPorNome")]
        ObterPorNome,
        [Description("usp_Transportadorea_ObterTodos")]
        ObterTodos
    }
}
