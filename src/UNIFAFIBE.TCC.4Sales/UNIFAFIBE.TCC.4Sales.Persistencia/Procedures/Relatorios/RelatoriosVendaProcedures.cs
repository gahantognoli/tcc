using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures.Relatorios
{
    public enum RelatoriosVendaProcedures
    {
        [Description("usp_Relatorio_Venda_PorPeriodo")]
        PorPeriodo,
        [Description("usp_Relatorio_Venda_RankingVendedores")]
        RankingVendedores
    }
}
