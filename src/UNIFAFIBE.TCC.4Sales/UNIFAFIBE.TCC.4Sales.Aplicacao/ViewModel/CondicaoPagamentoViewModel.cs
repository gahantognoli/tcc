using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class CondicaoPagamentoViewModel
    {
        public Guid CondicaoPagamentoId { get; set; }
        public string Descricao { get; set; }
        public decimal ValorMinimo { get; set; }
        public virtual Guid RepresentadaId { get; set; }
        public virtual RepresentadaViewModel Representada { get; set; }
        public ValidationResult ValidationResult { get; set; }


        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }
    }
}
