namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IDashboardRepositorio
    {
        decimal ObterTotalFaturamento(int ano, int mes);
        decimal ObterTotalAReceber(int ano, int mes);
        decimal ObterMeta(int ano, int mes);
    }
}
