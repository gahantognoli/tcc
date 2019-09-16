using System.ComponentModel;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Procedures
{
    public enum DashboardProcedures
    {
        [Description("usp_Dashboard_TotalFaturado")]
        ObterTotalFaturado,
        [Description("usp_Dashboard_TotalAReceber")]
        ObterTotalAReceber,
        [Description("usp_Dashboard_Meta")]
        ObterMeta
    }
}
