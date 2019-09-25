using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos.Relatorios
{
    public class RelatoriosVendaService : IRelatoriosVendaService
    {
        private readonly IRelatoriosVendaRepositorio _relatoriosVendaRepositorio;
        public RelatoriosVendaService(IRelatoriosVendaRepositorio relatoriosVendaRepositorio)
        {
            _relatoriosVendaRepositorio = relatoriosVendaRepositorio;
        }

        public IEnumerable<VendaPorPeriodo> PorPeriodo(DateTime dataEmissaoInicio, DateTime dataEmissaoFim)
        {
            return _relatoriosVendaRepositorio.PorPeriodo(dataEmissaoInicio, dataEmissaoFim);
        }

        public IEnumerable<VendaRankingVendedor> RankingVendedores(int mes, int ano)
        {
            return _relatoriosVendaRepositorio.RankingVendedores(mes, ano);
        }
    }
}
