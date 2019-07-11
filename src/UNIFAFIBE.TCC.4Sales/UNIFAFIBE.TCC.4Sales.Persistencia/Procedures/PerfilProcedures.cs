using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum PerfilProcedures
    {
        [Description("usp_Perfil_ObterPorId")]
        ObterPorId,
        [Description("usp_Perfil_ObterTodos")]
        ObterTodos,
        [Description("usp_Perfil_ObterPorDescricao")]
        ObterPorDescricao
    }
}
