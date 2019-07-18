using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ParcelaViewModel
    {
        public Guid ParcelaId { get; set; }
        [Display(Name = "Número Parcela")]
        public int NumeroParcela { get; set; }
        [Display(Name = "Valor Parcela")]
        public decimal ValorParcela { get; set; }
        [Display(Name = "Valor Comissão")]
        public decimal ValorComissao { get; set; }
        [Display(Name = "Data do Pagamento")]
        public DateTime DataPagamento { get; set; }
        public Guid FaturamentoId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public virtual FaturamentoViewModel Faturamento { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
