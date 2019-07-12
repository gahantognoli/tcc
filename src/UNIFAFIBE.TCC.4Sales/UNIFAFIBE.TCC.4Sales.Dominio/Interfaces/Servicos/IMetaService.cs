using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IMetaService
    {
        IEnumerable<Meta> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}
