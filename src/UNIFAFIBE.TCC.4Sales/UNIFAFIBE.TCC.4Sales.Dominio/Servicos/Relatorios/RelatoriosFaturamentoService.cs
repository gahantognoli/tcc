using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos.Relatorios
{
    public class RelatoriosFaturamentoService : IRelatoriosFaturamentoService
    {
        private readonly IRelatoriosFaturamentoRepositorio _relatoriosFaturamentoRepositorio;
        public RelatoriosFaturamentoService(IRelatoriosFaturamentoRepositorio relatoriosFaturamentoRepositorio)
        {
            _relatoriosFaturamentoRepositorio = relatoriosFaturamentoRepositorio;
        }

        public IEnumerable<FaturamentoPorPeriodo> PorPeriodo(DateTime dataEmissaoInicio, DateTime dataEmissaoFim)
        {
            return _relatoriosFaturamentoRepositorio.PorPeriodo(dataEmissaoInicio, dataEmissaoFim);
        }
    }
}
