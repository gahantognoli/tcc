using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class TransportadoraViewModel
    {
        public Guid TransportadoraId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "Informações Adicionais")]
        public string InformacoesAdicionais { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }
    }
}
