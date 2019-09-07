using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum PessoaJuridicaProcedures
    {
        [Description("usp_PessoaJuridica_ObterPorId")]
        ObterPorId,
        [Description("usp_PessoaJuridica_ObterTodos")]
        ObterTodos,
        [Description("usp_PessoaJuridica_ObterPorCNPJ")]
        ObterPorCNPJ,
        [Description("usp_PessoaJuridica_ObterPorInscricaoEstadual")]
        ObterPorInscricaoEstadual,
        [Description("usp_PessoaJuridica_ObterPorNomeFantasia")]
        ObterPorNomeFantasia,
        [Description("usp_PessoaJuridica_ObterPorRazaoSocial")]
        ObterPorRazaoSocial,
        [Description("usp_PessoaJuridica_ObterPorSegmento")]
        ObterPorSegmento
    }
}
