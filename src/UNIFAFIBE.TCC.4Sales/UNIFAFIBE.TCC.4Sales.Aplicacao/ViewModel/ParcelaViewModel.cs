using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ParcelaViewModel
    {
        public ParcelaViewModel()
        {
            ParcelaId = new Guid();
        }

        [Key]
        public Guid ParcelaId { get; set; }
        [Display(Name = "Nº da Parcela")]
        [Required(ErrorMessage = "Preencha o campo Nº da Parcela")]
        public int NumeroParcela { get; set; }
        [Display(Name = "Valor da Parcela")]
        [Required(ErrorMessage = "Preencha o campo Valor da parcela")]
        [Range(0, 9999999999999999.99)]
        public decimal ValorParcela { get; set; }
        [Display(Name = "Valor da Comissão")]
        [Required(ErrorMessage = "Preencha o campo Valor da Comissão")]
        [Range(0, 9999999999999999.99)]
        public decimal ValorComissao { get; set; }
        [Display(Name = "Data do Pagamento")]
        [Required(ErrorMessage = "Preencha o campo Data do Pagamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataPagamento { get; set; }
        [ScaffoldColumn(false)]
        public Guid FaturamentoId { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public virtual FaturamentoViewModel Faturamento { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
