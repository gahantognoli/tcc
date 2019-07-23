using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class CondicaoPagamentoViewModel
    {
        public CondicaoPagamentoViewModel()
        {
            CondicaoPagamentoId = Guid.NewGuid();
        }

        [Key]
        public Guid CondicaoPagamentoId { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo 20 caracteres")]
        public string Descricao { get; set; }
        [Display(Name = "Valor Mínimo")]
        public decimal ValorMinimo { get; set; }
        public virtual Guid RepresentadaId { get; set; }
        public virtual RepresentadaViewModel Representada { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }


        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
