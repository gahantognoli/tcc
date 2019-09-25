using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios.Relatorios
{
    public interface IRelatoriosVendaRepositorio
    {
        IEnumerable<VendaPorPeriodo> PorPeriodo(DateTime dataEmissaoInicio, DateTime dataEmissaoFim);
        IEnumerable<VendaRankingVendedor> RankingVendedores(int mes, int ano);
    }
}
