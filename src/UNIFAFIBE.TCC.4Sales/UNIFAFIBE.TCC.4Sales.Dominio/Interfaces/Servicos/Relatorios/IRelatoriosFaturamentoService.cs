using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios
{
    public interface IRelatoriosFaturamentoService
    {
        IEnumerable<FaturamentoPorPeriodo> PorPeriodo(DateTime dataEmissaoInicio, DateTime dataEmissaoFim);
    }
}
