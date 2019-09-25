using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos.Relatorios
{
    public class RelatoriosVendaAppService : IRelatoriosVendaAppService
    {
        private readonly IRelatoriosVendaService _relatoriosVendaService;
        public RelatoriosVendaAppService(IRelatoriosVendaService relatoriosVendaService)
        {
            _relatoriosVendaService = relatoriosVendaService;
        }

        public IEnumerable<VendaPorPeriodo> PorPeriodo(DateTime dataEmissaoInicio, DateTime dataEmissaoFim)
        {
            return _relatoriosVendaService.PorPeriodo(dataEmissaoInicio, dataEmissaoFim);
        }

        public IEnumerable<VendaRankingVendedor> RankingVendedores(int mes, int ano)
        {
            return _relatoriosVendaService.RankingVendedores(mes, ano);
        }
    }
}
