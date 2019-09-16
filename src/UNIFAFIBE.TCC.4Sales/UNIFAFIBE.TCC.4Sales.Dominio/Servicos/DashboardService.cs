using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepositorio _dashboardRepositorio;

        public DashboardService(IDashboardRepositorio dashboardRepositorio)
        {
            _dashboardRepositorio = dashboardRepositorio;
        }

        public decimal ObterMeta(int ano, int mes)
        {
            return _dashboardRepositorio.ObterMeta(ano, mes);
        }

        public decimal ObterTotalAReceber(int ano, int mes)
        {
            return _dashboardRepositorio.ObterTotalAReceber(ano, mes);
        }

        public decimal ObterTotalFaturamento(int ano, int mes)
        {
            return _dashboardRepositorio.ObterTotalFaturamento(ano, mes);
        }
    }
}
