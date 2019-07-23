using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class StatusPedidoViewModel
    {
        public StatusPedidoViewModel()
        {
            StatusPedidoId = Guid.NewGuid();
        }

        [Key]
        public Guid StatusPedidoId { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }
        public bool Padrao { get; set; } = false;

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
