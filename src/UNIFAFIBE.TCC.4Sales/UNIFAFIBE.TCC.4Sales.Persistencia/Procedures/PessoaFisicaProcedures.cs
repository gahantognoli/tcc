using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum PessoaFisicaProcedures
    {
        [Description("usp_PessoaFisica_ObterPorId")]
        ObterPorId,
        [Description("usp_PessoaFisica_ObterTodos")]
        ObterTodos,
        [Description("usp_PessoaFisica_ObterPorCPF")]
        ObterPorCPF,
        [Description("usp_PessoaFisica_ObterPorNome")]
        ObterPorNome

    }
}
