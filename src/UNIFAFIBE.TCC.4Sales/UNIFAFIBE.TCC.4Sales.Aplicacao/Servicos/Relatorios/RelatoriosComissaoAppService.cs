using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos.Relatorios
{
    public class RelatoriosComissaoAppService : IRelatoriosComissaoAppService
    {
        private readonly IRelatoriosComissaoService _relatoriosComissaoService;

        public RelatoriosComissaoAppService(IRelatoriosComissaoService relatoriosComissaoService)
        {
            _relatoriosComissaoService = relatoriosComissaoService;
        }

        public IEnumerable<ComissaoPorPeriodo> PorPeriodo(DateTime dataPagamentoInicio, DateTime dataPagamentoFim)
        {
            return _relatoriosComissaoService.PorPeriodo(dataPagamentoInicio, dataPagamentoFim);
        }
    }
}
