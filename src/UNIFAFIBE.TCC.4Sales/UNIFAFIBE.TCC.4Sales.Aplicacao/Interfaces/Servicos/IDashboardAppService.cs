namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IDashboardAppService
    {
        decimal ObterTotalFaturamento(int ano, int mes);
        decimal ObterTotalAReceber(int ano, int mes);
        decimal ObterMeta(int ano, int mes);
    }
}
