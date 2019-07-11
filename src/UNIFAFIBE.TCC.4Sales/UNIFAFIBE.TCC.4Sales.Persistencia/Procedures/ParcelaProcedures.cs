using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum ParcelaProcedures
    {
        [Description("usp_Parcela_ObterPorId")]
        ObterPorId,
        [Description("usp_Parcela_ObterTodos")]
        ObterTodos
    }
}
