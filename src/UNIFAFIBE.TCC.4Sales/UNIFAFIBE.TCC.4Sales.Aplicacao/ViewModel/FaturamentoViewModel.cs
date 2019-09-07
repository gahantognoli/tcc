using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class FaturamentoViewModel
    {
        public FaturamentoViewModel()
        {
            FaturamentoId = Guid.NewGuid();
        }

        [Key]
        public Guid FaturamentoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Valor")]
        [Range(0, 9999999999999999.99)]
        public decimal Valor { get; set; }
        [Display(Name = "Nota Fisal")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo 50 caracteres")]
        public string NotaFiscal { get; set; }
        public DateTime DataEmissao { get; set; }
        [Display(Name = "Informações Adicionais")]
        [MaxLength(500, ErrorMessage = "Preencha o campo Informações Adicionais")]
        public string InformacoesAdicionais { get; set; }
        [ScaffoldColumn(false)]
        public Guid PedidoId { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual PedidoViewModel Pedido { get; set; }
        public virtual ICollection<ParcelaViewModel> Parcelas { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
