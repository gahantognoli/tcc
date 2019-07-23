using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class TipoPedidoViewModel
    {
        public TipoPedidoViewModel()
        {
            TipoPedidoId = Guid.NewGuid();
        }

        [Key]
        public Guid TipoPedidoId { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [ScaffoldColumn(false)]
        public bool Padrao { get; set; } = false;
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
