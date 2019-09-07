using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum RepresentadaProcedures
    {
        [Description("usp_Representada_ObterPorId")]
        ObterPorId,
        [Description("usp_Representada_ObterTodos")]
        ObterTodos,
        [Description("usp_Representada_ObterPorCnpj")]
        ObterPorCnpj,
        [Description("usp_Representada_ObterPorNomeFantasia")]
        ObterPorNomeFantasia,
        [Description("usp_Representada_ObterPorRazaoSocial")]
        ObterPorRazaoSocial,
        [Description("usp_Representada_Remover")]
        Remover
    }
}
