using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios.Relatorios
{
    public interface IRelatoriosComissaoRepositorio
    {
        IEnumerable<ComissaoPorPeriodo> PorPeriodo(DateTime dataPagamentoInicio, DateTime dataPagamentoFim);
    }
}
