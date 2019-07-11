using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum ContatoClienteProcedures
    {
        [Description("usp_ContatoCliente_ObterPorId")]
        ObterPorId,
        [Description("usp_ContatoCliente_ObterTodos")]
        ObterTodos
    }
}
