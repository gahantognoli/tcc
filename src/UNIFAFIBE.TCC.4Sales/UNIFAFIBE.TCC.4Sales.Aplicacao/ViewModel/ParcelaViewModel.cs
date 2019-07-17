using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ParcelaViewModel
    {
        public Guid ParcelaId { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorComissao { get; set; }
        public DateTime DataPagamento { get; set; }
        public Guid FaturamentoId { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual FaturamentoViewModel Faturamento { get; set; }
    }
}
