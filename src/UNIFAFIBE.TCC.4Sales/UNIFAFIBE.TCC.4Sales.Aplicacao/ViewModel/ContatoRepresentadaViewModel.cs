using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ContatoRepresentadaViewModel
    {
        public Guid ContatoRepresentadaId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Telefone { get; set; }
        public Guid RepresentadaId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual RepresentadaViewModel Representada { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.Erros.Count() == 0;
        }
    }
}
