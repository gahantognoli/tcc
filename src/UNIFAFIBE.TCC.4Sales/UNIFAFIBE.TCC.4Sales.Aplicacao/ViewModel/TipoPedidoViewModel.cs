using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class TipoPedidoViewModel
    {
        public TipoPedidoViewModel()
        {
            TipoPedidoId = new Guid();
        }

        [Key]
        public Guid TipoPedidoId { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        public string Descricao { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
