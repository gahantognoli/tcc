using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class StatusPedidoViewModel
    {
        public Guid StatusPedidoId { get; set; }
        public string Descricao { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }
    }
}
