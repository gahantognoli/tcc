using DomainValidation.Validation;
using System;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.ContatosRepresentada;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class ContatoRepresentada
    {
        public ContatoRepresentada()
        {
            ContatoRepresentadaId = new Guid();
        }
        public Guid ContatoRepresentadaId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Telefone { get; set; }
        public Guid RepresentadaId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual Representada Representada { get; set; }

        public bool EhValido()
        {
            return this.EstaConsistente();
        }

        public bool EstaConsistente()
        {
            ValidationResult = new ContatoRepresentadaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto()
        {
            return true;
        }
    }
}
