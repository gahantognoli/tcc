
using DomainValidation.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ContatoClienteViewModel
    {
        public ContatoClienteViewModel()
        {
            ContatoClienteId = Guid.NewGuid();
        }

        [Key]
        public Guid ContatoClienteId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo Cargo")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo 50 caracteres")]
        public string Cargo { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo 20 caracteres")]
        public string Telefone { get; set; }
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
