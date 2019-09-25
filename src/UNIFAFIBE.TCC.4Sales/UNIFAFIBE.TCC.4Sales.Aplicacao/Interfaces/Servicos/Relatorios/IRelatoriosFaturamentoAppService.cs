using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos.Relatorios
{
    public interface IRelatoriosFaturamentoAppService
    {
        IEnumerable<FaturamentoPorPeriodo> PorPeriodo(DateTime dataEmissaoInicio, DateTime dataEmissaoFim);
    }
}
