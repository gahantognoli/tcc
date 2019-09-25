using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos.Relatorios
{
    public class RelatoriosComissaoService : IRelatoriosComissaoService
    {
        private readonly IRelatoriosComissaoRepositorio _relatoriosComissaoRepositorio;

        public RelatoriosComissaoService(IRelatoriosComissaoRepositorio relatoriosComissaoRepositorio)
        {
            _relatoriosComissaoRepositorio = relatoriosComissaoRepositorio;
        }

        public IEnumerable<ComissaoPorPeriodo> PorPeriodo(DateTime dataPagamentoInicio, DateTime dataPagamentoFim)
        {
            return _relatoriosComissaoRepositorio.PorPeriodo(dataPagamentoInicio, dataPagamentoFim);
        }
    }
}
