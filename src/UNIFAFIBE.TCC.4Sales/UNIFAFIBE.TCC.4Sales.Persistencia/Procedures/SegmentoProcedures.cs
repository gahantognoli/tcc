using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum SegmentoProcedures
    {
        [Description("usp_Segmento_ObterPorId")]
        ObterPorId,
        [Description("usp_Segmento_ObterTodos")]
        ObterTodos,
        [Description("usp_Segmento_ObterPorDescricao")]
        ObterPorDescricao
    }
}
