using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ClienteViewModel
    {
        public Guid ClienteId { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        [Display(Name = "Informações Adicionais")]
        public string InformacoesAdicionais { get; set; }
        public Guid SegmentoId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual SegmentoViewModel Segmento { get; set; }
        public virtual ICollection<ContatoClienteViewModel> ContatosCliente { get; set; }
        public virtual ICollection<EnderecoClienteViewModel> EnderecosCliente { get; set; }
        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.Erros.Count() == 0;
        }
    }
}
