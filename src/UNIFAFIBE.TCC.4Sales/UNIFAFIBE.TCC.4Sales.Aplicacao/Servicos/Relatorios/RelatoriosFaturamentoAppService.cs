using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos.Relatorios
{
    public class RelatoriosFaturamentoAppService : IRelatoriosFaturamentoAppService
    {
        private readonly IRelatoriosFaturamentoService _relatoriosFaturamentoService;

        public RelatoriosFaturamentoAppService(IRelatoriosFaturamentoService relatoriosFaturamentoService)
        {
            _relatoriosFaturamentoService = relatoriosFaturamentoService;
        }

        public IEnumerable<FaturamentoPorPeriodo> PorPeriodo(DateTime dataEmissaoInicio, DateTime dataEmissaoFim)
        {
            return _relatoriosFaturamentoService.PorPeriodo(dataEmissaoInicio, dataEmissaoFim);
        }
    }
}
