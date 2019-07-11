using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum UsuarioProcedures
    {
        [Description("usp_Usuario_ObterPorId")]
        ObterPorId,
        [Description("usp_Usuario_ObterPorNome")]
        ObterPorNome,
        [Description("usp_Usuario_ObterTodos")]
        ObterTodos
    }
}
