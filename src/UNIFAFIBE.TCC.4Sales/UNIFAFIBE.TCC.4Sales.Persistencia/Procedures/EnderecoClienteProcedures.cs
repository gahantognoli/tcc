using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum EnderecoClienteProcedures
    {
        [Description("usp_EnderecoCliente_ObterPorId")]
        ObterPorId,
        [Description("usp_EnderecoCliente_ObterTodos")]
        ObterTodos
    }
}
