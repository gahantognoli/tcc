using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class EnderecoClienteViewModel
    {
        public EnderecoClienteViewModel()
        {
            EnderecoClienteId = Guid.NewGuid();
        }

        [Key]
        public Guid EnderecoClienteId { get; set; }
        [Required(ErrorMessage = "Preencha o campo CEP")]
        [MinLength(14, ErrorMessage = "Tamanho mínimo 14 caracteres")]
        [MaxLength(14, ErrorMessage = "Tamanho máximo 14 caracteres")]
        public string CEP { get; set; }
        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Preencha o campo Endereço")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo 150 caracteres")]
        public string Endereco { get; set; }
        [Display(Name = "Número")]
        [Required(ErrorMessage = "Preencha o campo Número")]
        [MaxLength(15, ErrorMessage = "Tamanho máximo 15 caracteres")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MinLength(2, ErrorMessage = "Tamanho mínimo 2 caracteres")]
        [MaxLength(2, ErrorMessage = "Tamanho máximo 2 caracteres")]
        public string Estado { get; set; }
        [MaxLength(50, ErrorMessage = "Tamanho máximo 50 caracteres")]
        public string Complemento { get; set; }
        [ScaffoldColumn(false)]
        public Guid ClienteId { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
