using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ClienteId = Guid.NewGuid();
            EnderecosCliente = new List<EnderecoClienteViewModel>();
            ContatosCliente = new List<ContatoClienteViewModel>();
        }   

        [Key]
        public Guid ClienteId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(20, ErrorMessage ="Tamanho máximo 20 caracteres")]
        public string Telefone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Preencha o campo Email")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um Email válido")]
        public string Email { get; set; }
        [Display(Name = "Informações Adicionais")]
        [MaxLength(500, ErrorMessage = "Tamanho máximo 500 caracteres")]
        [ScaffoldColumn(false)]
        public string InformacoesAdicionais { get; set; }
        [ScaffoldColumn(false)]
        public Guid SegmentoId { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual SegmentoViewModel Segmento { get; set; }
        public virtual ICollection<ContatoClienteViewModel> ContatosCliente { get; set; }
        public virtual ICollection<EnderecoClienteViewModel> EnderecosCliente { get; set; }
        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
