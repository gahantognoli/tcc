using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos.Relatorios
{
    public interface IRelatoriosVendaAppService
    {
        IEnumerable<VendaPorPeriodo> PorPeriodo(DateTime dataEmissaoInicio, DateTime dataEmissaoFim);
        IEnumerable<VendaRankingVendedor> RankingVendedores(int mes, int ano);
    }
}
