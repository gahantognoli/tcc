using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos
{
    public class DashboardAppService : IDashboardAppService
    {
        private readonly IDashboardService _dashboardService;

        public DashboardAppService(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public decimal ObterMeta(int ano, int mes)
        {
            return _dashboardService.ObterMeta(ano, mes);
        }

        public decimal ObterTotalAReceber(int ano, int mes)
        {
            return _dashboardService.ObterTotalAReceber(ano, mes);
        }

        public decimal ObterTotalFaturamento(int ano, int mes)
        {
            return _dashboardService.ObterTotalFaturamento(ano, mes);
        }
    }
}
