using DomainValidation.Validation;
using System;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.ContatosCliente;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class ContatoCliente
    {
        public ContatoCliente()
        {
            ContatoClienteId = Guid.NewGuid();
        }
        public Guid ContatoClienteId { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Guid ClienteId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual Cliente Cliente { get; set; }

        public bool EhValido()
        {
            return this.EstaConsistente();
        }

        public bool EstaConsistente()
        {
            ValidationResult = new ContatoClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto()
        {
            return true;
        }
    }
}
