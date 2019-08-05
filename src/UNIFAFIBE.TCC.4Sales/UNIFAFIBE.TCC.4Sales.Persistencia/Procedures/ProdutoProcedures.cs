using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum ProdutoProcedures
    {
        [Description("usp_Produto_ObterPorId")]
        ObterPorId,
        [Description("usp_Produto_ObterTodos")]
        ObterTodos,
        [Description("usp_Produto_ObterPorFaixaDePreco")]
        ObterPorFaixaDePreco,
        [Description("usp_Produto_ObterPorCodigo")]
        ObterPorCodigo,
        [Description("usp_Produto_ObterPorNome")]
        ObterPorNome

    }
}
